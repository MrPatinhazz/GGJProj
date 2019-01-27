using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipController : MonoBehaviour
{
    public GameObject gun;
    private bool _activeGun;
    public GameObject axe;
    private bool _activeAxe;

    // Start is called before the first frame update
    void Start()
    {
        _activeGun = true;
        _activeAxe = false;
        gun.gameObject.SetActive(_activeGun);
        axe.gameObject.SetActive(_activeAxe);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            _activeGun = !_activeGun;
            _activeAxe = !_activeAxe;
        }
        gun.gameObject.SetActive(_activeGun);
        axe.gameObject.SetActive(_activeAxe);
    }
}
