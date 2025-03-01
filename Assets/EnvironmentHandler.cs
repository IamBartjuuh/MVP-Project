using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class EnvironmentHandler : MonoBehaviour
{
    public TMP_InputField Name;
    public TMP_InputField Length;
    public SpaceGarden spaceGarden;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create()
    {
        var attempt = new Environment2D()
        {
            name = Name.text,
            maxLength = int.Parse(Length.text)
        };
        spaceGarden.CreateEnvironment2D(attempt);
    }
}
