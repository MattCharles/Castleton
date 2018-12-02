public interface IActor
{
    ActorType GetType();

    void Die();
    void EndPlacement();
    void PlaceBlock();
    void Shoot();
    void ShowInventory();
    bool CanShoot();
    bool IsLoser();
}

public enum ActorState
{
    Placing, Shooting, doneShooting, Dead
}

public enum ActorType
{
    human, computer
}