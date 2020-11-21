using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    private bool _isPlaying = true;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
 
    public void PlayMusic()
    {
        if (_isPlaying) return;
        _audioSource.UnPause();
        _isPlaying = true;
    }
 
    public void StopMusic()
    {
        _audioSource.Pause();
        _isPlaying = false;
    }

    public void ToggleMusic()
    {
        if (_isPlaying)
        {
            StopMusic();
        }
        else
        {
            PlayMusic();
        }
    }
}
