using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

    public float bulletSpeed = 5f;

	void Start () {
		
	}
	
	void Update () {
        this.transform.Translate(new Vector3(bulletSpeed * Time.deltaTime, 0, 0));
    }
}
