using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 50f;
    Animator Playeranimator;
    float verticalValue;

    private void Awake()
    {
        Playeranimator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        verticalValue = Input.GetAxisRaw("Vertical");
        Move();
        Turn();
    }

    private void Move()
    {
        

        if(verticalValue != 0f)
        {
            Playeranimator.SetBool("runing", true);
            Playeranimator.SetFloat("direction", verticalValue);
            if(verticalValue < 0f)
            {
                transform.position -= transform.forward * moveSpeed * Time.deltaTime;

            }
            else transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            Playeranimator.SetBool("runing", false);
        }
    }

    private void Turn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit  groundHit;
        if(Physics.Raycast(ray,out groundHit, Mathf.Infinity))
        {
            Vector3 playertomouse= groundHit.point-transform.position;
            playertomouse.y = 0;
            Quaternion newrotate= Quaternion.LookRotation(playertomouse);
            transform.rotation = newrotate;
            
        }

    }
}
