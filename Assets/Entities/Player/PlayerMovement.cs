using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public GameObject laserObject;

    void Start()
    {

    }

    void Update () {      

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-0.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.2f, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Fire");
            Instantiate(laserObject, transform.position, Quaternion.identity);
        }

    }

  	
}
