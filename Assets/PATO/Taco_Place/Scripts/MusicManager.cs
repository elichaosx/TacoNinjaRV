using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _musicaEscena;

    void Start()
    {
        _audioSource.clip = _musicaEscena;

        _audioSource.Play();
    }
}
