using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armManager : MonoBehaviour {

    Vector3 zPos;
    public float zChange = 0.7071068f;

	void Start () {
        
	}

	void Update () {
        
        if (this.gameObject == GameObject.FindGameObjectWithTag("LeftArm"))
        {
            if (this.transform.rotation.z < zChange)
            {
                zPos = new Vector3(this.transform.position.x, this.transform.position.y, 0.1f);
                this.transform.position = zPos;
            }
            else
            {
                zPos = new Vector3(this.transform.position.x, this.transform.position.y, -0.1f);
                this.transform.position = zPos;
            }
        }
        else
        {
            if (this.transform.rotation.z > zChange)
            {
                zPos = new Vector3(this.transform.position.x, this.transform.position.y, 0.1f);
                this.transform.position = zPos;
            }
            else
            {
                zPos = new Vector3(this.transform.position.x, this.transform.position.y, -0.1f);
                this.transform.position = zPos;
            }
        }
		
	}
}
