namespace Assets.Scripts.Settings
{
    class BonusSettings
    {
        #region Fields
        private const int SCORE = 100;
        private const float SIZE = 0.6f;
        #endregion
        #region Properties
        public static int Score
        {
            get
            {
                return SCORE;
            }
        }
        public static float Size
        {
            get
            {
                return SIZE;
            }
        }
        #endregion
    }
}
