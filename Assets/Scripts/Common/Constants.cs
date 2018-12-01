using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Common
{
    public static class Constants
    {
        public enum Coords : int
        {
            x = 0,
            z = 1,
            y = 2
        }

        //if you have a problem with these not being constant, stiff
        public static float[] BLOCK_PLACE_SPEED = { 1f, 1f, 1f };
        public static float[] BLOCK_BOUNDS_UPPER = { 20f, 10f, 500f };
        public static float[] BLOCK_BOUNDS_LOWER = { -20f, -10f, -2f };

    }
}
