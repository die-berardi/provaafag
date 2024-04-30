using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;


public class PlayfabManager : MonoBehaviour
{

    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;
    // [SerializeField]
    public  Button loginBtn;
    public  Button registerBtn;

    // Start is called before the first frame update
    void Start()
    {
        registerBtn.onClick.AddListener(() => {
            RegisterButton();
        });
        loginBtn.onClick.AddListener(() => {
            LoginButton();
        });
    }

    void RegisterButton () {
        if(passwordInput.text.Length < 6 )  {
            messageText.text = "Password too short!";
            return;
        }
        var request = new RegisterPlayFabUserRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false 
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnSuccessRegister, OnError );

    }
    
    void OnSuccessRegister (RegisterPlayFabUserResult  result ) {
        messageText.text = "Registered and logged in!";
        Debug.Log("successfully registered ");

    }

    void LoginButton () {
        var request = new LoginWithEmailAddressRequest {
            Email = emailInput.text,
            Password = passwordInput.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccessLogin, OnError );

    }


    // void Login () {
    //     var request = new LoginWithCustomIDRequest {
    //         CustomId = SystemInfo.deviceUniqueIdentifier, 
    //         CreateAccount = true
    //     };

    //     PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError );
    // }
   

    void OnSuccessLogin (LoginResult result ) {
        Debug.Log("successfull logged in ");
        messageText.text = "Logged in!";

    }

    void OnError (PlayFabError error) {
        Debug.Log("Error in login  ");
        Debug.Log(error.GenerateErrorReport() );
        messageText.text = error.ErrorMessage;
    }
   
}
