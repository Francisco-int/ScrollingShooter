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
    public int enemynum;
    // Start is called before the first frame update
    void Start()
    {
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


    }
     void EnemiesAppear()
    {
        for (int i = 0; i < enemiesObjects.Count; i++)
        {
            enemyPosAppear.position = new Vector3(Random.Range(8, -8), 0, -9.19f);
            enemiesObjects[i].transform.position = enemyPosAppear.position;
            enemiesObjects[i].SetActive(true);
           
        }
    }

    public void SetAbleEnemy(int enemyToActivate)
    {
        StartCoroutine(AppearAgain(enemyToActivate));
    }

    IEnumerator AppearAgain(int enemyToActivate)
    {
        yield return new WaitForSeconds(Random.Range(0, timeToAppearAgain));
        enemyPosAppear.position = new Vector3(Random.Range(8, -8), 0, -9.19f);
        enemiesObjects[enemyToActivate].transform.position = enemyPosAppear.position;
        enemiesObjects[enemyToActivate].SetActive(true);
    }
}
