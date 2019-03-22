using System;

namespace Assets.Scripts.BlockFactories
{
    public class AbstractBlockFactory
    {
        protected Func<int, Block> _blockCreationFunc;
        public Block CreateBlock(int seed)
        {
            return _blockCreationFunc.Invoke(seed);
        }

        public Block CreateBlockWithState(int seed, Block.BlockState state)
        {
            Block result = _blockCreationFunc.Invoke(seed);
            result.state = state;
            return result;
        }
    }
}
