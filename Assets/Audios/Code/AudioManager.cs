using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio")]
    [SerializeField]
    private List<AudioClip> _sfxList = new List<AudioClip>();

    [SerializeField]
    private List<AudioClip> _musicList = new List<AudioClip>();

    [Header("Audio Mixer")]
    [SerializeField]
    private AudioMixerGroup _sfxMixerGroup;

    [SerializeField]
    private AudioMixerGroup _musicMixerGroup;

    private GameObject _soundsContainer;

    private List<AudioSource> _audioSources = new List<AudioSource>();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        _soundsContainer = new GameObject("SoundsContainer");
        _soundsContainer.transform.SetParent(transform);

        _audioSources = new List<AudioSource>();
    }


    private AudioSource FindAudioSource(AudioClip clip)
    {
        return _audioSources.Find(x => x.clip == clip);
    }


    public void PlaySound(int soundIndex, bool loop = false, float volume = 1f, float pitch = 1f)
    {
        if (soundIndex < 0 || soundIndex >= _sfxList.Count)
        {
            Debug.LogWarning("SFX index out of range: " + soundIndex);
            return;
        }

        AudioClip clip = _sfxList[soundIndex];

        if (clip == null)
        {
            Debug.LogWarning("SFX at index " + soundIndex + " is null!");
            return;
        }

        AudioSource audioSource = FindAudioSource(clip);

        if (audioSource == null)
        {
            GameObject go = new GameObject("AS : " + clip.name);

            audioSource = go.AddComponent<AudioSource>();

            audioSource.transform.SetParent(_soundsContainer.transform);

            audioSource.clip = clip;
            audioSource.loop = loop;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.outputAudioMixerGroup = _sfxMixerGroup;

            _audioSources.Add(audioSource);
        }
        else
        {
            audioSource.loop = loop;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
        }

        audioSource.Play();
    }


    public void StopSound(int soundIndex)
    {
        if (soundIndex < 0 || soundIndex >= _sfxList.Count)
        {
            Debug.LogWarning("SFX index out of range: " + soundIndex);
            return;
        }

        AudioClip clip = _sfxList[soundIndex];

        AudioSource audioSource = FindAudioSource(clip);

        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }


    public void PlayMusic(int musicIndex, bool loop = true, float volume = 1f)
    {
        if (musicIndex < 0 || musicIndex >= _musicList.Count)
        {
            Debug.LogWarning("Music index out of range: " + musicIndex);
            return;
        }

        AudioClip clip = _musicList[musicIndex];

        if (clip == null)
        {
            Debug.LogWarning("Music at index " + musicIndex + " is null!");
            return;
        }

        AudioSource audioSource = FindAudioSource(clip);

        if (audioSource == null)
        {
            GameObject go = new GameObject("Music : " + clip.name);

            audioSource = go.AddComponent<AudioSource>();

            audioSource.transform.SetParent(_soundsContainer.transform);

            audioSource.clip = clip;
            audioSource.loop = loop;
            audioSource.volume = volume;
            audioSource.outputAudioMixerGroup = _musicMixerGroup;

            _audioSources.Add(audioSource);
        }

        audioSource.Play();
    }


    public void StopMusic(int musicIndex)
    {
        if (musicIndex < 0 || musicIndex >= _musicList.Count)
        {
            Debug.LogWarning("Music index out of range: " + musicIndex);
            return;
        }

        AudioClip clip = _musicList[musicIndex];

        AudioSource audioSource = FindAudioSource(clip);

        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }


    public void StopAllSounds()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.Stop();
        }
    }


    public void SetSFXVolume(float volume)
    {
        if (_sfxMixerGroup == null)
        {
            return;
        }

        _sfxMixerGroup.audioMixer.SetFloat("SFXVolume", Mathf.Lerp(-80f, 0f, volume));
    }


    public void SetMusicVolume(float volume)
    {
        if (_musicMixerGroup == null)
        {
            return;
        }

        _musicMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80f, 0f, volume));
    }
}