using UnityEngine;
using TMPro;
using UnityEditor.PackageManager;
using UnityEngine.SceneManagement;

public class LoginHandler : MonoBehaviour
{
    public TMP_InputField Email;
    public TMP_InputField Password;
    public TextMeshProUGUI Message;

    public SpaceGarden spaceGarden;
    void Start()
    {
        Message.text = "";
    }
    public void test()
    {
        SceneManager.LoadScene(1);
    }
    public void Error(string error)
    {
        Message.color = Color.red;
        Message.text = error;
    }
    public void Login(bool login)
    {
        var attempt = new User()
        {
            email = Email.text,
            password = Password.text
        };
        if (login)
        {
            Debug.Log($"Sending attempt for login with: {attempt.email}, {attempt.password}");
            spaceGarden.Login(attempt);
            Message.color = Color.green;
            Message.text = "Waiting for response...";
        }
        else
        {
            Debug.Log($"Sending attempt for register with: {attempt.email}, {attempt.password}");
            spaceGarden.Register(attempt);
            Message.color = Color.green;
            Message.text = "Waiting for response...";
        }
    }
}
