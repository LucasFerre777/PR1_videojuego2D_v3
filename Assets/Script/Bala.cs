using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{

    public GameObject disparo; 

    GameObject Personaje;

    bool direccionPersonaje;

    public float velocidadBala = 0.05f;
    
    float balaCreada;

    public float tiempoHastaDestroy = 5.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Personaje = GameObject.Find("Personaje");

        direccionPersonaje = Personaje.GetComponent<Personaje>().direcBalaDcha;

        balaCreada = Time.time;



    }

    // Update is called once per frame
    void Update()
    {
       
       
       
        if (direccionPersonaje)
        {
            disparo.transform.Translate(velocidadBala*Time.deltaTime,0,0);
            transform.Rotate(0,0,0.5f);
        }
        else
        {
            disparo.transform.Translate(velocidadBala*-1*Time.deltaTime,0,0);
            transform.Rotate(0,0,-0.5f);
        }

        //Destruccion bala

        if (Time.time >= balaCreada + tiempoHastaDestroy)
        {
            Destroy(disparo);
        }

       


    }
}
