public interface IActor
{
    void Die();
    void EndPlacement();
    void MoveCamera();
    void PlaceBlock();
    void Shoot();
    void ShowInventory();
    bool CanShoot();
    bool IsLoser();
}

public enum ActorState
{
    Placing, donePlacing, Shooting, doneShooting, Dead
}