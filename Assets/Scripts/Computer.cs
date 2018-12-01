﻿using System;
using UnityEngine;

public class Computer : MonoBehaviour, IActor
{
    public Inventory inventory;
    public ActorState state;
    public GameObject MyPlatform;
    public float centerToSpawnEdge = 5f;
    public GameObject Cannon;

    public void MoveCamera()
    {
        // Do Fucking Nothing At All -- Ever!!!
    }
    public void PlaceBlock()
    {
        state = ActorState.Placing;
        foreach(Block block in inventory.buildingBlocks)
        {
            Instantiate(block, GetRandomPlacement(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPlacement()
    {
        float x = MyPlatform.transform.position.x + UnityEngine.Random.Range(-centerToSpawnEdge, centerToSpawnEdge);
        float y = MyPlatform.transform.position.y + 1;
        float z = MyPlatform.transform.position.z + UnityEngine.Random.Range(-centerToSpawnEdge, centerToSpawnEdge);
        return new Vector3(x, y, z);
    }

    public void EndPlacement()
    {
        // Hein???
    }

    public void Shoot()
    {
        state = ActorState.Shooting;
        foreach(Block block in inventory.shootingBlocks)
        {
            //Cannon.Shoot(block);
            //  transform or something?
        }
    }

    public void ShowInventory()
    {
        // I don't need to!!!!!
    }

    public void Die()
    {
        state = ActorState.Dead;
    }

    public bool IsWinner() {
        return false;
    }
}