using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Block> blocks;

    public Inventory(List<Block> blocks)
    {
        this.blocks.AddRange(blocks);
    }

    public int GetBlockCountWithState(Block.BlockState state)
    {
        int count = 0;
        foreach(var block in blocks)
        {
            if (block == null) continue;
            if(block.state == state) count += 1;
        }

        return count;
    }

    public bool ContainsBlocksWithState(Block.BlockState state)
    {
        foreach(Block block in blocks)
        {
            if (block.state == state)
            {
                return true;
            }
        }
        return false;
    }

    public bool ContainsBlocksWithStates(Block.BlockState[] states)
    {
        foreach (Block block in blocks)
        {
            print(block.state);
            if (states.ToList().Contains((block.state)))
            {
                return true;
            }
        }
        return false;
    }

    public Block GetFirstBlockWithState(Block.BlockState state)
    {
        foreach(Block block in blocks)
        {
            if(block.state == state)
            {
                return block;
            }
        }
        return null;
    }


    public Block CreateBuildingCube()
    {
        Block block = GetFirstBlockWithState(Block.BlockState.Available);
        if (block == null)
        {
            Debug.Log("Couldn't");
            return null;
        }
        Debug.Log("Creating Cube for Building");
        block.state = Block.BlockState.BuildingBlock;
        return block;
    }

    //TODO ^these really need to be combined to 1
    public Block CreateShootingCube()
    {
        Block block = GetFirstBlockWithState(Block.BlockState.Available);
        if (block == null)
        {
            Debug.Log("Couldn't");
            return null;
        }
        Debug.Log("Creating Cube for Shooting");
        block.state = Block.BlockState.ShootingBlock;
        return block;
    }
}