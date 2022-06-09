using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField] float speed = 5;
    private Vector3 target;

    private ObjectController objController;

    // Start is called before the first frame update
    void Start()
    {
        objController = GetComponent<ObjectController>();
        Destroy(gameObject,20f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!objController.isDeath)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void Settarget(Vector3 target)
    {
        this.target = target;
    }

    public void Escape()
    {
        if(GetComponent<ObjectController>().IsEnemy())
            GameController.Instance.UpdateSlider(1);
    }

    public void UpdateSpeed(float value)
    {
        speed = value;
    }
}
