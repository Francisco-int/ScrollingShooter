using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{   
    [SerializeField] GameObject proyectil;
    [SerializeField] Transform shotPoint;
    [SerializeField] float forceShot;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shot", 1, 2);

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void Shot()
    {
        GameObject newProyectil = Instantiate(proyectil, shotPoint);
        Rigidbody rb = newProyectil.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * forceShot, ForceMode.Impulse);
        Debug.Log("Disparo");

    }

}
