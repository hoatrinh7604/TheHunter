using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawController : MonoBehaviour
{
    [SerializeField] GameObject[] objects;

    [SerializeField] Transform spawPointMin;
    [SerializeField] Transform spawPointMax;
    [SerializeField] GameObject currentAnimal;
    [SerializeField] GameObject effect;

    public void SpawObject()
    {
        int index = Random.Range(0, objects.Length);
        GameObject obj = Instantiate(objects[index], transform);
        
        float x = Random.Range(spawPointMin.position.x, spawPointMax.position.x);
        obj.transform.position = new Vector3(x, spawPointMin.position.y, 0);
        obj.transform.localPosition = new Vector3(obj.transform.localPosition.x, spawPointMin.localPosition.y, 0);

        int randomScale = Random.Range(30, 41);
        obj.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        currentAnimal = obj;
    }

    public void Kill()
    {
        var eff = Instantiate(effect, Vector3.zero, Quaternion.identity, transform);
        eff.transform.position = new Vector3(currentAnimal.transform.position.x, currentAnimal.transform.position.y, currentAnimal.transform.position.z);
        eff.transform.localScale = new Vector3(100, 100, 100);
        Destroy(currentAnimal);
        Destroy(eff, 0.5f);
    }
}
