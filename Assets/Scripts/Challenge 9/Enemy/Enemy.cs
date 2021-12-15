using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject circle;

    void Start()
    {
        circle = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(DestroyEnemy());
    }

    void Update()
    {
        if (!PlayerData.START_GAME)
        {
            transform.position = Vector2.MoveTowards(transform.position, circle.transform.position, 1.5f * Time.deltaTime);
        }
        
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
