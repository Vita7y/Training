using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace CodeTrain.DataAlg
{
    public class VLinkedList<T>
    {
        public struct Leave
        {
            public Leave? Next;
            public Leave? Prev;
            public T Value;
        }

        private Leave _list;
        private Leave _first;
        private Leave _last;
        private int _count;

        public VLinkedList()
        {
            _list = new Leave();
            _first = _last = _list;
            _count = 0;
        }

        public void Add(T item)
        {
            _count++;
            var leave = new Leave()
            {
                Value = item,
                Prev = _last
            };
            if (_first.Prev == null)
                _first = leave;
            _last.Next = leave;
            _last = leave;
        }

        public void Delete(T item)
        {
            var cur = _first;
            while (!cur.Equals(_last))
            {
                if (cur.Value.Equals(item))
                {
                    _count--;
                    if (cur.Prev != null)
                    {
                        var lh = cur.Prev.Value;
                        lh.Next = cur.Next;
                    }

                    return;

                }
            }
        }

        public int Count()
        {
            return _count;
        }

        public T First()
        {
            return _first.Value;
        }

        public T Last()
        {
            return _last.Value;
        }
    }
}