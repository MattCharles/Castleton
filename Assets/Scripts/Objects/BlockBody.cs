using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBody : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        GetComponentInParent<Block>().Select();
    }

    private void OnMouseUp()
    {
        GetComponentInParent<Block>().DeSelect();
    }

    void OnCollisionEnter(Collision collision)
    {
        //TODO check if hitting block
        GetComponentInParent<Block>().BlockCollide();
    }
}
