using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPools = null;
    [SerializeField] private int amountToPool = 10;

    private void Awake()
    {
        SharedInstance = this;

        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for (var i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectToPools);
            tmp.transform.parent = transform;
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }

    }

    public GameObject GetPooledObject()
    {
        for (var i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
