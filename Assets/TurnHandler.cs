using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnHandler : MonoBehaviour {

    public Player player;
    public Computer computer;

    public GameObject GameOverWinPanel;
    public GameObject GameOverLosePanel;
    public GameObject GameOverCanvas;

    private void Update()
    {
        if (player.state == ActorState.notMyTurn ||
           (player.state == ActorState.doneShooting && 
            computer.CanShoot()))
        {
            StartCoroutine(WaitForAI());
        }

        if (!player.HasRemainingAction() && !computer.HasRemainingAction())
        {
            GameOverCanvas.SetActive(true);
            
            if (player.GetScore() < computer.GetScore())
            {
                GameOverLosePanel.SetActive(true);
            }
            //TODO add draw screen, right now draws go to player
            else if(player.GetScore() >= computer.GetScore())
            {
                GameOverWinPanel.SetActive(true);
            }
        }
    }

    IEnumerator WaitForAI()
    {
        player.state = ActorState.ImGaming;
        yield return new WaitForSeconds(3f);
        player.state = ActorState.Shooting;
        computer.Shoot();
    }
}
