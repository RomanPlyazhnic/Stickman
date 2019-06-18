using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Instances
{
    public class BonusStorage : IStorage<Bonus, GameObject>
    {
        #region Fields
        private static BonusStorage bonusStorage;
        

        public delegate void deleteDelegate(GameObject block);
        public delegate void deleteDelegateAll();
        public event deleteDelegate OnRemove;
        public event deleteDelegateAll OnRemoveAll;


        private int index;
        #endregion
        #region Properties
        public List<Bonus> Objects { get; set; }
        #endregion
        #region IStorage
        public void Add(GameObject bonus)
        {
            Objects.Add(new Bonus()
            {
                Item = bonus,
                Index = ++index
            });
            bonus.name += index.ToString();
        }


        public void Remove(Bonus bonus)
        {
            try
            {
                OnRemove(bonus.Item);
                Objects.RemoveAt(bonus.Index - 1);
            }
            catch
            {

            }
        }


        public void RemoveAll()
        {
            OnRemoveAll();
            Objects.Clear();
            index = 0;
            Objects = new List<Bonus>();
        }
        #endregion
        #region Public methods
        public static BonusStorage GetInstance()
        {
            if (bonusStorage == null)
                bonusStorage = new BonusStorage();
            return bonusStorage;
        }
        #endregion
        #region Private methods
        private BonusStorage()
        {
            index = 0;
            Objects = new List<Bonus>();
        }
        #endregion
    }
}
