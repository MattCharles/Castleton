using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public float xzSpeed = 1f;
    public float ySpeed = 1f;

    bool isSelected;

	// Use this for initialization
	void Start () {

        isSelected = false;

	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform != null)
                {
                    GetComponent<Renderer>().material.color = Color.yellow;
                    isSelected = true;
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
                    GetComponent<Renderer>().material.color = Color.white;
                    isSelected = false;
                }
                
            }
        }


        if (isSelected) {
            //x and z axis
            float x = Input.GetAxis("Horizontal") * xzSpeed;
            float z = Input.GetAxis("Vertical") * xzSpeed;

            //z axis
            float y = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.X) ? (1f * ySpeed) : 0f;
            //z direct
            y = Input.GetKey(KeyCode.X) ? -y : y;

            transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
        }
        
    }

    
}
