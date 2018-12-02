using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;
using System.Linq;

public class Block : MonoBehaviour {


    bool isDestroyed;
    bool isSelected;
    GameObject blockObj;

	// Use this for initialization
	void Start ()
    {
        blockObj = gameObject.transform.GetChild(0).gameObject;
        isDestroyed = false;
        isSelected = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isDestroyed) return;

        CheckOutOfBounds();

        CheckClick();

        if (isSelected)
        {
            CheckMove();
        }
        
    }

    public void CheckMove()
    {
        if (isDestroyed) return;

        float x = Input.GetAxis("Horizontal") * Constants.BlockPlaceSpeed.x;
        float z = Input.GetAxis("Vertical") * Constants.BlockPlaceSpeed.y;

        //z axis
        float y = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X) ? 1f * Constants.BlockPlaceSpeed.y : 0f;
        //z direct
        y = Input.GetKey(KeyCode.X) ? -y : y;

        blockObj.transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
        blockObj.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 0f));
    }

    public void CheckOutOfBounds()
    {
        if (isDestroyed) return;

        bool[] outOfBounds = 
        {
            blockObj.transform.position.x <= Constants.BlockBounds.Lower.x,
            blockObj.transform.position.x >= Constants.BlockBounds.Upper.x,
            blockObj.transform.position.z <= Constants.BlockBounds.Lower.z,
            blockObj.transform.position.z >= Constants.BlockBounds.Upper.z,
            blockObj.transform.position.y <= Constants.BlockBounds.Lower.y,
            blockObj.transform.position.y >= Constants.BlockBounds.Upper.y
        };

        if (outOfBounds.Contains(true))
        {
            Destroy(blockObj);
            GameObject.FindWithTag(Constants.Tags.soundManager).GetComponent<SoundManager>().PlaySound((int)Constants.Sounds.blockDestroy);
            isDestroyed = true;
        }
    }

    public void CheckClick()
    {
        if (isDestroyed) return;

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
        if (isDestroyed) return;

        //blockObj.transform.rotation.Set(0f, 0f, 0f, 0f);
        blockObj.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        blockObj.GetComponent<Renderer>().material.color = Color.yellow;
        blockObj.GetComponent<Rigidbody>().useGravity = false;
        blockObj.GetComponent<Rigidbody>().freezeRotation = true;
        isSelected = true;
    }

    public void DeSelect()
    {
        if (isDestroyed) return;

        blockObj.GetComponent<Renderer>().material.color = Color.white;
        blockObj.GetComponent<Rigidbody>().useGravity = true;
        blockObj.GetComponent<Rigidbody>().freezeRotation = false;
        isSelected = false;
        
    }



    
}
