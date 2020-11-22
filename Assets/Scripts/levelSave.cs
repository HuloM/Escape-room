using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelSave : MonoBehaviour
{
    [SerializeField] private Button _levelTwoButton;

    public bool Access;
    // Update is called once per frame
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        Access = FindObjectOfType<GameStateMachine>()._saveData.levelTwoAccess;
        if (FindObjectOfType<GameStateMachine>()._saveData.levelTwoAccess)
            _levelTwoButton.interactable = true;
        else
            _levelTwoButton.interactable = false;
    }
}
