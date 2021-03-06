﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateMachine : MonoBehaviour
{
    public static event Action<IState> OnGameStateChanged;

    private static GameStateMachine _instance;
    
    private StateMachine _stateMachine;
    public Type CurrentStateType => _stateMachine.CurrentState.GetType();

    public SaveData _saveData;
    private SaveDataSerializer _saveDataSerializer;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            Debug.Log("Destroyed GameStateMachine On Awake");
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
        
        _stateMachine = new StateMachine();
        SetUpSaveData();
        _stateMachine.OnStateChanged += state => OnGameStateChanged?.Invoke(state);

        var menu = new Menu();
        var loading = new LoadLevel();
        var play = new Play();
        var pause = new Pause();
        
        _stateMachine.SetState(menu);
        
        _stateMachine.AddTransition(menu, loading, () => PlayButton.LevelToLoad != null);
        _stateMachine.AddTransition(loading, play, loading.Finished);
        _stateMachine.AddTransition(play, pause, () => PlayerInput.Instance.PausePressed);
        _stateMachine.AddTransition(pause, play, () => PlayerInput.Instance.PausePressed);
        _stateMachine.AddTransition(pause, menu, () => RestartButton.Pressed);
        _stateMachine.AddTransition(play,menu, () => ChangeLevel.changeLevelToMenu);
        _stateMachine.AddTransition(play,menu, () => Countdown.outOfTime);
    }


    private void Update()
    {
        _stateMachine.Tick();
    }

    private void OnDestroy()
    {
        _stateMachine?.SetState(null);
        Debug.Log("Destroyed GameStateMachine");
    }
    
    private void SetUpSaveData()
    {
        _saveDataSerializer = new SaveDataSerializer();
        _saveData = _saveDataSerializer.Load();

        if (_saveData == null)
        {
            _saveData = new SaveData();
            _saveData.levelTwoAccess = false;
            _saveDataSerializer.save(_saveData);
        }
    }

    public void LevelTwoAccessGranted(bool granted)
    {
        _saveData.levelTwoAccess = granted;

        _saveDataSerializer.save(_saveData);
    }

    public void reset()
    {
        LevelTwoAccessGranted(false);
    }
}

public class Menu : IState
{
    public void Tick()
    {
    }

    public void OnEnter()
    {
        PlayButton.LevelToLoad = null;
        SceneManager.LoadSceneAsync("Menu");
    }

    public void OnExit()
    {
    }
}

public class Play : IState
{
    public void Tick()
    {
    }

    public void OnEnter()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void OnExit()
    {
    }
}

public class LoadLevel : IState
{
    public bool Finished() => _operations.TrueForAll(t => t.isDone);
    
    private List<AsyncOperation> _operations = new List<AsyncOperation>();
    
    public void Tick()
    {
    }

    public void OnEnter()
    {
        _operations.Add(SceneManager.LoadSceneAsync(PlayButton.LevelToLoad));
        _operations.Add(SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive));
    }

    public void OnExit()
    {
        _operations.Clear();
    }
}

public class Pause : IState
{
    public static bool Active { get; private set; }
    
    public void Tick()
    {
    }

    public void OnEnter()
    {
        Active = true;
        ToggleCursor(true);
        Time.timeScale = 0f;
    }

    private void ToggleCursor(bool isActive)
    {
        Cursor.lockState = isActive ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isActive;
    }

    public void OnExit()
    {
        Active = false;
        ToggleCursor(false);
        Time.timeScale = 1f;
    }
}
