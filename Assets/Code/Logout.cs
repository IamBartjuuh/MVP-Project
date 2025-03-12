using UnityEngine;

public class Logout : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Out()
    {
        Debug.Log(Equals("Logout"));
        Application.Quit();
    }
}
