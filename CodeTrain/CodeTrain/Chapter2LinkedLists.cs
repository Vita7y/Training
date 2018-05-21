using System.Linq;
using CodeTrain.DataAlg;

namespace CodeTrain
{
    public class Chapter2LinkedLists
    {
        ///2 . 1 . Напишите код для удаления дубликатов из не сортированного связного списка.
        ///Дополнительно: Как вы будете решать задачу, если использовать временный буфер запрещено?
        public static string DeleteDublicate(string input)
        {
            var list = new VLinkedList<char>();
            foreach (var ch in input)
                list.Add(ch);

            foreach (var ch in list)
            {
                DeleteDublicateCharFromList(ch, list);
            }

            return list.Aggregate("", (first, next) => first + next);
        }

        private static void DeleteDublicateCharFromList(char ch, VLinkedList<char> list)
        {
            var node = list.Find(ch);
            VLinkedList<char>.Node last = list.FindLast(ch);
            while (node != last)
            {
                list.Delete(last);
                last = list.FindLast(ch);
            }
        }

        ///2.2. Реализуйте алгоритм для нахождения в односвязном списке k-го элемента с конца.
        public static T GetElementFromEnd<T>(VLinkedList<T> list, int numFromEnd)
        {
            var realNum = list.Count() - numFromEnd;
            var node = list.FirstNode();

            for (int i = 0; i < realNum-1; i++)
            {
                node = node.Next;
            }

            return node.Value;
        }
    }
}