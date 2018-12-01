using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;

public class Block : MonoBehaviour {


    bool isSelected;

	// Use this for initialization
	void Start ()
    {

        isSelected = false;

	}
	
	// Update is called once per frame
	void Update ()
    {
        CheckOutOfBounds();

        CheckClick();

        if (isSelected)
        {
            CheckMove();
        }
        
    }

    public void CheckMove()
    {
        float x = Input.GetAxis("Horizontal") * Constants.XZ_BLOCK_MOVE_SPEED;
        float z = Input.GetAxis("Vertical") * Constants.XZ_BLOCK_MOVE_SPEED;

        //z axis
        float y = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X) ? (1f * Constants.Y_BLOCK_MOVE_SPEED) : 0f;
        //z direct
        y = Input.GetKey(KeyCode.X) ? -y : y;

        transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
    }

    public void CheckOutOfBounds()
    {
 
        if (gameObject.transform.position.y <= Constants.BLOCK_OUT_OF_BOUNDS_Y)
        {
            Destroy(gameObject);
            
        }
    }

    public void CheckClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform != null)
                {
                    Select();
                }

            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform != null)
                {
                    DeSelect();
                }

            }
        }
    }

    public void Select()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
        GetComponent<Rigidbody>().useGravity = false;
        isSelected = true;
    }

    public void DeSelect()
    {
        GetComponent<Renderer>().material.color = Color.white;
        isSelected = false;
        GetComponent<Rigidbody>().useGravity = true;
    }



    
}
