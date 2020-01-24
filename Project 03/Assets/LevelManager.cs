using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour{
    public void LoadLevel(string name){
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }
    public void QuitRequest(){
        Debug.Log("I wanna quit!");
        Application.Quit();
    }
}
