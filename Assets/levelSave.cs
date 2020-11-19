using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSave : MonoBehaviour
{
    [SerializeField] private Button _levelTwoButton;
    
    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameStateMachine>()._saveData.levelTwoAccess)
            _levelTwoButton.interactable = true;
        else
            _levelTwoButton.interactable = false;     
            
    }
}
