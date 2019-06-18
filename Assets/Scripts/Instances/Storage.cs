namespace Assets.Scripts.Instances
{
    class Storages
    {
        #region Properties
        public static StickStorage Sticks { get; set; }
        public static BlockStorage Blocks { get; set; }
        public static BonusStorage Bonuses { get; set; }
        #endregion
        #region Public methods
        static Storages()
        {
            Sticks = StickStorage.GetInstance();
            Blocks = BlockStorage.GetInstance();
            Bonuses = BonusStorage.GetInstance();
        }
        #endregion
    }
}
