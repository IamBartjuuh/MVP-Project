using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour // IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // The prefab to instantiate
    public bool isDragging;
    public MenuPanel menuPanel;
    void OnMouseDown()
    {
        isDragging = !isDragging;
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        }
    }
}
