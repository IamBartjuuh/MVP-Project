using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GeneralLogic : MonoBehaviour
{
    public GameObject SelectionMenu;
    bool active = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    active = !active;
        //    HideMenu(active);
        //}
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider)
            {
                active = !active;
                HideMenu(active);
            }
           
        }
    }
    public void HideMenu(bool show)
    {
        active = show;
        SelectionMenu.SetActive(show);
    }

    public void Reset()
    {
        SceneManager.LoadScene("2D Enviroment Builder");
    }
}
