using System;
using System.Collections.Generic;

namespace SoundCore.CustomStructures
{
    public interface IDJStructure<T> : IEnumerable<T>
    {
        int Quantity { get; }
        bool ItIsEmpty { get; }
        T First { get; }

        void AddAtTheEnd(T value);
        void PlayNext(T value);
        T AdvanceTrack();
        void Invert();
        void OrderInsert(T value, Comparison<T> comparer);
        void Order(Comparison<T> comparer);
        void PurgeDuplicates(Func<T, T, bool> areEqual);
         void Remove(T item);
    }
}