using System;
using UnityEngine;

public class Player : IActor
{
    public ActorState state;
    public ActorType type;
    public FireProjectile playerCannon;

    override public ActorType GetType()
    {
        return type;
    }

    void OnEnable()
    {
        TurnHandler.DonePlacing += EndPlacement;
        // TODO: We need to activate this delegate from somewhere.
        TurnHandler.TakeAShot += Shoot;
    }

    void Update()
    {
        if(this.state == ActorState.Shooting)
        {
            playerCannon.HandleInput();
        }
    }

    public Player(Inventory inventory, ActorType type)
    {
        this.inventory = inventory;
        state = ActorState.Placing;
        this.type = type;

        playerCannon.linkedInventory = inventory;
    }

    override public void PlaceBlock()
    {
        
    }

    override public void EndPlacement()
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

    override public void Shoot()
    {
        // i think this needs to stay blank unless we move fire controls up here
        
    }

    public void SetType(ActorType type)
    {
        this.type = type;
    }

    override public void ShowInventory()
    {
        inventory.enabled = true;
    }

    public void HideInventory()
    {
        inventory.enabled = false;
    }

    override public void Die()
    {

    }

    override public bool CanShoot()
    {
        return ToString() != "matt";
    }

    override public bool IsLoser()
    {
        return ToString() == "ian";
    }

    public void CreateBuildingCube()
    {
        Block block = inventory.CreateBuildingCube();
        block.transform.position = new Vector3(6f, 10f, 0f);
    }
}
