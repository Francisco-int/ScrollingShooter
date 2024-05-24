using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float velocidad;
    [SerializeField] public int numEnemy;
    [SerializeField] GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        numEnemy = gameManager.enemynum;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * velocidad);
        if(transform.position.z > 15 || transform.position.z > 7)
        {
            Dead();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Proyectil"))
        {
            Dead();
        }
    }
    
    void Dead()
    {
        gameManager.SetAbleEnemy(numEnemy);
        gameObject.SetActive(false);
    }
}
