using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCube : MonoBehaviour
{
    public AudioClip sound;
    private void OnTriggerEnter(Collider other) 
    {
    	Destroy(gameObject);
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
