using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RisingLava : MonoBehaviour
{
    public float speed = 0.01f;
    float updateY;

    // Update is called once per frame
    void Update()
    {
        speed += speed;
        updateY = transform.position.y + speed;
        transform.position = new Vector3(transform.position.x, updateY, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
