using Assets.Scripts.Instances;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class StickStorage : IStorage<Stick, GameObject>
    {
        #region Fields
        private static StickStorage stickStorage;
        

        public delegate void deleteDelegate(GameObject block);
        public delegate void deleteDelegateAll();
        public event deleteDelegate OnRemove;
        public event deleteDelegateAll OnRemoveAll;

        
        private int index;
        #endregion
        #region Properties
        public List<Stick> Objects { get; set; }
        public bool IsIncreasingStick { get; set; }
        public bool IsAbleToIncrease { get; set; }
        #endregion
        #region IStorage
        public void Add(GameObject stick)
        {
            Objects.Add(new Stick()
            {
                Item = stick,
                IsPassed = false,
                Index = ++index,
                IsPlayerCanMove = false,
                IsMade = false
            });
            stick.name += index.ToString();
        }


        public void Remove(Stick stick)
        {
            try
            {
                OnRemove(stick.Item);
                Objects.RemoveAt(stick.Index - 1);
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
            IsIncreasingStick = false;
            IsAbleToIncrease = true;
            Objects = new List<Stick>();
        }
        #endregion
        #region Public methods
        public static StickStorage GetInstance()
        {
            if (stickStorage == null)
                stickStorage = new StickStorage();
            return stickStorage;
        }
        #endregion
        #region Private methods
        private StickStorage()
        {
            index = 0;
            IsIncreasingStick = false;
            IsAbleToIncrease = true;
            Objects = new List<Stick>();
        }
        #endregion
    }
}
