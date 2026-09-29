using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SoundCore.CustomStructures
{
    public class ListTAdapter<T> : IDJStructure<T>
    {
        private readonly List<T> _list = new List<T>();

        public int Quantity => _list.Count;
        public bool ItIsEmpty => _list.Count == 0;

        public T First => _list.Count > 0
            ? _list[0]
            : throw new InvalidOperationException("The list is empty.");

        public void AddAtTheEnd(T value) => _list.Add(value);
        public void Remove(T item)
        {
            _list.Remove(item);
        }
        public void PlayNext(T value)
        {
            if (_list.Count == 0)
                _list.Add(value);
            else
                _list.Insert(1, value);   
        }

        public T AdvanceTrack()
        {
            if (_list.Count == 0)
                throw new InvalidOperationException("The queue is empty. There is no track to advance.");

            var value = _list[0];
            _list.RemoveAt(0);
            return value;
        }

        public void Invert() => _list.Reverse();

        public void OrderInsert(T value, Comparison<T> comparer)
        {
            int i = 0;
            while (i < _list.Count && comparer(value, _list[i]) >= 0)
                i++;

            _list.Insert(i, value);
        }

        public void Order(Comparison<T> comparer)
        {
            var sorted = _list.OrderBy(x => x, Comparer<T>.Create(comparer)).ToList();
            _list.Clear();
            _list.AddRange(sorted);
        }

        public void PurgeDuplicates(Func<T, T, bool> areEqual)
        {
            for (int i = 0; i < _list.Count; i++)
            {
                for (int j = _list.Count - 1; j > i; j--)
                {
                    if (areEqual(_list[i], _list[j]))
                        _list.RemoveAt(j);
                }
            }
        }

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}