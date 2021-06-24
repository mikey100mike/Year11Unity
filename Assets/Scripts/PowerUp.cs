using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PlayerController controller;
    void Start()
    {
        controller = GetComponent<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {   
        // Speed UP Power Up
        if (other.gameObject.tag == "Speed Up")
        {
            controller.speed = 50f;
        }
        else if (other.gameObject.tag == "Slow Down")
        {
            controller.speed = 8f;
        }

        // Mini Power Up
        if (other.gameObject.tag == "MiniPowerUp")
        {
            // Change scale of player controller
            transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            controller.jumpHeight = 0.5f;
            controller.gravity = -10f;
        } else if (other.gameObject.tag == "NormalSize")
        {
            // Revert to original scale
            transform.localScale = new Vector3(1f, 1f, 1f);
            controller.jumpHeight = 3f;
            controller.gravity = -30f;
        }
    }
}
