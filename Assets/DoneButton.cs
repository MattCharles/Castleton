using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoneButton : MonoBehaviour {

    public GameObject powerSlider;
    public GameObject trajectoryObject;
    public Player humanPlayer;
    public GameObject CreateCubeButton;

    public void Update()
    {
        if (!Input.GetMouseButtonUp(0)) return;
        Debug.Log("I log");
        CreateCubeButton.SetActive(false);
        powerSlider.SetActive(true);
        trajectoryObject.SetActive(true);
        humanPlayer.EndPlacement();
        gameObject.SetActive(false);
    }
}
