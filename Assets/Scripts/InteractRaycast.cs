using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractRaycast : MonoBehaviour
{
    private RaycastHit hit;
    
    // Update is called once per frame
    void Update()
    {
        Physics.Raycast( Camera.main.ScreenPointToRay( Input.mousePosition ), out hit, 1000f );
        if (hit.collider.gameObject.CompareTag("Interactable"))
        {
            var outline = hit.collider.gameObject.AddComponent<Outline>();

            outline.OutlineMode = Outline.Mode.OutlineAll;
            outline.OutlineColor = Color.yellow;
            outline.OutlineWidth = 5f;
        }
    }
}
