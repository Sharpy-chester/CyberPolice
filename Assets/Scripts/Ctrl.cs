using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Ctrl : MonoBehaviour {

    Animator animator;

    public float speed = 5f;


    void Start () {
        animator = GetComponent<Animator>();
	}
	

	void Update () {
        
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f, 0f));
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime, 0f));
        }
        animator.SetFloat("X", Input.GetAxisRaw("Horizontal"));
        animator.SetFloat("Y", Input.GetAxisRaw("Vertical"));
    }



    
}
