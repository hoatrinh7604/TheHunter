using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] bool isTargetAnimal = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            isTargetAnimal = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isTargetAnimal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            isTargetAnimal = false;
        }
    }

    public bool IsTargetAnimal()
    {
        return isTargetAnimal;
    }

    public void Reset()
    {
        isTargetAnimal=false;
    }
}
