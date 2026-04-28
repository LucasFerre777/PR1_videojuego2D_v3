
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static int vidas = 3;

    public static int puntos = 0;

    GameObject TextCoin;

    GameObject TextVidas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        TextVidas = GameObject.Find("TextVidas");
        vidas = 3;
        TextCoin = GameObject.Find("TextCoin");
        puntos = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //vidas

        Debug.Log("Vidas: " + vidas);

        TextVidas.GetComponent<TextMeshProUGUI>().text = vidas.ToString();



        //puntos

        Debug.Log("Puntos: " + puntos);

        TextCoin.GetComponent<TextMeshProUGUI>().text = puntos.ToString();


    }
}
