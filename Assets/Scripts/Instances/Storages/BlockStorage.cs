using Assets.Scripts.Instances;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class BlockStorage: IStorage<Block, GameObject>
    {
        #region Fields
        private static BlockStorage blockStorage;

                
        public delegate void deleteDelegate(GameObject block);
        public delegate void deleteDelegateAll();
        public event deleteDelegate OnRemove;
        public event deleteDelegateAll OnRemoveAll;


        private int index;
        #endregion
        #region Properties
        public List<Block> Objects { get; set; }
        #endregion
        #region IStorage
        public void Add(GameObject block)
        {
            Objects.Add(new Block()
            {
                Item = block,
                IsPassed = false,
                HasStick = false,
                Index = ++index
            });
            block.name += index.ToString();
        }


        public void Remove(Block block)
        {
            var stickToRemove = Storages.Sticks.Objects.FirstOrDefault(x => x.Index == block.Index);
            if (stickToRemove != null)
                Storages.Sticks.Remove(stickToRemove);
            OnRemove(block.Item);
            Objects.RemoveAt(block.Index - 1);
        }


        public void RemoveAll()
        {
            OnRemoveAll();
            Objects.Clear();
            Objects = new List<Block>();
            index = 0;
        }
        #endregion
        #region Public methods
        public static BlockStorage GetInstance()
        {
            if (blockStorage == null)
                blockStorage = new BlockStorage();
            return blockStorage;
        }
        #endregion
        #region Private methods
        private BlockStorage()
        {
            index = 0;
            Objects = new List<Block>();
        }
        #endregion
    }
}
