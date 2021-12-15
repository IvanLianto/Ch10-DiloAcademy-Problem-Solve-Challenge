using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [SerializeField] private GameObject square;
    [SerializeField] private int counter;

    private GameObject circle;

    private int numberToSpawn;

    private ObjectPool OP;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        OP = ObjectPool.SharedInstance;
        circle = GameObject.FindGameObjectWithTag("Player");
        InitSquare();
    }

    private void InitSquare()
    {
        numberToSpawn = Random.Range(5, 15);

        OP.AddObjectPool(square, numberToSpawn);


        while(counter < numberToSpawn)
        {
            var spawn = OP.GetPooledObject();

            if ((RandomPos() - circle.transform.position).magnitude < 3)
            {
                continue;
            } else
            {
                spawn.transform.position = RandomPos();
                spawn.transform.rotation = Quaternion.identity;
                spawn.SetActive(true);
                counter++;
            }
        }
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f));
    }

    public void SpawnSquare()
    {
        if (counter < numberToSpawn)
        {
            var spawn = OP.GetPooledObject();
            if ((RandomPos() - circle.transform.position).magnitude >= 3)
            {
                spawn.transform.position = RandomPos();
                spawn.transform.rotation = Quaternion.identity;
                spawn.SetActive(true);
                counter++;
            }
        }
    }

    public void Invoke()
    {
        InvokeRepeating(nameof(SpawnSquare), 3f, 3f);
    }

    public void SetCounter(int amount)
    {
        counter += amount;
    }
}
