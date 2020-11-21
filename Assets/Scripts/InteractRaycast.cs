using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class InteractRaycast : MonoBehaviour
{
    [SerializeField] private TMP_Text _interactionText;
    [SerializeField] private float _maxRayDist = 1f;
    
    private RaycastHit hit;
    private Outline _outline;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position,
            Camera.main.transform.forward,
            out hit,
            _maxRayDist))
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
