using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

	public void Exit()
    {
        Debug.Log("EXIT");
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
