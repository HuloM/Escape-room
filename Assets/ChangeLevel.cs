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
    
    // Start is called before the first frame update
    void Start()
    {
        _gsm = FindObjectOfType<GameStateMachine>();
        _player = FindObjectOfType<Player>();
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
            {
                SceneManager.LoadScene("Scenes/Menu");
            }
        }
    }
}
