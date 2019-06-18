namespace Assets.Scripts.Settings
{
    class PlayerSettings
    {
        #region Fields
        private const float DEFAULT_SPEED = 5;
        private const float SIZE = 0.3f;
        private const float DEFAULT_X_POS = -8;
        private const float MARGIN_FROM_STICK = 0.9f;
        #endregion
        #region Properties
        public static float Size
        {
            get
            {
                return SIZE;
            }
        }
        public static float MarginFromStick
        {
            get
            {
                return MARGIN_FROM_STICK;
            }
        }
        public static float DefaultXPos
        {
            get
            {
                return DEFAULT_X_POS;
            }
        }
        public static float DefaultYPos
        {
            get
            {
                return BlockSettings.YPos + BlockSettings.Height / 2 + SIZE / 2;
            }
        }
        public static float PlayerEndGameYPos
        {
            get
            {
                return DefaultYPos - 2.5f;
            }
        }
        public static float Speed { get; private set; }
        #endregion
        #region Public methods
        static PlayerSettings()
        {
            ResetSpeed();
        }


        public static void ResetSpeed()
        {
            Speed = 0;
        }


        public static void SetSpeed()
        {
            Speed = DEFAULT_SPEED;
        }
        #endregion
    }
}
