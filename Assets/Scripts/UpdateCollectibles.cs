using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCollectibles : MonoBehaviour
{
	public Text textBox;
	public float cubesAmount;
	public float cubesCollected;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<Text>();
        cubesAmount = GameObject.FindGameObjectsWithTag("Cube").Length;
        cubesCollected = 0;
    }

    // Update is called once per frame
    void Update()
    {
    	cubesCollected = cubesAmount - GameObject.FindGameObjectsWithTag("Cube").Length;
        textBox.text = cubesCollected + "/" + cubesAmount + " Cubes Collected.";
        if (cubesCollected == cubesAmount)
        {
            Destroy(door);
        }
    }
}
