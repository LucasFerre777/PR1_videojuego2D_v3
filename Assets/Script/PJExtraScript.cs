using UnityEngine;

public class PJExtraScript : MonoBehaviour
{

    GameObject HOLAMUNDO;

    GameObject Personaje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HOLAMUNDO = GameObject.Find("HOLAMUNDO");

        Personaje = GameObject.Find("Personaje");

        HOLAMUNDO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "Personaje")
        {
            HOLAMUNDO.SetActive(true);
        }
        else
        {
            HOLAMUNDO.SetActive(false);
        }
    }

     void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name == "Personaje")
        {
            HOLAMUNDO.SetActive(false);
        }
        else
        {
            HOLAMUNDO.SetActive(true);
        }
    }

        
}

