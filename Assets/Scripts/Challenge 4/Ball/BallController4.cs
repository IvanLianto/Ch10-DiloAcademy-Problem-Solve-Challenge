using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController4 : MonoBehaviour
{
    [SerializeField] private float speed;


    void Start()
    {
        
    }

    void Update()
    {
        KeyboardController();
    }

    private void KeyboardController()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(x, y) * speed * Time.deltaTime);
    }
}
