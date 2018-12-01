using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null; // Static instance of GameManager which allows it to be accessed by any other script.

    public Player player   = null; // Store a reference to player
    public Player computer = null; // Store a reference to the computer
    public World world;            // Store a reference to the world
    public List<Block> blockSet;   // Store a reference to the set of blocks

    public bool isPlayerTurn; // Store whose turn

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

    void InitGame()
    {
        CreatePlayers();
        PlaceBlocks();
        ShootBlocks();
        Die();
    }

    private void CreatePlayers()
    {
        player   = player   ?? new Player(new Inventory(blockSet));
        computer = computer ?? new Player(new Inventory(blockSet));
    }

    private void PlaceBlocks()
    {
        while(player.state != ActorState.donePlacing && computer.state != ActorState.donePlacing)
        {
            if(isPlayerTurn && player.state == ActorState.Placing)
            {
                player.ShowInventory();
            }
            else if(!isPlayerTurn && computer.state == ActorState.Placing)
            {
                computer.ShowInventory();
            }
        }
    }

    private void ShootBlocks()
    {
        while(player.state != ActorState.doneShooting && computer.state != ActorState.doneShooting)
        {
            if(isPlayerTurn && player.CanShoot() && !player.IsLoser())
            {
                player.ShowInventory();
            }
            else if(!isPlayerTurn && computer.CanShoot() && !computer.IsLoser())
            {
                computer.ShowInventory();
            }
        }
    }

    private void Die()
    {
        throw new NotImplementedException();
    }

    //Update is called every frame.
    void Update()
    {
        if (player.IsLoser())
            throw new NotImplementedException();
        else if (computer.IsLoser())
            throw new NotImplementedException();
    }
}
