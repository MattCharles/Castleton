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

    public bool IsWinner() {
        return false;
    }
}
