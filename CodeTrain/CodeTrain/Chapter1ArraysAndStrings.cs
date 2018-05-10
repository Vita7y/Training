using System.Text;

namespace CodeTrain
{
    public class Chapter1ArraysAndStrings
    {
		///1.1 Реализуйте алгоритм, определяющий, все л и символы в строке встречаются
		///только один раз. А если при этом запрещено использование дополнительных
		///структур данных?
        public bool CharsCounter_AllCharsUnique(string input)
        {
            var arr = new int[char.MaxValue];
            foreach (var ch in input)
            {
                arr[ch]++;
                if (arr[ch] > 1)
                    return false;
            }

            return true;
        }

		///1.2. Для двух строк напишите метод, определяющий, является ли одна строка перестановкой другой
        public bool CharsCounter_AllCharsUnique2(string input)
        {
            var str = Sort(input.ToCharArray());

            char tmp = '\0';
            foreach (var ch in str)
            {
                if (ch == tmp)
                    return false;
                tmp = ch;
            }

            return true;
        }

        public char[] Sort(string arr)
        {
            return Sort(arr.ToCharArray());
        }

        public char[] Sort(char[] arr)
        {
            var tmp = new char[arr.Length];
            arr.CopyTo(tmp,0);

            for (int i = 0; i < tmp.Length; i++)
            {
                for (int j = tmp.Length - 1; j >= 0; j--)
                {
                    if (i < j && tmp[i] > tmp[j])
                    {
                        char c = tmp[i];
                        tmp[i] = tmp[j];
                        tmp[j] = c;
                    }
                }
            }

            return tmp;
        }

        public bool CheckReversalStrings(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return false;
            if (str1.Length != str2.Length)
                return false;

            var j = str2.Length - 1;
            for (int i = 0; i < str1.Length; i++, j--)
            {
                if (str1[i] != str2[j])
                    return false;
            }

            return true;
        }

		///1.3. Напишите метод, заменяющий все пробелы в строке символами ' %20 ' . Можете
		///считать, что длина строки позволяет сохранить дополнительные символы,
		///а фактическая длина строки известна заранее.
        public string ReplaceBlanks(string str, char replace)
        {
            var sb = new StringBuilder();
            bool r = false;
            foreach (char c in str)
            {
                if (c.Equals(' '))
                {
                    r = true;
                    continue;
                }
                if(r)
                {
                    sb.Append(replace);
                    r = false;
                }
                sb.Append(c);
            }

            return sb.ToString();
        }

		///1.4. Напишите функцию, которая проверяет, является ли заданная строка перестановкой
		///палиндрома. ( Палиндром - слово или фраза, одинаково читающиеся
		///в прямом и обратном направлении; перестановка - строка, содержащая те
		///же символы в другом порядке.) Палиндром не ограничивается словами из
		///словаря.
        public bool CheckPalindrome(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return false;
            if (str1.Length != str2.Length)
                return false;

            var tmp = str2.ToCharArray();

            foreach (var ch in str1)
            {
                var find = false;
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (ch == tmp[i])
                    {
                        tmp[i] = (char) 0;
                        find = true;
                        break;
                    }
                }

                if (!find)
                    return false;
            }

            return true;
        }

		///1 .5. Существуют три вида модифицирующих операций со строками: вставка
		///символа, удаление символа и замена символа. Напишите функцию, которая
		///проверяет, находятся ли две строки на расстоянии одной модификации (или
		///нуля модификаций).
        public bool CheckOneModification(string str1, string str2)
        {
            if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
                return false;

            if (str1 == str2)
                return true;

            var countChange = 0;
            int j = 0;

            for (int i = 0; i < str1.Length; i++)
            {
                if (countChange > 1)
                    return false;

                if (j > str2.Length - 1)
                {
                    countChange++;
                    continue;
                }

                if (str1[i] == str2[j])
                {
                    j++;
                    continue;
                }

                countChange++;

                if (i < str1.Length-1
                   && str1[i+1] == str2[j])
                    continue;

                if (j < str2.Length-1 
                    && str1[i] != str2[j + 1])
                    j++;
            }

            return countChange < 2;
        }
    }
}