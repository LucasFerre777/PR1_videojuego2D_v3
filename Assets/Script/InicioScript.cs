using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class InicioScript : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelSetting;

    public GameObject AudioManagerObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelSetting.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }

    public void showSettings()
    {
        panelSetting.SetActive(true);

        panelInicio.SetActive(false);

        AudioManagerObj.GetComponent<AudioManager>().SonarBoton();
    }

    public void exitSettings()
    {
        panelSetting.SetActive(false);

        panelInicio.SetActive(true);

        AudioManagerObj.GetComponent<AudioManager>().SonarBoton();
    }

    public void exitGame()
    {
        Application.Quit();

        AudioManagerObj.GetComponent<AudioManager>().SonarBoton();
    }

    public void Inicio()
    {
        SceneManager.LoadScene("juego");

        AudioManagerObj.GetComponent<AudioManager>().SonarBoton();
    }

     public void escapeInicio()
    {
        SceneManager.LoadScene("Inicio");

        AudioManagerObj.GetComponent<AudioManager>().SonarBoton();
    }
}
