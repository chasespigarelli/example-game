using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{
    public Button nextButton;

    public void Start()
    {

    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(2);
    }
}