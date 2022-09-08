using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

using TMPro;   // for text mesh pro

public class Registration : MonoBehaviour
{
    public TMP_InputField UsernameField;
    public TMP_InputField PasswordField;
    public TMP_InputField FirstnameField;
    public TMP_InputField LastnameField;
    readonly string postURL = "http://localhost/UnityBackendTutorial/register.php";

    public Button submitButton;
    public Button backButton;

    public void GoBack()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("Username", UsernameField.text));
        wwwForm.Add(new MultipartFormDataSection("Password", PasswordField.text));
        wwwForm.Add(new MultipartFormDataSection("Firstname", FirstnameField.text));
        wwwForm.Add(new MultipartFormDataSection("Lastname", LastnameField.text));
        UnityWebRequest www = UnityWebRequest.Post(postURL, wwwForm);
        yield return www.SendWebRequest();
            string text = www.downloadHandler.text;
            Debug.Log(text);
        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);

        }
        else
        {
            Debug.Log("user creation success!");
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }
    }


    public void VerifyInputs()
    {
        submitButton.interactable = (UsernameField.text.Length >= 1 && PasswordField.text.Length >= 1 && FirstnameField.text.Length >= 1 && LastnameField.text.Length >= 1);
    }




}
