using UnityEngine;

public class Computer : MonoBehaviour, IActor
{
    public Inventory inventory;
    public ActorState state;
    public GameObject MyPlatform;
    public GameObject TargetPlatform;
    public float ySpawnVariance = 3f;
    public float centerToSpawnEdge = 1f;
    public Cannon Cannon;
    public ActorType type = ActorType.computer;
    Vector3 PlatformCenter;

    public new ActorType GetType()
    {
        return type;
    }

    void Awake()
    {
        PlatformCenter = new Vector3(-10f, 1f, 0f);
        PlaceBlock();
    }

    public void PlaceBlock()
    {
        state = ActorState.Placing;
        foreach(Block block in inventory.blocks)
        {
            block.owner = this;
            if(Random.Range(0f, 1f) > .35f) {
                block.state = Block.BlockState.ShootingBlock;
                continue;
            }
            
            block.transform.position = GetRandomPlacement();
            Debug.Log(block.transform.position);
            block.gameObject.SetActive(true);
            block.state = Block.BlockState.Placed;
        }
    }

    private Vector3 GetRandomPlacement()
    {
        float r1 = UnityEngine.Random.Range(-centerToSpawnEdge, centerToSpawnEdge);
        float r2 = UnityEngine.Random.Range(-centerToSpawnEdge, centerToSpawnEdge);
        float deltaY = UnityEngine.Random.Range(0f, ySpawnVariance);
        float x = PlatformCenter.x + r1;
        float y = PlatformCenter.y + deltaY;
        float z = PlatformCenter.z + r2;
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
            Cannon.AIShoots(block, TargetPlatform.transform.position);
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
