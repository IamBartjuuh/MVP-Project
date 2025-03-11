using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnvironmentHandler : MonoBehaviour
{
    public TMP_InputField Name;
    public TMP_InputField Length;
    public TextMeshProUGUI Message;

    public SpaceGarden spaceGarden;
    public SceneSwitcher sceneSwitcher; 

    public List<UnityEngine.UI.Button> Environments = new();
    public List<UnityEngine.UI.Button> DeleteEnv = new();

    private List<Environment2D> UserEnviroments;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Message.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnvironments(List<Environment2D> enviroments)
    {
        UserEnviroments = enviroments;
        Debug.Log(enviroments.Count);
        for (int i = 0; i < Environments.Count; i++)
        {
            if(enviroments.Count > i)
            {
                Environments[i].GetComponentInChildren<TextMeshProUGUI>().text = enviroments[i].name;
                Debug.Log("Setting up button for enviroment: " + enviroments[i].id);
                Environments[i].name = enviroments[i].id;
                var id = enviroments[i].id;
                Environments[i].onClick.AddListener(() => OpenEnviroment(id));
                DeleteEnv[i].onClick.AddListener(() => DeleteEnviroment(id));
            } else
            {
                Environments[i].GetComponentInChildren<TextMeshProUGUI>().text = "Empty";
                Environments[i].name = "Empty";
            }

        }
    }

    public void DeleteEnviroment(string id)
    {
        Debug.Log("Deleting enviroment: " + id);
        spaceGarden.DeleteEnvironment2D(id);
    }

    public void OpenEnviroment(string id)
    {
        Debug.Log("Opening enviroment: " + id);
        spaceGarden.CurrentEnviromentId = id;
        sceneSwitcher.SwitchScene("2D Enviroment Builder");
    }

    public void Create()
    {
        var attempt = new Environment2D()
        {
            name = Name.text,
            ownerUserId = "",
            maxLength = int.Parse(Length.text)
        };
        spaceGarden.CreateEnvironment2D(attempt);
        Message.color = Color.green;
        Message.text = "Waiting for response...";
    }
    public void Error(string error)
    {
        Message.color = Color.red;
        Message.text = error;
    }
}
