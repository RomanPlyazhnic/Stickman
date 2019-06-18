using UnityEngine;

namespace Assets.Scripts.Instances
{
    public class Block
    {
        #region Properties
        public GameObject Item { get; set; }
        public bool IsPassed { get; set; }
        public bool HasStick { get; set; }
        public int Index { get; set; }
        #endregion
    }
}
