using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] Camera camera;

    private float cameraZDistance;

    [SerializeField] float minX, maxX;
    [SerializeField] float minY, maxY;

    private void Start()
    {
        camera = Camera.main;
        cameraZDistance = camera.WorldToScreenPoint(transform.position).z;
    }

    private void OnMouseDrag()
    {
        cameraZDistance = camera.WorldToScreenPoint(transform.position).z;
        Vector3 screenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraZDistance);

        Vector3 newWorldPosition = camera.ScreenToWorldPoint(screenPosition);
        transform.position = transform.position + newWorldPosition.normalized;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        HandlePos();
    }

    public void HandlePos()
    {
        if(transform.localPosition.x < minX)
        {
            transform.localPosition = new Vector3(minX, transform.localPosition.y, 0);
        }
        else if(transform.localPosition.x > maxX)
        {
            transform.localPosition = new Vector3(maxX, transform.localPosition.y, 0);
        }

        if (transform.localPosition.y < minY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, minY, 0);
        }
        else if (transform.localPosition.y > maxY)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, maxY, 0);
        }
    }
}
