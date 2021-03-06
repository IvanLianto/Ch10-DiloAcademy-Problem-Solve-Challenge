using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolEnemy : MonoBehaviour
{
    public static ObjectPoolEnemy SharedInstance;

    [SerializeField] private List<GameObject> pooledObjects;
    [SerializeField] private GameObject objectToPools = null;

    private void Awake()
    {
        SharedInstance = this;

        pooledObjects = new List<GameObject>();
    }

    public void AddObjectPool(GameObject obj, int amountToPool = 4)
    {
        GameObject tmp;
        for (var i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(obj);
            tmp.transform.parent = transform;
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (var i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
