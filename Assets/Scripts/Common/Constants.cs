using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Common
{
    public static class Constants
    {

        public static class BlockPlaceSpeed
        {
            public static float x = 1f;
            public static float z = 1f;
            public static float y = 1f;
            public static float r = 50f;
        }

        public static class BlockBounds
        {
            public static class Upper
            {
                public static float x = 20f;
                public static float z = 10f;
                public static float y = 500f;
            }

            public static class Lower
            {
                public static float x = -20f;
                public static float z = -10f;
                public static float y = -2f;
            }
        }

        public static class Tags
        {
            public static string soundManager = "SoundManager";
        }

        public enum Sounds : int
        {
            fire = 0,
            collide = 1,
            musicMenu = 2,
            musicGame = 3,
            blockDestroy = 4
        }

        public static Block.BlockState[] actionStates = { Block.BlockState.Available, Block.BlockState.BuildingBlock, Block.BlockState.ShootingBlock};


    }
}
