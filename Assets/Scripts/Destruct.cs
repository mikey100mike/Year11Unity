using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
	public GameObject destroyedVersion;
    public bool ifBoxCracked = false;
    void OnMouseDown()
    {
        ifBoxCracked = true;
    	Instantiate(destroyedVersion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}