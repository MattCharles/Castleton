using System.Collections.Generic;

public class Inventory
{
    public List<Block> available;
    public List<Block> placed;
    public List<Block> shot;

    public Inventory(List<Block> blocks)
    {
        this.available = blocks;
    }
}