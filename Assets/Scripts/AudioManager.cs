using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
     
    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        
        DontDestroyOnLoad(gameObject);
        foreach (Sounds sound in sounds)
        {
            sound.audioSource= gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;

            sound.audioSource.loop = sound.loop;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
        }
        
    }

    private void Start()
    {
        PlaySound("BackGroundMusic");
    }

    public void PlaySound(string name)
    {
        Sounds s= Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: "+ name+" isn't found!");
            return;
        }
        s.audioSource.Play();
        
    }
}
