namespace Assets.Scripts.Settings
{
    class CameraSettings
    {
        #region Fields
        private const float INCREASE_SPEED = 0.5f;
        private const float GAME_DISTANCE = 8;
        private const float MAIN_MENU_DISTANCE = 10;
        #endregion
        #region Properties
        public static float GameDistance
        {
            get
            {
                return GAME_DISTANCE;
            }
        }
        public static float MainMenuDistance
{
            get
            {
                return MAIN_MENU_DISTANCE;
            }
        }
        public static float IncreaseSpeed
        {
            get
            {
                return INCREASE_SPEED;
            }
        }
        #endregion
    }
}
