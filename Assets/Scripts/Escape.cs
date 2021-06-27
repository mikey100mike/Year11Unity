using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    // Update is called once per frame
    // Source: https://answers.unity.com/questions/24538/how-to-have-the-escape-key-actualy-close-the-game.html
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
