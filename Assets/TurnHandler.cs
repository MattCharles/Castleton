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
        if (player.state == ActorState.notMyTurn)
        {
            StartCoroutine(WaitForAI());
        }
        if(player.state == ActorState.doneShooting &&
            computer.state == ActorState.doneShooting)
        {
            GameOverCanvas.SetActive(true);
            GameOverWinPanel.SetActive(true);
        }

        if (player.IsLoser() || player.GetScore() <= computer.GetScore())
        {
            //GameOverLosePanel.SetActive(true);
        }
        else
        {
            //GameOverWinPanel.SetActive(true);
        }
    }

    IEnumerator WaitForAI()
    {
        yield return new WaitForSeconds(3f);
        computer.Shoot();
        player.state = ActorState.Shooting;
    }
}
