using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float speed;
    public bool facingRightElseFacingLeft;
    public int posOffset;
       
    // Start is called before the first frame update
    void Start()
    {
        //initialize variables
        speed = 8;
        facingRightElseFacingLeft = true; //default facing right
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
            if (!facingRightElseFacingLeft)
            {
                facingRightElseFacingLeft = true;
            }
        }

        if (angle > 100f && angle < 180f || angle < -90f && angle > -180f)
        {
            if (facingRightElseFacingLeft)
            {
                facingRightElseFacingLeft = false;
            }
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        transform.position += movement * speed * Time.deltaTime;
    }

}
