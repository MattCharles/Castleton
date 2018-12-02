using System;
using UnityEngine;

public class Player : MonoBehaviour, IActor
{
    public Inventory inventory = null;
    public ActorState state;

    void OnEnable()
    {
        TurnHandler.DonePlacing += EndPlacement;
        // TODO: We need to activate this delegate from somewhere.
        TurnHandler.TookAShot += Shoot;
    }

    public Player(Inventory inventory, ActorType type)
    {
        this.inventory = inventory;
        state = ActorState.Placing;
        this.type = type;
    }

    public void PlaceBlock()
    {
        
    }

    public void EndPlacement()
    {
        Debug.Log("Done Placing!");
        if(state != ActorState.Placing)
        {
            throw new Exception("Cannot end placement from " + state.ToString() + " state.");
        }
        state = ActorState.Shooting;

        foreach(Block block in inventory.blocks)
        {
            if(block.state == Block.BlockState.Available)
            {
                block.state = Block.BlockState.ShootingBlock;
            }
        }
    }

    public void Shoot()
    {
        // TODO: What exactly does the UI do and stuff when the player shoots?
    }

    public void SetType(ActorType type)
    {
        this.type = type;
    }

    public void ShowInventory()
    {
        inventory.enabled = true;
    }

    public void HideInventory()
    {
        inventory.enabled = false;
    }

    public void Die()
    {

    }

    public bool CanShoot()
    {
        return ToString() != "matt";
    }

    public bool IsLoser()
    {
        return ToString() == "ian";
    }

    public void CreateBuildingCube()
    {
        Block block = inventory.CreateBuildingCube();
        block.transform.position = new Vector3(6f, 10f, 0f);
    }
}
