using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace CodeTrain.DataAlg
{
    public class VLinkedList<T>:IEnumerable<T>
    {
        public class Node
        {
            public Node Next;
            public Node Prev;
            public T Value;
        }

        private Node _first;
        private Node _last;
        private int _count;

        public VLinkedList()
        {
            _first = _last = null;
            _count = 0;
        }

        public void Add(IList<T> list)
        {
            foreach (var item in list)
            {
                Add(item);
            }
        }

        public void Add(T item)
        {
            _count++;
            var node = new Node()
            {
                Value = item,
                Prev = _last
            };

            if (_first == null)
                _first = node;
            if (_last != null)
                _last.Next = node;
            _last = node;
        }

        public void Delete(Node node)
        {
            _count--;

            if (node == _first)
                _first = node?.Next;
            if (node == _last)
                _last = node?.Prev;

            if (node.Next != null)
                node.Next.Prev = node.Prev;
            if (node.Prev != null)
                node.Prev.Next = node.Next;
        }

        public void Delete(T item)
        {
            var cur = _first;
            do
            {
                if (cur.Value.Equals(item))
                {
                    Delete(cur);
                    return;
                }

                cur = cur.Next;
            } while (cur!=null && !cur.Equals(_last));

            if (cur!=null
                &&cur.Value.Equals(item) 
                && cur == _last)
            {
                _count--;
                _last = cur.Prev;
                _last.Next = null;
            }

        }

        public int Count()
        {
            return _count;
        }

        public Node Find(T value)
        {
            var node = _first;
            for (int i = 0; i < _count; i++)
            {
                if (node.Value.Equals(value))
                    return node;
                node = node.Next;
            }
            return null;
        }

        public Node FindLast(T value)
        {
            var node = _last;
            for (int i = 0; i < _count; i++)
            {
                if (node.Value.Equals(value))
                    return node;
                node = node.Prev;
            }
            return null;
        }

        public T First()
        {
            if (_first == null)
                return default(T);
            return _first.Value;
        }

        public Node FirstNode()
        {
            return _first;
        }

        public T Last()
        {
            if (_last == null)
                return default(T);
            return _last.Value;
        }


        public IEnumerator<T> GetEnumerator()
        {
            var node = _first;
            for (int i = 0; i < _count; i++)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}