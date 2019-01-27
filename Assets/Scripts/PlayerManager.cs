using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public bool facingRight;
    public int posOffset;
    public Animator animator; 
       
    // Start is called before the first frame update
    void Start()
    {
        //initialize variables
        speed = 8;
        facingRight = true; //default facing right
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5f;

        

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x -= objectPos.x;
        mousePos.y -= objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        
        if (angle > 0f && angle < 100f || angle < 0f && angle > -90f)
        {
            if (!facingRight)
            {
                facingRight = true;
                
            }
        }

        if (angle > 100f && angle < 180f || angle < -90f && angle > -180f)
        {
            if (facingRight)
            {
                facingRight = false;
            }
        }

        this.GetComponent<SpriteRenderer>().flipX = !facingRight;

        Debug.Log(facingRight);

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        animator.SetBool("mov", (x != 0.0f || y != 0.0f));

        Vector3 movement = new Vector3(x,y, 0.0f);

        
        transform.position += movement * speed * Time.deltaTime;
    }

}
