using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float velocidad;
    [SerializeField] public int numEnemy;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform player;
    
    
    
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        numEnemy = gameManager.enemynum;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0,0,velocidad * Time.deltaTime);
        if(transform.position.z > 15 || transform.position.z > 7)
        {
            Dead();
        }
        transform.LookAt(player.transform.position);

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
