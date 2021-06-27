using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    public Text textBox;
    public GameObject crate;
    Destruct destructable;
    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<Text>();
        destructable = crate.GetComponent<Destruct>();
    }

    // Update is called once per frame
    void Update()
    {
        print(destructable.ifBoxCracked);
        if (GameObject.Find("Enemy01") == null)
        {
            textBox.text = "Tutorial 2: Break crates by clicking";
            if (destructable.ifBoxCracked)
            {
                textBox.text = "Tutorial 3: Collect ALL cubes to progress";
            }
        }
        
    }
}
