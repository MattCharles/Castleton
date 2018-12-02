using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Common;
using System.Linq;

public class Block : MonoBehaviour {

    bool isDestroyed;
    bool isSelected;
    bool collidedWithOpponent;
    GameObject blockObj;
    public BlockState state = BlockState.Available;
    public Player owner;

	// Use this for initialization
	void Start ()
    {
        blockObj = gameObject.transform.GetChild(0).gameObject;
        isDestroyed = false;
        isSelected = false;
        collidedWithOpponent = false;

        //TODO remove this
        //hard coding for testing
        owner = new Player(null, ActorType.human);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isDestroyed) return;

        CheckOutOfBounds();

        //CheckClick();

        if (isSelected)
        {
            CheckMove();
        }
        
    }

    public void BlockCollide()
    {
        switch (state)
        {
            //make collide noise
            case BlockState.Shot:
                FiredCollide();
                break;
        }
    }

    private void FiredCollide()
    {
        //make collide noise, only once
        if(!collidedWithOpponent) GameObject.FindWithTag(Constants.Tags.soundManager).GetComponent<SoundManager>().PlaySound((int)Constants.Sounds.collide);
        collidedWithOpponent = true;
    }


    public void CheckMove()
    {
        if (isDestroyed) return;
        //if (state != BlockState.BuildingBlock) return;

        float x = Input.GetAxis("Horizontal") * Constants.BlockPlaceSpeed.x;
        float z = Input.GetAxis("Vertical") * Constants.BlockPlaceSpeed.y;

        //y axis
        float y = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X) ? 1f * Constants.BlockPlaceSpeed.y : 0f;
        //y direction
        y = Input.GetKey(KeyCode.X) ? y : -y;


        //no rotation in x or z dir
        float rX = 0f;
        float rZ = 0f;

        //rotation y
        float rY = Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E) ? 1f : 0f;
        //rotation y direction
        rY = Input.GetKey(KeyCode.E) ? -rY : rY;

        blockObj.transform.Rotate((new Vector3(rX, rY, rZ)), Time.deltaTime * Constants.BlockPlaceSpeed.r);
        blockObj.transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
        //blockObj.GetComponent<Rigidbody>().AddForce(new Vector3(0f, 0f, 0f));
    }

    public void CheckOutOfBounds()
    {
        if (isDestroyed) return;
        if (blockObj == null) return;

        if
        (
            blockObj.transform.position.x <= Constants.BlockBounds.Lower.x
            || blockObj.transform.position.x >= Constants.BlockBounds.Upper.x
            || blockObj.transform.position.z <= Constants.BlockBounds.Lower.z
            || blockObj.transform.position.z >= Constants.BlockBounds.Upper.z
            || blockObj.transform.position.y <= Constants.BlockBounds.Lower.y
            || blockObj.transform.position.y >= Constants.BlockBounds.Upper.y
        )
        {
            Destroy(blockObj);
            GameObject.FindWithTag(Constants.Tags.soundManager).GetComponent<SoundManager>().PlaySound((int)Constants.Sounds.blockDestroy);
            isDestroyed = true;
        }

    }

    //public void CheckClick()
    //{
    //    
    //    if (isDestroyed) return;
    //    if (state != BlockState.BuildingBlock) return;

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        if (Physics.Raycast(ray, out hit, 100f))
    //        {
    //            if (hit.transform != null)
    //            {
    //                Select();
    //            }

    //        }
    //    }
    //    else if (Input.GetMouseButtonDown(1))
    //    {
    //        RaycastHit hit;
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //        if (Physics.Raycast(ray, out hit, 100f))
    //        {
    //            if (hit.transform != null)
    //            {
    //                DeSelect();
    //            }

    //        }
    //    }
    //}

    public void Select()
    {
        if (isDestroyed) return;
        if (state != BlockState.BuildingBlock) return;

        //TODO if ever adding hotseat this will not work
        if (owner.type != ActorType.human) return;

        blockObj.transform.rotation = Quaternion.identity;
        blockObj.GetComponent<Renderer>().material.color = Color.yellow;
        blockObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        isSelected = true;
    }

    public void DeSelect()
    {
        if (isDestroyed) return;
        if (state != BlockState.BuildingBlock) return;

        //TODO if ever adding hotseat this will not work
        if (owner.type != ActorType.human) return;

        blockObj.GetComponent<Renderer>().material.color = Color.white;
        blockObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        isSelected = false;

        
    }

    public enum BlockState
    {
        Available, BuildingBlock, ShootingBlock, Placed, Shot
    }
    
}
