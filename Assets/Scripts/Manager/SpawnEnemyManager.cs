using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    private GameObject circle;

    [SerializeField] private GameObject enemy;

    private ObjectPoolEnemy OP;

    void Start()
    {
        OP = ObjectPoolEnemy.SharedInstance;
        circle = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (PlayerData.SCORE >= 0 && !PlayerData.START_GAME)
        {
            yield return new WaitForSeconds(2f);
            OP.AddObjectPool(enemy, 1);
            var spawn = OP.GetPooledObject();

            if ((RandomPos() - circle.transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                spawn.transform.position = RandomPos();
                spawn.transform.rotation = Quaternion.identity;
                spawn.SetActive(true);
            }

        }
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-7f, 7f), Random.Range(-3f, 3f));
    }

}
