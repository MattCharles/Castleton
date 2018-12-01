using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager instance = null; // Static instance of GameManager which allows it to be accessed by any other script.

    public Player player;                   // Store a reference to player
    public Player computer;                 // Store a reference to the computer
    public World world;                     // Store a reference to the world
    public List<Block> blockSet;            // Store a reference to the set of blocks

    public bool isPlayer1Turn;              // Store whose turn

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
        FillInventories();
        PlaceBlocks();
        Shoot();
        Die();
    }

    private void Die()
    {
        throw new NotImplementedException();
    }

    private void Shoot()
    {
        throw new NotImplementedException();
    }

    private void PlaceBlocks()
    {
        throw new NotImplementedException();
    }

    private void FillInventories()
    {
        throw new NotImplementedException();
    }

    private void CreatePlayers()
    {
        throw new NotImplementedException();
    }

    //Update is called every frame.
    void Update()
    {
        if (player.IsWinner())
            throw new NotImplementedException();
        else if (computer.IsWinner())
            throw new NotImplementedException();
    }
}
