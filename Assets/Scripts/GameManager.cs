using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using System;
using System.Linq;
using Assets.Scripts.Common;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null; // Static instance of GameManager which allows it to be accessed by any other script.

    public Player player   = null;  // Store a reference to player
    public Player computer = null;  // Store a reference to the computer
    public List<Block> blockSet;    // Store a reference to the set of blocks

    public bool isPlayerTurn = true; // Store whose turn

    //Awake is always called before any Start functions
    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();

    }
    private void Start()
    {
        GameObject.FindWithTag(Constants.Tags.soundManager).GetComponent<SoundManager>().PlaySound((int)Constants.Sounds.musicGame);
    }

    void InitGame()
    {
        CreatePlayers();
        PlaceBlocks();
        ShootBlocks();
        EndGame();
    }

    private void CreatePlayers()
    {
        player   = player   ?? new Player(new Inventory(blockSet), ActorType.human);
        computer = computer ?? new Player(new Inventory(blockSet), ActorType.computer);

    }

    private void PlaceBlocks()
    {
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
    }

    private void ShootBlocks()
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
    }
    private void EndGame()
    {
        if(player.IsLoser() || player.inventory.GetBlockCountWithState(Block.BlockState.Placed) <= computer.inventory.GetBlockCountWithState(Block.BlockState.Placed))
        {
            // You lose screen.
        }
        else
        {
            // You win screen.
        }
    }
}
