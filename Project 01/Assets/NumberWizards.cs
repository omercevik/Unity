using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizards : MonoBehaviour
{
    int max;
    int min;
    int guess;

    void Start() { StartGame(); }
    
    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = 500;
        print("========================");
        print("Welcome to Number Wizard!");
        print("Pick a number in your head, but don't tell me. :)");
        print("The heighest number that you can pick is : " + max);
        print("The lowest number that you can pick is : " + min);
        print("Is the number higher or lower than " + guess + " ?");
        print("Up = heigher, down = lower, return = equal");
        ++max;
    }

    void NextGuess() {
        guess = (max + min) / 2;
        print("Higher or lower than " + guess + " ?");
        print("Up = heigher, down = lower, return = equal");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) { min = guess;
                                                 NextGuess(); }
        else if (Input.GetKeyDown(KeyCode.DownArrow)) { max = guess;
                                                        NextGuess(); }
        else if (Input.GetKeyDown(KeyCode.Return)) { print("I won!"); }
    }
}
