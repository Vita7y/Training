using System;

namespace CodeTrain.DataAlg
{
    public class VStack<T> where T: IComparable<T>
    {
        private T[] _arr;
        private int _point;
        private T _min;

        public VStack():this(42)
        {
        }

        public VStack(int len)
        {
            _arr = new T[len];
            _point = -1;
        }

        public int Count()
        {
            return _point;
        }

        public void Push(T item)
        {
            if (_arr.Length >= _point + 1)
            {
                var newArr = new T[_arr.Length * 2];
                _arr.CopyTo(newArr,0);
                _arr = newArr;
            }

            if (_point == -1 || item.CompareTo(_min) == -1)
                _min = item;
            _arr[++_point] = item;
        }

        public T Pop()
        {
            if (_point < 0)
                throw new IndexOutOfRangeException();
            return _arr[_point--];
        }

        public T Min()
        {
            return _min;
        }
    }
}