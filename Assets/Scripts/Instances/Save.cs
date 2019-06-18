using System;

namespace Assets.Scripts.Instances
{
    [Serializable]
    public static class Save
    {
        #region Fields
        public static string BestScore;
        #endregion
        #region Public methods
        static Save()
        {
            BestScore = string.Empty;
            Game.LoadGame();
        }
        #endregion
    }
}
