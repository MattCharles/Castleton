using Assets.Scripts.Common;
using UnityEngine;

public class Player : IActor
{
    public ActorState state;
    public ActorType type;
    public FireProjectile playerCannon;
    public CameraMovement cameraMovement;

    override public ActorType GetType()
    {
        return type;
    }

    void Update()
    {
        if(inventory.GetBlockCountWithState(Block.BlockState.ShootingBlock) == 0 &&
            inventory.GetBlockCountWithState(Block.BlockState.Available) == 0)
        {
            this.state = ActorState.doneShooting;
        }
        if(this.state == ActorState.Shooting)
        {
            cameraMovement.playerShooting = true;
            if (playerCannon.HandleInput())
            {
                cameraMovement.playerShooting = false;
                state = ActorState.notMyTurn;
            }
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
        state = ActorState.Shooting;

        foreach(Block block in inventory.currentBlockList)
        {
            if(block.state == Block.BlockState.BuildingBlock)
            {
                block.state = Block.BlockState.Placed;
            }
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
        return inventory.ContainsBlocksWithState(Block.BlockState.ShootingBlock);
    }

    public void CreateBuildingCube()
    {
        Block block = inventory.CreateBuildingCube();
        block.transform.position = new Vector3(4f, 10f, -2f);
    }

    override public bool HasRemainingAction()
    {
        return inventory.ContainsBlocksWithStates(Constants.actionStates);
    }
}
