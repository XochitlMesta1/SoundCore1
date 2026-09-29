using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SoundCore.CustomStructures
{
    public class LinkedListAdapter<T> : IDJStructure<T>
    {
        private readonly LinkedList<T> _list = new LinkedList<T>();

        public int Quantity => _list.Count;
        public bool ItIsEmpty => _list.Count == 0;

        public T First => _list.First != null
            ? _list.First.Value
            : throw new InvalidOperationException("The list is empty.");

        public void AddAtTheEnd(T value) => _list.AddLast(value);

        public void PlayNext(T value)
        {
            if (_list.First == null)
                _list.AddFirst(value);
            else
                _list.AddAfter(_list.First, value);
        }

        public T AdvanceTrack()
        {
            if (_list.First == null)
                throw new InvalidOperationException("The queue is empty. There is no track to advance.");

            var value = _list.First.Value;
            _list.RemoveFirst();
            return value;
        }

        public void Invert()
        {
            var elements = new T[_list.Count];
            _list.CopyTo(elements, 0);
            _list.Clear();

            for (int i = elements.Length - 1; i >= 0; i--)
                _list.AddLast(elements[i]);
        }

        public void OrderInsert(T value, Comparison<T> comparer)
        {
            var node = _list.First;
            while (node != null && comparer(value, node.Value) >= 0)
                node = node.Next;

            if (node == null)
                _list.AddLast(value);
            else
                _list.AddBefore(node, value);
        }

        public void Order(Comparison<T> comparer)
        {
            var sorted = _list.OrderBy(x => x, Comparer<T>.Create(comparer)).ToList();
            _list.Clear();
            foreach (var item in sorted)
                _list.AddLast(item);
        }
        public void Remove(T item)
        {
            var node = _list.Find(item);

            if (node != null)
                _list.Remove(node);
        }
        public void PurgeDuplicates(Func<T, T, bool> areEqual)
        {
            var node = _list.First;
            while (node != null)
            {
                var other = node.Next;
                while (other != null)
                {
                    var nextOther = other.Next;
                    if (areEqual(node.Value, other.Value))
                        _list.Remove(other);
                    other = nextOther;
                }
                node = node.Next;
            }
        }

        public IEnumerator<T> GetEnumerator() => _list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}