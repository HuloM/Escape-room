﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetButton : MonoBehaviour
{
    
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => FindObjectOfType<GameStateMachine>().LevelTwoAccessGranted(false));
    }
}
