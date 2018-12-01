public interface IActor
{
    void Die();
    void EndPlacement();
    bool IsWinner();
    void MoveCamera();
    void PlaceBlock();
    void Shoot();
    void ShowInventory();
}

public enum ActorState
{
    Placing, donePlacing, Shooting, doneShooting, Dead
}