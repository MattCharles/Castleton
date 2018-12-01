public interface IActor
{
    void die();
    void endPlacement();
    bool isWinner();
    void moveCamera();
    void placeBlock();
    void shoot();
    void showInventory();
}

public enum ActorState
{
    Placing, Shooting, Dead
}