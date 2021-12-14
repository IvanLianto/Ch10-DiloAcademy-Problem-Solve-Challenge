using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject square;
    [SerializeField] private int numberToSpawn;
    [SerializeField] private int counter;

    private GameObject circle;

    private ObjectPool OP;

    void Start()
    {
        OP = ObjectPool.SharedInstance;
        circle = GameObject.FindGameObjectWithTag("Player");
        SpawnSquare();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSquare()
    {
        while(counter < numberToSpawn)
        {
            Vector3 pos = new Vector3(Random.Range(-6.71f, 6.71f), Random.Range(-2.74f, 2.74f));
            var spawn = OP.GetPooledObject();

            if ((pos - circle.transform.position).magnitude < 3)
            {
                continue;
            } else
            {
                spawn.transform.position = pos;
                spawn.transform.rotation = Quaternion.identity;
                spawn.SetActive(true);
                counter++;
            }

        }
    }
}
