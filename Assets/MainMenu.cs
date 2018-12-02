using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public void Start()
    {
        GameObject.FindWithTag(Constants.Tags.soundManager).GetComponent<SoundManager>().PlaySound((int)Constants.Sounds.musicMenu);
    }
    public void Play() 
    {
        SceneManager.LoadScene(1); //TODO
        
    }

    public void Quit()
    {
        Application.Quit();
    }

}
