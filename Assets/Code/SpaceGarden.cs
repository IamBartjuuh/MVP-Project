using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpaceGarden : MonoBehaviour
{
    [Header("Test data")]
    //public User user;
    //public Environment2D environment2D;
    //public Object2D object2D;

    [Header("Dependencies")]
    public UserApiClient userApiClient;
    public Environment2DApiClient enviroment2DApiClient;
    public Object2DApiClient object2DApiClient;

    [Header("Login/Register")]
    public MenuSwitcher menuSwitcher;
    public LoginHandler loginHandler;
    public bool userLoggedIn = false;

    [Header("Enviroment")]
    public EnvironmentHandler environmentHandler;
    public string CurrentEnviromentId;
    public static SpaceGarden instance { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // hier controleren we of er al een instantie is van deze singleton
        // als dit zo is dan hoeven we geen nieuwe aan te maken en verwijderen we deze
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public void FindAllScripts()
    {
        menuSwitcher = GameObject.FindGameObjectWithTag("Handlers").GetComponent<MenuSwitcher>();
        loginHandler = GameObject.FindGameObjectWithTag("Handlers").GetComponent<LoginHandler>();
        environmentHandler = GameObject.FindGameObjectWithTag("Handlers").GetComponent<EnvironmentHandler>();
        Debug.Log("Trying to find all scripts");
    }

    #region Login
    public async void Register(User user)
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Register(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                loginHandler.Message.text = "Register succes! You can now login.";
                
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Register error: " + errorMessage);
                string httpcode = errorMessage.Substring(9, 3);
                switch (httpcode)
                {
                    case "400":
                        loginHandler.Error("Password requires at least: a-z, A-Z, 0-9, #-? and 10 or more characters.");
                        break;
                    case "500":
                        loginHandler.Error("Server did not respond try again later.");
                        break;
                    default:
                        loginHandler.Error("Unexpected error. Try again.");
                        break;
                }
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }
    public async void Login(User user)
    {
        IWebRequestReponse webRequestResponse = await userApiClient.Login(user);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log("Login succes!");
                userLoggedIn = true;
                // TODO: Todo handle succes scenario.
                menuSwitcher.ActivateEnviromentMan();
                loginHandler.Message.text = "";
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Login error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                string httpcode = errorMessage.Substring(9, 3);
                switch (httpcode){
                    case "401":
                        loginHandler.Error("Username / password is incorrect.");
                        break;
                    case "500":
                        loginHandler.Error("Server did not respond try again later.");
                        break;
                    default:
                        loginHandler.Error("Unexpected error. Try again.");
                        break;
                }
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion

    #region Environment

    [ContextMenu("Environment2D/Read all")]
    public async void ReadEnvironment2Ds()
    {
        IWebRequestReponse webRequestResponse = await enviroment2DApiClient.ReadEnvironment2Ds();

        switch (webRequestResponse)
        {
            case WebRequestData<List<Environment2D>> dataResponse:
                List<Environment2D> environment2Ds = dataResponse.Data;
                Debug.Log("List of environment2Ds: " + environment2Ds);
                //environment2Ds.ForEach(environment2D => Debug.Log(environment2D.id));
                environmentHandler.SetEnvironments(environment2Ds);
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Read environment2Ds error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Environment2D/Create")]
    public async void CreateEnvironment2D(Environment2D attempt)
    {
        IWebRequestReponse webRequestResponse = await enviroment2DApiClient.CreateEnvironment(attempt);

        switch (webRequestResponse)
        {
            case WebRequestData<Environment2D> dataResponse:
                // TODO: Handle succes scenario.
                environmentHandler.Message.text = "Environment created!";
                environmentHandler.Name.text = "";
                environmentHandler.Length.text = "";
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Create environment2D error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                string httpcode = errorMessage.Substring(9, 3);
                switch (httpcode)
                {
                    case "400":
                        environmentHandler.Error("Name must be 1 to 25 character long.");
                        break;
                    case "500":
                        environmentHandler.Error("Server did not respond try again later.");
                        break;
                    default:
                        environmentHandler.Error("Unexpected error. Try again.");
                        break;
                }
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Environment2D/Delete")]
    public async void DeleteEnvironment2D(string id)
    {
        IWebRequestReponse webRequestResponse = await enviroment2DApiClient.DeleteEnvironment(id);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                string responseData = dataResponse.Data;
                // TODO: Handle succes scenario.
                Debug.Log("Delete environment succes: " + responseData);
                ReadEnvironment2Ds();
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Delete environment error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    #endregion Environment

    #region Object2D

    [ContextMenu("Object2D/Read all")]
    public async void ReadObject2Ds(string environmentId, MenuPanel menuPanel)
    {
        IWebRequestReponse webRequestResponse = await object2DApiClient.ReadObject2Ds(environmentId);

        switch (webRequestResponse)
        {
            case WebRequestData<List<Object2D>> dataResponse:
                List<Object2D> object2Ds = dataResponse.Data;
                Debug.Log("List of object2Ds: " + object2Ds);
                object2Ds.ForEach(object2D => Debug.Log(object2D.id));
                object2Ds.ForEach(object2D => menuPanel.CreateGameObjectFromDataBase(object2D));
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Read object2Ds error: " + errorMessage);
                // TODO: Error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Object2D/Create")]
    public async void CreateObject2D(Object2D object2D, Instance instance)
    {
        IWebRequestReponse webRequestResponse = await object2DApiClient.CreateObject2D(object2D);

        switch (webRequestResponse)
        {
            case WebRequestData<Object2D> dataResponse:
                object2D.id = dataResponse.Data.id;
                instance.object2D.id = object2D.id;
                //Debug.Log(dataResponse.Data.id);
                // TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Create Object2D error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Object2D/Update")]
    public async void UpdateObject2D(Object2D object2D, Instance instance)
    {
        IWebRequestReponse webRequestResponse = await object2DApiClient.UpdateObject2D(object2D);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                Debug.Log(dataResponse.Data);
                //TODO: Handle succes scenario.
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Update object2D error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }

    [ContextMenu("Object2D/Delete")]
    public async void DeleteObject2D(string id, Instance instance)
    {
        IWebRequestReponse webRequestResponse = await object2DApiClient.DeleteObject2D(id);

        switch (webRequestResponse)
        {
            case WebRequestData<string> dataResponse:
                string responseData = dataResponse.Data;
                // TODO: Handle succes scenario.
                Debug.Log("Delete object2D succes!");
                instance.DestroyGameObject();
                break;
            case WebRequestError errorResponse:
                string errorMessage = errorResponse.ErrorMessage;
                Debug.Log("Delete object2D error: " + errorMessage);
                // TODO: Handle error scenario. Show the errormessage to the user.
                break;
            default:
                throw new NotImplementedException("No implementation for webRequestResponse of class: " + webRequestResponse.GetType());
        }
    }
    #endregion

}
