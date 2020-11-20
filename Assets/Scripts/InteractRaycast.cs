using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class InteractRaycast : MonoBehaviour
{
    private RaycastHit hit;

    private Outline _outline;

    [SerializeField] private TMP_Text _interactionText;
    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position,
            Camera.main.transform.forward,
            out hit,
            3f))
        {
            if (hit.collider.gameObject.CompareTag("Interactable"))
            {
                _outline = hit.collider.gameObject.GetComponent<Outline>();
                _outline.enabled = true;
                if (_interactionText != null)
                    _interactionText.enabled = true;
            }
        }
        else if (_outline != null)
        {
            _outline.enabled = false;
            if (_interactionText != null)
                _interactionText.enabled = false;
        }
        

    }
}
