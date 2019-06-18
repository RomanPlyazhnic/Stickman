namespace Assets.Scripts
{
    interface IStorage<T, F> where F : UnityEngine.Object
    {
        void Add(F obj);
        void Remove(T obj);
        void RemoveAll();
    }
}
