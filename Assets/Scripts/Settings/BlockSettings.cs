namespace Assets.Scripts.Settings
{
    class BlockSettings
    {
        #region Fields
        private const float FIRST_BLOCK_WIDTH = 20;
        private const float FIRST_BLOCK_X_POS = -11.863f;
        private const float Y_POS = -6.373f;
        private const float MIN_DISTANCE = 2;
        private const float MAX_DISTANCE = 7;
        private const float MIN_WIDTH = 1.5f;
        private const float MAX_WIDTH = 2.5f;
        private const int MAX_COUNT = 10;
        private const int MAX_PASSED_COUNT = 5;
        private const float HEIGHT = 13;
        #endregion
        #region Properties
        public static float FirstBlockWidth
        {
            get
            {
                return FIRST_BLOCK_WIDTH;
            }
        }
        public static float FirstBlockXPos
        {
            get
            {
                return FIRST_BLOCK_X_POS;
            }
        }
        public static float YPos {
            get
            {
                return Y_POS;
            }
        }
        public static float MinDistance
        {
            get
            {
                return MIN_DISTANCE;
            }
        }
        public static float MaxDistance
        {
            get
            {
                return MAX_DISTANCE;
            }
        }
        public static float MinWidth
        {
            get
            {
                return MIN_WIDTH;
            }
        }
        public static float MaxWidth
        {
            get
            {
                return MAX_WIDTH;
            }
        }
        public static int MaxCount
        {
            get
            {
                return MAX_COUNT;
            }
        }
        public static int MaxPassedCount
        {
            get
            {
                return MAX_PASSED_COUNT;
            }
        }
        public static float Height
        {
            get
            {
                return HEIGHT;
            }
        }
        #endregion
    }
}
