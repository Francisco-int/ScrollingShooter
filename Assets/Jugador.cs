using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField]float velocidadJugador;
    [SerializeField] float tiempoEnfriamiento;
    [SerializeField] float fuerzaDisparo;
    [SerializeField] List<GameObject> proyectilInstances;
    [SerializeField] GameObject proyectilPrefab;
    int proyectilADiparar;
    bool ableDisparador;
    Transform cañon;
    [SerializeField] int cantidadProyectiles;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < cantidadProyectiles; i++)
        {
            GameObject proyectilInstance = Instantiate(proyectilPrefab, Vector3.zero, Quaternion.identity);
            proyectilInstances.Add(proyectilInstance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovimientoJugador();

    }

    void MovimientoJugador()
    {
       horizontal  = Input.GetAxis("Horizontal");
       vertical  = Input.GetAxis("Vertical");

       Vector3 direccion = new Vector3 (horizontal, 0, vertical);  

        transform.Translate(direccion * Time.deltaTime * velocidadJugador);

    }
    void Ataque()
    {
        /*       
        if(Input.GetKey(KeyCode.Space) && ableDisparador)
        {
            proyectilPrefab[proyectilADiparar].transform.position = cañon.position;
            proyectilPrefab[proyectilADiparar].SetActive(true);
            Rigidbody rb = proyectilPrefab[proyectilADiparar].GetComponent<Rigidbody>();
            rb.AddForce(rb.transform.forward * fuerzaDisparo, ForceMode.Impulse);
            proyectilADiparar++;

            
            

            if(proyectilADiparar == proyectilPrefab.Length)
            {
               ableDisparador = false;
               StartCoroutine(Enfriamiento());

            }
        }
        */
    }

    IEnumerator Enfriamiento()
    {
        //proyectilADiparar = 0;
        //for (int i = 0; i < proyectilPrefab.Length; i++)
        //{
        //    proyectilPrefab[i].SetActive(false);
        //}
        //yield return new WaitForSeconds(tiempoEnfriamiento);
        //ableDisparador = true; 
        return null;

    }
}
