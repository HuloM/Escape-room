using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
 
    public void PlayMusic()
    {
        _audioSource.UnPause();
    }
 
    public void StopMusic()
    {
        _audioSource.Pause();
    }

    public void ToggelMusic()
    {
        if(_audioSource.isPlaying)
            StopMusic();
        else 
            PlayMusic();
    }
}
