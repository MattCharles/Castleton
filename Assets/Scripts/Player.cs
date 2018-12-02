using System;
using UnityEngine;

public class Player : MonoBehaviour, IActor
{
    public Inventory inventory = null;
    public ActorState state;
    public ActorType type;

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
        if(state != ActorState.Placing)
        {
            throw new Exception("Cannot end placement from " + state.ToString() + " state.");
        }
        state = ActorState.Shooting;
    }

    public void Shoot()
    {

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
