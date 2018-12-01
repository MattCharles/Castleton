using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Common
{
    public static class Constants
    {

        public static class BlockPlaceSpeed
        {
            public static float x = 1f;
            public static float z = 1f;
            public static float y = 1f;
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

    }
}
