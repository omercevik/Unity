using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text text;

	void Update () {
        text.text = player.position.z.ToString("0");
	}
}
