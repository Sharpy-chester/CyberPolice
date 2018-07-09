using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : MonoBehaviour
{


    public float speed = 5f;
    public GameObject pivot;

    GameObject gunEmit;
    public GameObject projectile;

    float cooldown;
    public float maxCooldown = 1f;
    float shotDecay = 5f;

    //Animator gunAnimator;

    Vector3 zPos;
    public float zChange = 0f;

    public float change = 0.5f;

    public GameObject leftGun;
    public GameObject rightGun;

    void Start()
    {
        gunEmit = GameObject.FindGameObjectWithTag("BulletEmit");
        //gunAnimator = this.gameObject.GetComponent<Animator>();
        //scalepivot = GameObject.FindGameObjectWithTag("Scalepivot");
    }


    void Update()
    {

        var mouse = Input.mousePosition;
        var screenPoint = Camera.main.WorldToScreenPoint(pivot.transform.position);
        var offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        var angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (pivot.gameObject == GameObject.FindGameObjectWithTag("LeftPivot"))
        {
            pivot.transform.rotation = Quaternion.Euler(0, 180, -angle - 90f);
        }
        else
        {
            pivot.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        print(angle);
        if (pivot.gameObject == GameObject.FindGameObjectWithTag("LeftPivot"))
        {
            if (angle < 60 && angle > -60)
            {
                rightGun.gameObject.SetActive(true);
                leftGun.gameObject.SetActive(false);
            }
            else
            {
                
                rightGun.gameObject.SetActive(false);
                leftGun.gameObject.SetActive(true);
            }
        }
        else
        {
            if (angle < 120 && angle > -120)
            {
                rightGun.gameObject.SetActive(true);
                leftGun.gameObject.SetActive(false);
            }
            else
            {
                print(angle);
                rightGun.gameObject.SetActive(false);
                leftGun.gameObject.SetActive(true);
            }
        }

        GunRot();
        GunShoot();
        GunDepth();

    }

    void GunDepth()
    {
        if (this.transform.rotation.z > zChange)
        {
            zPos = new Vector3(this.transform.position.x, this.transform.position.y, 0.005f);
            this.transform.position = zPos;
        }
        else
        {
            zPos = new Vector3(this.transform.position.x, this.transform.position.y, -0.30f);
            this.transform.position = zPos;
        }
        //if (pivot.transform.rotation.z > 0.7071068)
        //{
        //    scalepivot.transform.localScale = new Vector3(scalepivot.transform.localScale.x, scalepivot.transform.localScale.y, scalepivot.transform.localScale.z);
        //}
    }

    void GunShoot()
    {

        if (cooldown > maxCooldown)
        {
            //gunAnimator.SetBool("Shot", false);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print(gunEmit.transform.position);
                GameObject shot = Instantiate(projectile, gunEmit.transform.position, gunEmit.transform.rotation);
                cooldown = 0f;
                Destroy(shot, shotDecay);

                //gunAnimator.SetBool("Shot", true);
            }
        }
        else
        {
            cooldown = cooldown + Time.deltaTime;
        }

    }

    void GunRot()
    {
        
        

    }
}
