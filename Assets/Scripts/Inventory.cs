using System.Collections.Generic;

public class Inventory
{
    public List<Block> buildingBlocks;
    public List<Block> shootingBlocks;

    public Inventory(List<Block> buildingBlocks, List<Block> shootingBlocks)
    {
        this.buildingBlocks = buildingBlocks;
        this.shootingBlocks = shootingBlocks;
    }
}