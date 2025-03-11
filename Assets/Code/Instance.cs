using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Instance : MonoBehaviour // IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // The prefab to instantiate
    public GeneralLogic generalLogic;
    public SpaceGarden spaceGarden;
    public bool isDragging;

    public Object2D object2D;
    void Start()
    {
        generalLogic = GameObject.FindGameObjectWithTag("GeneralLogic").GetComponent<GeneralLogic>();
        spaceGarden = GameObject.FindGameObjectWithTag("GameAPI").GetComponent<SpaceGarden>();
    }
    void OnMouseDown()
    {
        isDragging = !isDragging;
        object2D.positionX = gameObject.transform.position.x;
        object2D.positionY = gameObject.transform.position.y;
        object2D.environmentId = spaceGarden.CurrentEnviromentId;
        if (!isDragging)
        {
            if (object2D.id == "")
            {
                spaceGarden.CreateObject2D(object2D, gameObject.GetComponent<Instance>());
            }
            else
            {
                spaceGarden.UpdateObject2D(object2D, gameObject.GetComponent<Instance>());
            }
        }

        generalLogic.HideMenu(!isDragging);

    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            spaceGarden.DeleteObject2D(object2D.id, gameObject.GetComponent<Instance>());
        }
    }

    void Update()
    {

        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
        } 

    }
    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
