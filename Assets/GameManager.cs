using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int enemiesAmount;
    [SerializeField] List<GameObject> enemiesObjects;
    [SerializeField] GameObject enemyObject;
    [SerializeField] Transform enemyPosAppear;
    [SerializeField] float timeToAppearAgain;
    [SerializeField] int limitEnemiesDead;
    [SerializeField] int addLimitenemiesDead;
    [SerializeField] int enemiesKilled;
    [SerializeField] int killBoss;
    public int enemynum;
    float rot;
    bool ableSpawnEnemies;
    [SerializeField] GameObject boss;
    // Start is called before the first frame update
    void Start()
    {

        ableSpawnEnemies = true;
        for (int i = 0; i < enemiesAmount; i++)
        {
            GameObject enemy = Instantiate(enemyObject, Vector3.zero, Quaternion.identity);
            enemy.SetActive(false);
            enemiesObjects.Add(enemy);
            enemynum++;
        }
        Invoke("EnemiesAppear", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesKilled > limitEnemiesDead)
        {
            ChangeRotGame();

        }
        if(enemiesKilled > killBoss)
        {
            ableSpawnEnemies = false;
            boss.SetActive(true);
        }
    }

    void ChangeRotGame()
    {
        rot += 90;
        limitEnemiesDead += addLimitenemiesDead;

        //MovimientoCamara movimientoCamara = GameObject.Find("Camera").GetComponent<MovimientoCamara>();
        //movimientoCamara.ChangeRot(rot);
    }

    void EnemiesAppear()
    {
        if(ableSpawnEnemies)
        {
         
            for (int i = 0; i < enemiesObjects.Count; i++)
        {
                enemyPosAppear.transform.position = new Vector3(Random.Range(8, -8), 0, -9.19f);
                enemiesObjects[i].transform.position = enemyPosAppear.position;
                enemiesObjects[i].SetActive(true);
                StartCoroutine(randomTimeSpawn());
                
        }
        }
        
    }

    public void SetAbleEnemy(int enemyToActivate)
    {
        StartCoroutine(AppearAgain(enemyToActivate));
    }

    IEnumerator AppearAgain(int enemyToActivate)
    {
        if (ableSpawnEnemies)
        {
            enemiesKilled++;
            enemyToActivate--;
            yield return new WaitForSeconds(Random.Range(0, timeToAppearAgain));
            enemyPosAppear.transform.position = new Vector3(Random.Range(8, -8), 0, -9.19f);
            enemiesObjects[enemyToActivate].transform.position = enemyPosAppear.position;
            enemiesObjects[enemyToActivate].SetActive(true);
        }
           
    }
    IEnumerator randomTimeSpawn()
    {
        yield return new WaitForSeconds(Random.Range(0, timeToAppearAgain));
        
    }
}
