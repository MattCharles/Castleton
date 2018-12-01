using System.Collections.Generic;

public class Inventory
{
    public HashSet<Block> blocks;

    public Inventory(HashSet<Block> blocks)
    {
        this.blocks = blocks;
    }

    public int GetBlockCount()
    {
        int count = 0;
        foreach(var block in blocks)
        {
            // if(block.state == BlockState.Placed) count += 1;
        }

        return count;
    }
}