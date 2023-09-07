using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusManager : MonoBehaviour
{
    [SerializeField] Transform[] posEnemys;

    [SerializeField] GameObject[] enemysBoss;

    [SerializeField] List<int> list = new List<int>();

    [SerializeField] int randomPos;

    [SerializeField] bool existsNumber;


    void Start()
    {
        randomPos = Random.Range(0, 4);
        InvokeRepeating("SpawnObject", 1, 2);
    }

    void SpawnObject()
    {
        randomPos = Random.Range(0, 4);
        list.Add(randomPos);

        Debug.Log(randomPos);


        posEnemys[randomPos].GetChild(0).gameObject.SetActive(true);


        if (list.Contains(randomPos))
        {
            if (list.Count > 5)
            {
                existsNumber = true;

                if (existsNumber)
                {
                    foreach (var enemy in enemysBoss)
                    {
                        enemy.SetActive(false);
                        existsNumber = false;
                    }
                }

                list.Clear();
                randomPos = Random.Range(0, 4);
            }
        }
    }
}