using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class InteractRaycast : MonoBehaviour
{
    private RaycastHit hit;

    private Outline _outline;
    // Update is called once per frame
    void Update()
    {
        Physics.Raycast( Camera.main.transform.position, 
            Camera.main.transform.forward, 
            out hit, 
            10f );
        if (hit.collider.gameObject.CompareTag("Interactable"))
        {
            _outline = hit.collider.gameObject.GetComponent<Outline>();
            _outline.enabled = true;
        }
        else if (_outline != null)
            _outline.enabled = false;
        

    }
}
