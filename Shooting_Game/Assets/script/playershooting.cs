using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playershooting : MonoBehaviour
{
    public GameObject Bulletpre;
    public float firerate = 0.5f;
    public Transform poitfire;
    private float nextbullet = 0.5f;

    private Animator playerAnimator;


    private void Awake()
    {
        playerAnimator=GetComponentInChildren<Animator>();
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            playerAnimator.SetBool("fire", true);
            if(Time.time > nextbullet)
            {
                nextbullet = Time.time+firerate;
                GameObject bullet = Instantiate(Bulletpre, poitfire.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = transform.forward * 20;
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            playerAnimator.SetBool("fire", false);
        }
    }

}
