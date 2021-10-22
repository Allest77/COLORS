using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public void QuitGame() {
        Application.Quit();
        Debug.Log("BYE");
    }

    //Level Select
    public void LoadLevel(int levelIndex) {
        SceneManager.LoadScene("TEST");
    } }
