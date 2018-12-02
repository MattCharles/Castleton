using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource[] soundList;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlaySound(int audio)
    {
        soundList[audio].Play();
    }

    public void PauseSound(int audio)
    {
        soundList[audio].Pause();
    }
}
