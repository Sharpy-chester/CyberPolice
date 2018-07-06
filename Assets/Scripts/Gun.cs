using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : MonoBehaviour {

    public GameObject player;
    public float speed = 5f;
    GameObject pivot;

	void Start () {
        pivot = GameObject.FindGameObjectWithTag("Pivot");
	}
	

	void Update () {

        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        pivot.transform.rotation = Quaternion.Euler(0, 0, angle);

    }
}
