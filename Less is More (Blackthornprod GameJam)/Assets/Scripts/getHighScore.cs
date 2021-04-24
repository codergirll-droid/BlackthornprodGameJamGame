using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class getHighScore : MonoBehaviour
{
    public Text Text;

    // Start is called before the first frame update
    void Start()
    {
        float a = PlayerPrefs.GetFloat("Highscore");
        Text.text = "Highscore: " + a.ToString("0");
    }

}
