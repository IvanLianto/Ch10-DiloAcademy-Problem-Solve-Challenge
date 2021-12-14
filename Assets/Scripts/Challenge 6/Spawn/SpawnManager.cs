using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject square;
    [SerializeField] private int counter;

    private GameObject circle;

    private int numberToSpawn;

    private ObjectPool OP;

    void Start()
    {
        OP = ObjectPool.SharedInstance;
        circle = GameObject.FindGameObjectWithTag("Player");
        SpawnSquare();
    }

    private void SpawnSquare()
    {
        numberToSpawn = Random.Range(5, 15);

        OP.AddObjectPool(square, numberToSpawn);


        while(counter < numberToSpawn)
        {
            Vector3 pos = new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f));
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
