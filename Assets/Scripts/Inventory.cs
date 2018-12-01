using System.Collections.Generic;

public class Inventory
{
    public HashSet<Block> blocks;

    public Inventory(HashSet<Block> blocks)
    {
        this.blocks = blocks;
    }
}