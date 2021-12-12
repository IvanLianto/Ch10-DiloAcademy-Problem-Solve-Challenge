using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2 : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        PushBall();
    }

    private void PushBall()
    {
        var angle = Random.Range(-45f, 45f);
        Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

        rb.AddForce(dir * force);
    }
}
