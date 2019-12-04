using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f, 1f)] public float volume = 0.7f;
    [Range(0.1f, 3f)] public float pitch = 1f;
    public bool loop; 

    private AudioSource source;

    public AudioSource GetAudioSource()
    {
        return source;
    }

    public void SetAudioSource(AudioSource _source)
    {
        source = _source;
    }
}
