using UnityEngine;

public class MenuSwitcher : MonoBehaviour
{
    public GameObject LR_Menu;
    public GameObject Enviroment_Manager;
    public GameObject Create_Enviroment;

    public SpaceGarden SpaceGarden;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SpaceGarden.userLoggedIn)
        {
            ActivateEnviromentMan();
        }
        else
        {
            ActivateLRmenu();
        }
    }

    public void ActivateEnviromentMan()
    {
        Create_Enviroment.SetActive(false);
        LR_Menu.SetActive(false);

        Enviroment_Manager.SetActive(true);
        SpaceGarden.ReadEnvironment2Ds();
    }

    public void ActivateCreateEnv()
    {
        LR_Menu.SetActive(false);
        Enviroment_Manager.SetActive(false);

        Create_Enviroment.SetActive(true);
    }

    public void ActivateLRmenu()
    {
        Enviroment_Manager.SetActive(false);
        Create_Enviroment.SetActive(false);

        LR_Menu.SetActive(true);
    }
}
