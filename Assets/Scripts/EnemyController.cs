using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float LookRadius = 20f;
    public float MoveSpeed = 2f;
    public CharacterController controller;
    public float gravity = -9.8f;
    Transform target;
    Transform spawnPoint;
    Vector3 velocity;

    // Player Manager manages the position
    void Start()
    {
    	target = PlayerManager.instance.player.transform;
    	spawnPoint = EnemyManager.instance.spawnPoint.transform;
    }
    void Update() 
    {
        // If distance between player and enemy smaller than look radius, face player
        if (Vector2.Distance(transform.position, target.position) <= LookRadius)
        {
            transform.LookAt(target);   
        } else 
        {
            transform.LookAt(spawnPoint);
        }
        Vector3 eulerAngles = transform.rotation.eulerAngles;
        eulerAngles = new Vector3(0, eulerAngles.y, 0);
        transform.rotation = Quaternion.Euler(eulerAngles);
        Vector3 move = transform.forward;
        controller.Move(move * MoveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    // Draws the Radius of the view of the the enemy (This is for adjusting what the enemy see)
    void OnDrawGizmos() 
    {
    	Gizmos.color = Color.red;
    	Gizmos.DrawWireSphere(transform.position, LookRadius);
    }
}
