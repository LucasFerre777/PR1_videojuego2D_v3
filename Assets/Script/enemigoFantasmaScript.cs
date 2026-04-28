using UnityEngine;
using UnityEngine.UIElements;

public class enemigoFantasmaScript : MonoBehaviour
{

    //estados de enemigo: patrulla, Ataque

    string estado = "patrulla";

    public float distanciaPatrulla = 2.0f;

    public float velocidadPatrulla = 0.1f;

    Vector3 posicionBase;
    public Vector3 posicionLimitIzq, posicionLimitDcha;

    bool dirPatrullaDcha = true;

    //Ataque

    public float distanciaAtaque = 2.0f;

    public float distanciaEvitar = 5.0f;

    GameObject Personaje;

    public float velocidadAtaque = 0.1f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posicionBase = transform.position;
        posicionLimitIzq = new Vector3 (posicionBase.x - distanciaPatrulla, posicionBase.y, 0);
        posicionLimitDcha = new Vector3 (posicionBase.x + distanciaPatrulla, posicionBase.y, 0);

        Personaje = GameObject.FindWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(transform.position, Personaje.transform.position);

        if (distancia <= distanciaAtaque)
        {
            estado = "ataque";
        }
        if (distancia >= distanciaEvitar)
        {
            estado = "patrulla";
        }






        if(estado == "patrulla")
        {
            
            if(transform.position.x >= posicionLimitDcha.x)
            {
                dirPatrullaDcha = false;
            }
            if(transform.position.x <= posicionLimitIzq.x)
            {
                dirPatrullaDcha = true;
            }
            

            if(dirPatrullaDcha == true)
            {
                transform.Translate(velocidadPatrulla*Time.deltaTime, 0, 0);
                this.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                transform.Translate(velocidadPatrulla*-1*Time.deltaTime, 0, 0);
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if(estado == "ataque")
        {
            transform.position = Vector3.MoveTowards(transform.position, Personaje.transform.position, velocidadAtaque*Time.deltaTime);
        }


    }

    void OnTriggerEnter2D(Collider2D col)
    {
   
        Debug.Log(col.gameObject.name);

    if(col.gameObject.tag == "Player")
        {
            
            Personaje.GetComponent<Personaje>().Muerte();
        }

     if(col.gameObject.name == "bala")
        {
            GameManager.puntos += 20;
            
            Destroy(this.gameObject, 0.3f); //se pueden poner vidas al fantasma y hacer que se destruya solo cuando tenga 0 vidas
            Destroy(col.gameObject);
        }



    }


}
