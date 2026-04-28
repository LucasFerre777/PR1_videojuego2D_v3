using UnityEngine;

public class Diamante : MonoBehaviour
{
    public int puntos = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
   

     if(col.gameObject.name == "Personaje")
        {
            GameManager.puntos += puntos;
            gameObject.GetComponent<Animator>().SetBool("obtenerDiamante", true);
            Destroy(this.gameObject, 0.9f);

            GetComponent<Collider2D>().enabled = false;
        }



    }
}
