using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayButton : MonoBehaviour
{
    public static string LevelToLoad;

    [SerializeField] private string _levelName;

    private void Awake()
    {
        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot((AudioClip) Resources.Load(path: "Assets/Audio/button_click.wav"));
        GetComponent<Button>().onClick.AddListener(() => LevelToLoad = _levelName);
    }
}