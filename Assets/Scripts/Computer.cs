using UnityEngine;

public class Computer : MonoBehaviour, IActor
{
    public Inventory inventory;
    public ActorState state;
    public GameObject MyPlatform;
    public Vector3 TargetPlatform;
    public float centerToSpawnEdge = 5f;
    public Cannon Cannon;
    
    public void PlaceBlock()
    {
        state = ActorState.Placing;
        foreach(Block block in inventory.blocks)
        {
            if(Random.Range(0, 1) > .5f) {
                block.state = Block.BlockState.ShootingBlock;
                continue;
            }
            Instantiate(block, GetRandomPlacement(), Quaternion.identity);
            block.state = Block.BlockState.Placed;
        }
    }

    private Vector3 GetRandomPlacement()
    {
        float x = MyPlatform.transform.position.x + UnityEngine.Random.Range(-centerToSpawnEdge, centerToSpawnEdge);
        float y = MyPlatform.transform.position.y + 1;
        float z = MyPlatform.transform.position.z + UnityEngine.Random.Range(-centerToSpawnEdge, centerToSpawnEdge);
        return new Vector3(x, y, z);
    }

    public void EndPlacement()
    {
        // Hein???
    }

    public void Shoot()
    {
        state = ActorState.Shooting;
        foreach(Block block in inventory.blocks)
        {
            Cannon.AIShoots(block, TargetPlatform);
        }
    }

    public void ShowInventory()
    {
        // I don't need to!!!!!
    }

    public void Die()
    {
        state = ActorState.Dead;
    }

    public bool IsWinner() {
        return false;
    }

    public bool CanShoot()
    {
        return inventory.ContainsBlocksWithState(Block.BlockState.ShootingBlock);
    }

    public bool IsLoser()
    {
        return false;
    }
}
