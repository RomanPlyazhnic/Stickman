namespace Assets.Scripts.Settings
{
    class StickSettings
    {
        #region Fields
        private const float CREATING_SPEED = 0.05f;
        private const float WIDTH = 0.1f;
        private const float HEIGHT_MARGIN = 0.5f;
        #endregion
        #region Properties
        public static float Width
        {
            get
            {
                return WIDTH;
            }
        }
        public static float MaxHeight
        {
            get
            {
                return BlockSettings.MaxWidth + BlockSettings.MaxDistance + HEIGHT_MARGIN;
            }
        }
        public static float CreatingSpeed
        {
            get
            {
                return CREATING_SPEED;
            }
        }
        #endregion
    }
}
