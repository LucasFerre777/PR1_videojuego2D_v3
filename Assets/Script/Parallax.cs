using UnityEngine;

public class Parallax : MonoBehaviour
{

    public float velocidadParallax = 0.5f;
    GameObject Personaje;
    GameObject Camara;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camara = GameObject.Find ("Main Camera");
        Personaje = GameObject.Find ("Personaje");
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.position = new Vector3 (Camara.transform.position.x*velocidadParallax , 0 , 5.0f );
    }
}
