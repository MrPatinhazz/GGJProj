using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeScript : MonoBehaviour
{
    public GameObject tree;
    public float swingRate = 1;
    public int swingDmg = 35;
    private float _timeToSwing = 0;

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
        if(Input.GetButton("Fire1") && Time.time > _timeToSwing)
        {
            _timeToSwing = Time.time + 1 / swingRate;
            Swing(other);
        }
    }

    private void Swing(Collider2D _tree)
    {
        TreeController cTree = _tree.gameObject.GetComponent<TreeController>();
        cTree.DamageTree(swingDmg);
        Debug.Log("Tree hit for " + swingDmg);
    }

}
