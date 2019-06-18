using UnityEngine;

namespace Assets.Scripts.Instances
{
    public class Stick
    {
        #region Properties
        public GameObject Item { get; set; }
        public bool IsPassed { get; set; }
        public int Index { get; set; }
        public bool IsPlayerCanMove { get; set; }
        public bool IsMade { get; set; }
        #endregion
    }
}
