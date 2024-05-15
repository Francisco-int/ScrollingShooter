using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] float rateRounds;
    [SerializeField] int enemiesAmount;
    [SerializeField] int enemiesAddAmount;
    [SerializeField] bool startRound;
    [SerializeField] float addRateRound;
    [SerializeField] List<GameObject> enemiesObjects;
    [SerializeField] GameObject enemyObject;

    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (time == rateRounds)
        {
            time = 0;
            rateRounds = addRateRound;
            RoundEnemies();
            
        }
    }

    void RoundEnemies()
    {
        for (int i = 0; i < enemiesAmount; i++)
        {
            enemiesObjects.Add(enemyObject);
        }
        for (int i = 0; i < enemiesObjects.Count; i++)
        {
            enemiesObjects[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < enemiesAddAmount; i++)
        {
            enemiesObjects.Add(enemyObject);
        }

    }
}
