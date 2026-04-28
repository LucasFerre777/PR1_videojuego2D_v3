
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour
{
    public float velocidad = 0.5f;
    public float impulsoSalto = 5;
    public GameObject senyal;
    GameObject respawn;

    bool puedoSaltar = false;

    Rigidbody2D rb;

    Animator controlAnimacion;

    public Vector3 inicioPersonaje = new Vector3(1,1,0);

    public bool direcBalaDcha = true;

    public string direccionPersonaje = "quieto";

    bool estoyAzul = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        this.transform.position = inicioPersonaje;

        rb = GetComponent<Rigidbody2D>();

        senyal = GameObject.Find("sign");

        senyal.SetActive(false);

        controlAnimacion = GetComponent<Animator>();

        respawn = GameObject.Find("respawn");

    }

    // Update is called once per frame
    void Update()
    {

        //caminar izquierda - derecha
        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        this.transform.Translate(moveInput.x*velocidad*Time.deltaTime, 0 , 0);


        //Flipear al caminar


        if(moveInput.x < 0)
        {
            direcBalaDcha = false;
            this.GetComponent<SpriteRenderer>().flipX = true;
            direccionPersonaje = "izq";
        }
        else if(moveInput.x > 0)
        {
            direcBalaDcha = true;
            this.GetComponent<SpriteRenderer>().flipX = false;
            direccionPersonaje = "dcha";
        }
        else
        {
            direccionPersonaje = "quieto";
        }

        //animacion caminado

        if(moveInput.x != 0)
        {
            controlAnimacion.SetBool("activaCamina", true);
        }
        else
        {
            controlAnimacion.SetBool("activaCamina", false);
        }


        //Esto para que al saltar determine donde está el suelo desde el personaje con un rayo


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        Debug.DrawRay(transform.position, Vector2.down*0.5f, Color.red);

        if(hit.collider == true)
        {
            puedoSaltar = true;
            controlAnimacion.SetBool("activaSalto", false);
        }
        else
        {
            puedoSaltar = false;
            controlAnimacion.SetBool("activaSalto", true);
        }

        Debug.Log(puedoSaltar);

        //Saltar

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();

        if(salto == true && puedoSaltar == true)
        {
            rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);
        }

        
        //Cualquier cambio de estado durante el salto:

        if(puedoSaltar == true)
        {
            //this.GetComponent<SpriteRenderer>().color = Color.white;
            senyal.SetActive(false);

        }
        else
        {
            //this.GetComponent<SpriteRenderer>().color = Color.red;
            senyal.SetActive(true);

        }

        if (transform.position.y <= -30)
        {
            Muerte();
        }

        if (GameManager.vidas <= 0)
        {
        SceneManager.LoadScene("GameOver");
        }

    }

    // para hacer que un objeto cambie de estado cuando lo toca el pj

    /*
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Colision con: " + col.gameObject.name);

        if(col.gameObject.name == "ladrillo")
        {
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }

    }
    */
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger con: " + col.gameObject.name);
        //muerte por pincho

        if(col.gameObject.name == "pincho")
        {
            
            col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            Muerte();
        }

        //checkpoint

        if(col.gameObject.name == "checkpoint")
        {
            respawn.transform.position = col.transform.position;
        }

    }

    
    
    

    public void Muerte()
    {
        GameManager.vidas -= 1;
        transform.position = respawn.transform.position;

    }
    

    //esto es para el ui canvas

    public void CambioColor()
    {
        if (estoyAzul)
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
            estoyAzul = false;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            estoyAzul = true;
        }
        
    }


}

