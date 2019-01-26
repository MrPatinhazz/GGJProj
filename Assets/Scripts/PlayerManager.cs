using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool isReloading, canShoot;
    public float speed, shootingSpeed;
    public GameObject crosshair;
    public GameObject pelletPrefab;
    public bool facingRightElseFacingLeft;
    public int posOffset;
    public GameObject weapon;


    // Start is called before the first frame update
    void Start()
    {
        //initialize variables
        speed = 8;
        shootingSpeed = 15;
        isReloading = false;
        canShoot = true;
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

        if (facingRightElseFacingLeft)
        {
            posOffset = 75;
        } else
        {
            posOffset = 110;
        }

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + posOffset)); //rotating

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

       // aimAndShoot();
    }

    //shooting and crosshair movement
    void aimAndShoot()
    {
        //update shooting direction
        Vector2 shootingDirection = new Vector2((Input.mousePosition).x, (Input.mousePosition).y);
        crosshair.transform.position = Input.mousePosition.normalized;
        RaycastHit2D raycast = Physics2D.Raycast(transform.position, shootingDirection, 100);

        shootingDirection.Normalize();


        if (Input.GetButtonDown("Fire1"))
        {
            GameObject pellet = Instantiate(pelletPrefab, transform.position, Quaternion.identity);
            pellet.GetComponent<Rigidbody2D>().velocity = shootingDirection * shootingSpeed;
            pellet.transform.Rotate(0.0f, 0.0f, Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg);
            Destroy(pellet, 2.0f);
        }
    }
}
