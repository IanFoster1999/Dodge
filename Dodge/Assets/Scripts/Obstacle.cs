using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {


	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (this.transform.position.y < (Camera.main.gameObject.transform.position.y - 10))
            Destroy(this.gameObject);
	}
}
