using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip musicaEscena1;
    public AudioClip musicaEscena2;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        CambiarMusica();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += AlCargarEscena;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= AlCargarEscena;
    }

    private void AlCargarEscena(Scene escena, LoadSceneMode modo)
    {
        CambiarMusica();
    }

    private void CambiarMusica()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            audioSource.clip = musicaEscena1;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            audioSource.clip = musicaEscena2;
        }

        audioSource.Play();
    }
}