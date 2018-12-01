using System;

public class Player : IActor
{
    public Inventory inventory = null;
    public ActorState state;

    public Player(Inventory inventory)
    {
        this.inventory = inventory;
        this.state = ActorState.Placing;
    }

    public void MoveCamera()
    {

    }
    public void PlaceBlock()
    {

    }
    public void EndPlacement()
    {
        if(state != ActorState.Placing)
        {
            throw new Exception($"Cannot end placement from {state.ToString()} state.");
        }
        state = ActorState.Shooting;
    }

    public void Shoot()
    {

    }
    public void ShowInventory()
    {

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
}
