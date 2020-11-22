using TMPro;
using UnityEngine;

public static class Interact
{
    public static void InteractWithObject(
        GameObject uiBoard, Player playergameObject, 
        GameObject interactionObject, TMP_Text tmpText)
    {
        var dist = Vector3.Distance(
            interactionObject.transform.position,
            playergameObject.transform.position);

        if (PlayerInput.Instance.SelectionPressed)
            PuzzleIsActive(true, tmpText, uiBoard, playergameObject);
        else if (PlayerInput.Instance.DeSelectionPressed || dist > 3)
            PuzzleIsActive(false, tmpText, uiBoard, playergameObject);
    }
    

    private static void PuzzleIsActive(bool isActive, TMP_Text tmpText, GameObject uiBoard, Player playergameObject)
    {
        Cursor.lockState = isActive? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = isActive;
        tmpText.enabled = isActive;
        uiBoard.SetActive(isActive);
        playergameObject.Frozen = isActive;
    }
}