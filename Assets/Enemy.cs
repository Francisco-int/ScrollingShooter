using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] float velocidad;
    [SerializeField] int numEnemy;
    [SerializeField] GameManager gameManager;
    [SerializeField] Transform player;
    [SerializeField] GameObject proyectil;
    [SerializeField] float forceShot;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("ff1");

    }
    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        numEnemy += gameManager.enemynum;
        Shot();
        Debug.Log("ff");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + new Vector3(0, 0, velocidad * Time.deltaTime);
        if (transform.position.z > 15 || transform.position.z > 7)
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

    void Shot()
    {
        GameObject newProyectil = Instantiate(proyectil, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        Rigidbody rb = newProyectil.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * forceShot, ForceMode.Impulse);
        StartCoroutine(Disparar());
        Debug.Log("Disparo");

    }
    void Dead()
    {
        gameManager.SetAbleEnemy(numEnemy);
        gameObject.SetActive(false);
    }
    IEnumerator Disparar()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 2));
        Shot();
    }
}
