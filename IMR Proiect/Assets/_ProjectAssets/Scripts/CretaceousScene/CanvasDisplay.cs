using UnityEngine;

public class CanvasDisplay : MonoBehaviour
{
    public Canvas canvasToDisplay;
    public float displayDuration = 5f;

    void Start()
    {
        Invoke("HideCanvas", displayDuration);
    }

    void HideCanvas()
    {
        canvasToDisplay.enabled = false;
        canvasToDisplay.gameObject.SetActive(false);
    }
}
