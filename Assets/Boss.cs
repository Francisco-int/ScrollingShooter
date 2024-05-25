using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

   [SerializeField] int vida;
   [SerializeField] Transform cañonUno;
   [SerializeField] Transform cañonDos;
    [SerializeField] GameObject proyectil;
    [SerializeField] float forceShot;
   [SerializeField] float velocidad;
   [SerializeField] bool bossActive;
    // Start is called before the first frame update
    void Start()
    {
        bossActive = true;
    }
    private void Awake()
    {
        InvokeRepeating("Disparo", 1, 0.5f);

    }
    // Update is called once per frame
    void Update()
    {
        if (bossActive)
        {
            transform.Translate(transform.forward * Time.deltaTime * velocidad);
        }
        if (transform.position.z >= -6.48)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -6.48f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Proyectil"))
        {
            vida--;
            if(vida <= 0)
            {
                Destroy(gameObject);
            }
        }

    }
    void Disparo()
    {
       StartCoroutine(DisparoIntervalo());
       StartCoroutine(DisparoIntervalo1());
    }
    IEnumerator DisparoIntervalo()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        GameObject newProyectil = Instantiate(proyectil, cañonUno);
        Rigidbody rb = newProyectil.GetComponent<Rigidbody>();
        rb.AddForce(cañonUno.transform.forward * forceShot, ForceMode.Impulse);
    }
    IEnumerator DisparoIntervalo1()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        GameObject newProyectil = Instantiate(proyectil, cañonDos);
        Rigidbody rb = newProyectil.GetComponent<Rigidbody>();
        rb.AddForce(cañonDos.transform.forward * forceShot, ForceMode.Impulse);
    }

}
