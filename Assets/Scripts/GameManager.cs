using UnityEngine;

using System.Collections.Generic; 
using Assets.Scripts.Common;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null; // Static instance of GameManager which allows it to be accessed by any other script.

    public Player player   = null;  // Store a reference to player
    public Computer computer = null;  // Store a reference to the computer
    public List<Block> blockSet;    // Store a reference to the set of blocks

    public bool isPlayerTurn = true; // Store whose turn

    public GameObject GameOverWinPanel;
    public GameObject GameOverLosePanel;

    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        GameOverWinPanel.SetActive(false);
        GameOverLosePanel.SetActive(false);
    }
    private void Start()
    {
        GameObject.FindWithTag(Constants.Tags.soundManager).GetComponent<SoundManager>().PlaySound((int)Constants.Sounds.musicGame);
    }

    void Update()
    {
        //CreatePlayers();
        //PlaceBlocks();
        //ShootBlocks();
        ProcessTurns();
    }

    /*private void CreatePlayers()
    {
        player   = player   ?? new Player(new Inventory(blockSet), ActorType.human);
        computer = computer ?? new Computer(new Inventory(blockSet), ActorType.computer);

    }*/

    /*private void PlaceBlocks()
    {
        // Todo: change this
        while(player.state == ActorState.Placing || computer.state == ActorState.Placing)
        {
            if(isPlayerTurn)
            {
                if(player.state == ActorState.Placing)
                {
                    player.ShowInventory();
                }
                else if(player.state == ActorState.Shooting)
                {
                    player.HideInventory();
                    isPlayerTurn = false;
                }
            }
            if(!isPlayerTurn)
            {
                if(computer.state == ActorState.Placing)
                {
                    computer.ShowInventory();
                }
                else if(computer.state == ActorState.Shooting)
                {
                    computer.HideInventory();
                    isPlayerTurn = true;
                }
            }
        }

        player.HideInventory();
        computer.HideInventory();
        isPlayerTurn = true; // player always gets to shoot first
    }*/

    /*private void ShootBlocks()
    {
        while(player.state != ActorState.doneShooting || computer.state != ActorState.doneShooting)
        {
            if(player.IsLoser() || computer.IsLoser()) {
                return;
            }
            else if(isPlayerTurn && player.CanShoot())
            {
                player.ShowInventory();
                player.Shoot();
                player.HideInventory();
                isPlayerTurn = false;
            }
            else if(!isPlayerTurn && computer.CanShoot())
            {
                computer.ShowInventory();
                computer.Shoot();
                computer.HideInventory();
                isPlayerTurn = true;
            }
        }
    }*/

    private void ProcessTurns()
    {
        Debug.Log("I'm gaming.");
        if(player.state == ActorState.notMyTurn)
        {
            computer.Shoot();
            player.state = ActorState.Shooting;
        }
        //if (!player.HasRemainingAction() && !computer.HasRemainingAction())
        //{
        //    if (player.GetScore() < computer.GetScore())
        //    {
        //        GameOverLosePanel.SetActive(true);
        //    }
        //    else
        //    {
        //        GameOverWinPanel.SetActive(true);
        //    }
        //}
    }
}
