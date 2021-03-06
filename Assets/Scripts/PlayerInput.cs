using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPlayerInput
{
    public static IPlayerInput Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    public event Action MoveModeTogglePressed;
    public float Vertical => Input.GetAxis("Vertical");
    public float Horizontal => Input.GetAxis("Horizontal");
    public float MouseX => Input.GetAxis("Mouse X");

    public event Action<int> HotkeyPressed;

    private void Update() => Tick();

    public void Tick()
    {
        if (MoveModeTogglePressed != null && Input.GetKeyDown(KeyCode.Minus))
            MoveModeTogglePressed();
        
        if (HotkeyPressed == null)
            return;
        
        for (int i = 0; i < 9; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
                HotkeyPressed(i);
        }
    }

    public bool PausePressed => Input.GetKeyDown(KeyCode.Escape);
    public bool SelectionPressed => Input.GetKeyDown(KeyCode.E);
    public bool DeSelectionPressed => Input.GetKeyDown(KeyCode.B);
    public Vector2 MousePosition => Input.mousePosition;
    public bool GetKeyDown(KeyCode keyCode) => Input.GetKeyDown(keyCode);
}