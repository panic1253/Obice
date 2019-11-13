using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSelectControl : MonoBehaviour
{
    public AudioSource buttonSound;

    public void UI_buttonSelect(int num)
    {
        buttonSound.Play();
        switch (num)
        {
            case 0:
                SceneManager.LoadScene("MainGameScene");
                break;
            case 1:
                Application.Quit();
                break;
        }
    }
}
