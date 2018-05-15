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
    }
}