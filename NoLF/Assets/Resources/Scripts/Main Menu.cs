using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] public GameObject[] menuObjects;
    [SerializeField] public GameObject[] infoObjects;

    public void PlayGame()
    {
        SceneManager.LoadScene("UISceneCopy");
    }

    public void showInfo() {
        for (int i = 0; i < menuObjects.Length; i++) {
            menuObjects[i].SetActive(false);
        }
        for (int i = 0; i < infoObjects.Length; i++) {
            infoObjects[i].SetActive(true);
        }
    }

    public void hideInfo() {
        for (int i = 0; i < menuObjects.Length; i++) {
            menuObjects[i].SetActive(true);
        }
        for (int i = 0; i < infoObjects.Length; i++) {
            infoObjects[i].SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
