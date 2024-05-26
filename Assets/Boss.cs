using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

   [SerializeField] int vida;
   [SerializeField] Transform cañonUno;
   [SerializeField] Transform cañonDos;
    [SerializeField] Transform cañonTres;
    [SerializeField] GameObject proyectil;
    [SerializeField] GameObject misilObject;
    [SerializeField] float forceShot;
   [SerializeField] float velocidad;
   [SerializeField] bool bossActive;
    [SerializeField] bool misilAble;
    [SerializeField] Text bossDefetedText;
    [SerializeField] Text pressRToRestart;
    bool restartAble;
    // Start is called before the first frame update
    void Start()
    {
        bossActive = true;
        misilAble = true;
        restartAble = false;
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
        if (misilAble)
        {
            misilAble = false;
           StartCoroutine(Misil());
        }
        if (Input.GetKeyDown(KeyCode.R) && restartAble)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Proyectil"))
        {
            other.gameObject.SetActive(false);
            vida--;
            if(vida <= 0)
            {
                this.gameObject.SetActive(false);
                Defeat();
                restartAble = true;
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
    IEnumerator Misil()
    {
        yield return new WaitForSeconds(Random.Range(2, 4));
        Instantiate(misilObject, new Vector3(cañonTres.position.x, cañonTres.position.y, cañonTres.position.z), Quaternion.identity);
        misilAble = true;
    }
    void Defeat()
    {
        bossDefetedText.text = "Boss Killed";
        pressRToRestart.text = "Press R to restart";
        restartAble = true;
        Time.timeScale = 0f;
    }
}
