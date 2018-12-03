using UnityEngine;

public class Computer : IActor
{
    public ActorState state;
    public GameObject MyPlatform;
    public GameObject TargetPlatform;
    public float ySpawnVariance = 3f;
    public float centerToSpawnEdge = 1f;
    public Cannon Cannon;
    public ActorType type = ActorType.computer;
    Vector3 PlatformCenter;

    override public ActorType GetType()
    {
        return type;
    }

    void Awake()
    {
        PlatformCenter = new Vector3(-10f, 1f, 0f);
        PlaceBlock();
    }

    override public void PlaceBlock()
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

    override public void EndPlacement()
    {
        // Hein???
    }

    override public void Shoot()
    {
        state = ActorState.Shooting;
        foreach(Block block in inventory.blocks)
        {
            Cannon.AIShoots(block, TargetPlatform.transform.position);
        }
    }

    override public void ShowInventory()
    {
        // I don't need to!!!!!
    }

    override public void Die()
    {
        state = ActorState.Dead;
    }

    public bool IsWinner() {
        return false;
    }

    override public bool CanShoot()
    {
        return inventory.ContainsBlocksWithState(Block.BlockState.ShootingBlock);
    }

    override public bool IsLoser()
    {
        return false;
    }
}
