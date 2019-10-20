using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sence : MonoBehaviour
{
    public void ChangeScence()
    {
        SceneManager.LoadScene("InGame");
        Application.Quit();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
