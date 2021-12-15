using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController9 : MonoBehaviour
{
    Vector3 mousePosition;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector2 boundary;

    private void Start()
    {
        SpawnManager.Instance.Invoke();
    }

    void Update()
    {
        if (!PlayerData.DISABLE_INPUT)
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed * Time.deltaTime);
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Kotak"))
        {
            ScoreManager.Instance.SetScore(1, ScoreState.ADD);
            UIMain.Instance.SetScoreText();
            collision.gameObject.SetActive(false);

            SpawnManager.Instance.SetCounter(-1);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            ScoreManager.Instance.SetScore(2, ScoreState.SUBSTRACT);
            UIMain.Instance.SetScoreText();
            collision.gameObject.SetActive(false);
        }
    }
}
