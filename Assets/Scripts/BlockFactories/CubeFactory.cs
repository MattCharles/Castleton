namespace Assets.Scripts.BlockFactories
{
    public class CubeFactory : AbstractBlockFactory
    {
        public CubeFactory()
        {
            _blockCreationFunc = CreateCube;
        }

        public Block CreateCube(int seed)
        {
            return new Block();
        }

        public Block CreateCube(int seed, IActor owner)
        {
            return new Block()
            {
                owner = owner
            };
        }
    }
}
