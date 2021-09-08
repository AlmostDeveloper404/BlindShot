using UnityEngine;

[System.Serializable]
public class Sounds
{
    public string name;
    public AudioClip audioClip;

    [Range(0,1)] public float volume;
    [Range(-3,1)]public float pitch;

    public bool loop;

    [HideInInspector]public AudioSource audioSource;

}
