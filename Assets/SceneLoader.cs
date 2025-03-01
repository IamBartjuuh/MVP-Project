using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        //spaceGarden.ScriptsMenuScene(activeScene);
    }
}
