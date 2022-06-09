using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    [SerializeField] GameObject gameOver;
    [SerializeField] Slider slider;
    [SerializeField] TextMeshProUGUI timeGP;
    [SerializeField] TextMeshProUGUI hightimeGP;
    [SerializeField] TextMeshProUGUI timeGO;

    [SerializeField] SpawController spawController;
    [SerializeField] GunController gunController;

    float score = 0;
    float highscore = 0;
    float sliderValue = 0;

    private float time;
    [SerializeField] float timeOfGame;

    private void Start()
    {
        Reset();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        UpdateSlider(time);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void OnShoot()
    {
        if(gunController.IsTargetAnimal())
        {
            slider.value = 1000;
            spawController.Kill();
            UpdateScore();
            StartCoroutine(StartNewTurn());
        }
        else
        {
            GameOver();
        }
    }

    IEnumerator StartNewTurn()
    {
        yield return new WaitForSeconds(1f);
        NextTurn();
    }

    public void UpdateScore()
    {
        score++;
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetFloat("time", highscore);
            hightimeGP.text = ((int)highscore).ToString();
        }
        timeGP.text = score.ToString();
        timeGO.text = score.ToString();
    }

    public void NextTurn()
    {
        gunController.Reset();
        time = timeOfGame;
        UpdateSlider(time);
        spawController.SpawObject();
    }

    public void UpdateSlider(float value)
    {
        slider.value = value;

        CheckGameState();
    }

    public void Restart()
    {
        GetComponent<SceneController>().StartGame();
    }

    public void CheckGameState()
    {
        if(sliderValue <= 0)
        {
            GameOver();
        }
    }

    public void Reset()
    {
        Time.timeScale = 1;
        gameOver.SetActive(false);
        time = timeOfGame;
        sliderValue = time;
        score = 0;
        slider.value = sliderValue;
        slider.maxValue = sliderValue;
        highscore = PlayerPrefs.GetFloat("time");
        hightimeGP.text = ((int)highscore).ToString();
        timeGP.text = score.ToString();
        timeGO.text = score.ToString();

        NextTurn();
    }
}
