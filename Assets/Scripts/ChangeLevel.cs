using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour
{
    private GameStateMachine _gsm;
    private Player _player;
    private Slider _completepuzzleslider;
    public static ChangeLevel _instance;
    public static bool changeLevelToMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        _gsm = FindObjectOfType<GameStateMachine>();
        _player = FindObjectOfType<Player>();
        changeLevelToMenu = false;
        _completepuzzleslider = GameObject.FindGameObjectWithTag("CompletePuzzle").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_completepuzzleslider.value == _completepuzzleslider.maxValue)
            _gsm.LevelTwoAccessGranted(true);
        if (_gsm._saveData.levelTwoAccess)
        {
            gameObject.GetComponent<Outline>().OutlineColor = Color.green;
            var dist = Vector3.Distance(transform.position, _player.transform.position);
            if (dist < 2 && PlayerInput.Instance.SelectionPressed)
                changeLevelToMenu = true;
            else
                changeLevelToMenu = false;
        }
    }
}
