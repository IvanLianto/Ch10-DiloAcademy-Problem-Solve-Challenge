using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController5 : MonoBehaviour
{
    Vector3 mousePosition;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 boundary;

    void Start()
    {
        
    }

    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        Boundary();
    }

    private void Boundary()
    {
        if (transform.position.y >= boundary.y)
        {
            transform.position = new Vector2(transform.position.x, boundary.y);
        }

        if (transform.position.y <= -boundary.y)
        {
            transform.position = new Vector2(transform.position.x, -boundary.y);
        }

        if (transform.position.x >= boundary.x)
        {
            transform.position = new Vector2(boundary.x, transform.position.y);
        }

        if (transform.position.x <= -boundary.x)
        {
            transform.position = new Vector2(-boundary.x, transform.position.y);
        }
    }
}
