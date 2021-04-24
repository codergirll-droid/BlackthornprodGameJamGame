using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGame : MonoBehaviour
{
    public void exit()
    {
        Debug.Log("Quitted game!");
        Application.Quit();
    }
}
