using UnityEngine;

public abstract class IActor : MonoBehaviour
{
    public abstract ActorType GetType();
    public abstract void Die();
    public abstract void EndPlacement();
    public abstract void PlaceBlock();
    public abstract void Shoot();
    public abstract void ShowInventory();
    public abstract bool CanShoot();
    public abstract bool HasRemainingAction();


    public Inventory inventory;

    public int GetScore()
    {
        return inventory.GetBlockCountWithState(Block.BlockState.Placed);
    }
}

public enum ActorState
{
    Placing, Shooting, notMyTurn, doneShooting, Dead
}

public enum ActorType
{
    human, computer
}