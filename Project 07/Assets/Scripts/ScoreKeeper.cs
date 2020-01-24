using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    private Text myText;

    private void Start()
    {
        myText = GetComponent<Text>();
        Reset();
    }

    public void Score(int points)
    {
        score += points;
        myText.text = score.ToString();
    }

    public static void Reset()
    {
        score = 0;
    }
}
