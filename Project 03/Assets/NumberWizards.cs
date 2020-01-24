using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizards : MonoBehaviour
{
    int max;
    int min;
    int guess;

    public int maxGuessedAllowed = 5;

    public Text text;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = 1000;
        min = 1;
        NextGuess();
    }

    void NextGuess()
    {
        guess = Random.Range(min,max+1);
        text.text = guess.ToString();
        --maxGuessedAllowed;

        if(maxGuessedAllowed <= 0)
        {
            SceneManager.LoadScene("Win");
        }
       
    }

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
