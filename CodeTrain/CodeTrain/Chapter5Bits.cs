namespace CodeTrain
{
    public class Chapter5Bits
    {

        /// <summary>
        /// 5.1. Даны два 32-разрядных числа N и М и  две позиции битов i и j.
        ///Напишите метод для вставки м в  N так, чтобы число М занимало позицию с бита j по бит i.
        ///Предполагается, что j и i имеют такие значения, что число М гарантированно поместится в этот промежуток.
        ///Скажем, для М = 10011 можно считать, что j и i разделены как минимум 5 битами.
        ///Комбинация вида j = з и i = 2 невозможна, так как число М не поместится между битом 3 и битом 2.
        ///Пример:
        ///Ввод: N = 10000000000, М = 10011, i = 2, j = 6
        ///Вывод: N = 10001001100
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        public static bool InsertBitsIntoNumber(int n, int m, int i, int j, out int res)
        {
            res = n;

            int lastBitNum = 0;
            int tmp = m;
            for (int ii = 0; ii < 32; ii++)
            {
                if ((tmp & 1) == 1)
                    lastBitNum = ii;
                tmp = tmp >> 1;
            }

            if (lastBitNum > (j - i))
                return false;

            res = res >> j;
            res = res << j - i;
            res ^= m;
            res = res << i;
            res ^= n;

            return true;
        }
    }
}