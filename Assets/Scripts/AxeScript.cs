using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public GameObject tree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            Debug.Log("collision.gameObject.tag");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Can cut");
        if(Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            Debug.Log("Cutting");
        }
    }

}
