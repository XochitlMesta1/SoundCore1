using System;
using System.Collections;
using System.Collections.Generic;

namespace SoundCore.CustomStructures
{
   
    public class SinglyLinkedList<T> : IDJStructure<T>
    {
        internal Node<T> Head { get; private set; }
        internal Node<T> Tail { get; private set; }
        public int Quantity { get; private set; }
        public bool ItIsEmpty => Head is null;

        public T First => Head is null
            ? throw new InvalidOperationException("The list is empty.")
            : Head.Data;

        public void AddAtTheEnd(T value)
        {
            var newNode = new Node<T>(value);

            if (Head is null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }

            Quantity++;
        }

        public void PlayNext(T value)
        {
            var newNode = new Node<T>(value);

            if (Head is null)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head.Next;
                Head.Next = newNode;

                if (Tail == Head)
                    Tail = newNode;
            }

            Quantity++;
        }

        public T AdvanceTrack()
        {
            if (Head is null)
                throw new InvalidOperationException("The queue is empty. There is no track to advance.");

            var value = Head.Data;
            Head = Head.Next;

            if (Head is null)
                Tail = null;

            Quantity--;
            return value;
        }


        public void Invert()
        {
            Node<T> previous = null;
            Node<T> current = Head;

            Tail = Head;

            while (current != null)
            {
                Node<T> next = current.Next;

                current.Next = previous;

                previous = current;
                current = next;
            }

            Head = previous;
        }
        public void OrderInsert(T value, Comparison<T> comparer)
        {
            InsertNodeOrdered(new Node<T>(value), comparer);
            Quantity++;
        }
        public void Remove(T item)
        {
            if (Head == null)
                return;

            if (EqualityComparer<T>.Default.Equals(Head.Data, item))
            {
                Head = Head.Next;
                Quantity--;

                if (Quantity == 0)
                    Tail = null;

                return;
            }

            Node<T> current = Head;

            while (current.Next != null)
            {
                if (EqualityComparer<T>.Default.Equals(current.Next.Data, item))
                {
                    if (current.Next == Tail)
                        Tail = current;

                    current.Next = current.Next.Next;
                    Quantity--;
                    return;
                }

                current = current.Next;
            }
        }
        public void Order(Comparison<T> comparer)
        {
            Node<T> pending = Head;
            Head = null;
            Tail = null;

            while (pending != null)
            {
                Node<T> node = pending;
                pending = pending.Next;
                node.Next = null;
                InsertNodeOrdered(node, comparer);
            }
            
        }

        private void InsertNodeOrdered(Node<T> newNode, Comparison<T> comparer)
        {
            if (Head is null)
            {
                Head = newNode;
                Tail = newNode;
                return;
            }

            if (comparer(newNode.Data, Head.Data) < 0)
            {
                newNode.Next = Head;
                Head = newNode;
                return;
            }

            var current = Head;
            while (current.Next != null && comparer(newNode.Data, current.Next.Data) >= 0)
                current = current.Next;

            newNode.Next = current.Next;
            current.Next = newNode;

            if (newNode.Next is null)
                Tail = newNode;
        }

        public void PurgeDuplicates(Func<T, T, bool> areEqual)
        {
            var current = Head;

            while (current != null)
            {
                var runner = current;

                while (runner.Next != null)
                {
                    if (areEqual(current.Data, runner.Next.Data))
                    {
                        runner.Next = runner.Next.Next;   
                        Quantity--;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }

            if (Head is null)
            {
                Tail = null;
            }
            else
            {
                var node = Head;
                while (node.Next != null)
                    node = node.Next;
                Tail = node;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}