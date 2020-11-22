using System;
using UnityEngine;

public class ComputerLights : MonoBehaviour
{
    private Item flashdrive;
    private Player player;
    [SerializeField] private GameObject lights;

    public bool hasFlashdrive => flashdrive != null;

    public void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void Update()
    {
        var dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
        if (player.GetComponent<Inventory>().GetItemInSlot(0) != null && PlayerInput.Instance.SelectionPressed && dist < 2)
        {
            flashdrive = player.GetComponent<Inventory>().GetItemInSlot(0);
            lights.SetActive(true);
        }
            
    }
}