using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioClip clipMenu;
    public AudioClip bandaSonora;
    public AudioClip monedas;

    void Awake()
    {
        if (Instance != null && Instance != this.gameObject)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<AudioSource>().clip = bandaSonora;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update() { }

    public void SonarBoton()
    {
        GetComponent<AudioSource>().PlayOneShot(clipMenu);
    }
}
