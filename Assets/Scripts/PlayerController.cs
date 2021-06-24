using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	public CharacterController controller;
    public float speed = 8f;
    public float gravity = -30f;
    public float jumpHeight = 3f;
    public float jumpCount = 0f;
    Vector3 velocity;
    Animator PlayerAnimator;
    
    // Start is called before the first frame update
    void Start() 
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        // Makes sure player only moves when buttons are pressed, else player will slide
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) 
        {
        	controller.Move(move * speed * Time.deltaTime);
            PlayerAnimator.SetInteger("Condition", 2);
        } else 
        {
            PlayerAnimator.SetInteger("Condition", 1);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        // Jumping script, makes sure player hasn't exceeded jump limit.
        if(Input.GetKeyDown("space") && jumpCount < 2)
        {
        	jumpCount += 1;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // If player is on the ground stop velocity from decreasing
        if (controller.isGrounded && !(Input.GetKeyDown("space")))
        {
            velocity.y = 0;
            jumpCount = 0;
        }

        // Checks if player is below ground barrier, if this is the case, restart level
        if (controller.transform.position.y < -10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // If object is ramp give player push player up
        if (other.gameObject.tag == "Ramp")
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}