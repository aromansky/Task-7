namespace Funcs
{
    public static class MyFuncs
    {
        /// <summary>
        /// Создает двусвязный список целых чисел по массиву
        /// </summary>
        /// <param name="arr">Массив целых чисел</param>
        /// <returns>Двусвязный список целых чисел</returns>
        public static LinkedList<T> CreateDList<T>(params T[] arr) => new LinkedList<T>(arr);

        /// <summary>
        /// Печатает двусвязный список целых чисел
        /// </summary>
        /// <param name="head">Указатель на голову списка</param>
        public static void PrintDList(LinkedListNode<int> head)
        {
            if (head != null)
            {
                Console.Write($"{head.Value} ");
                PrintDList(head.Next);
            }
            else Console.WriteLine();
        }
    }
    public class Funcs
    {
        /// <summary>
        /// Сумма всех вещественных чисел A, A + h, A + 2h , … в диапазоне [A, B], удовлетворяющих заданному предикату.
        /// </summary>
        /// <param name="a">A</param>
        /// <param name="b">B</param>
        /// <param name="h">h</param>
        /// <param name="pred">Предикат</param>
        /// <returns></returns>
        public static double SumAH(double a, double b, double h, Predicate<double> pred)
        {
            if (a > b) 
                (a, b) = (b, a);

            if (h == 0)
                throw new ArgumentException();

            double Sum(int n = 0)
            {
                var s = a + n * h;
                if (s > b) return 0;
        
                return pred(s) ? s + Sum(++n) : Sum(++n);
            }

            return Sum();
        }



        /// <summary>
        /// Определяет, является ли строка палиндромом.
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns>true в члучае, если строка является палиндромом. else - иначе</returns>
        public static bool IsPalindrom(string s)
        {
            if (s == String.Empty) return true;
            if (s.Length == 1) return true;

            bool IsPalindromRec(int l, int r)
            {
                if (s[l] != s[r]) return false;
                if (l >= r) return true;
                return IsPalindromRec(l + 1, r - 1);
            }

            return IsPalindromRec(0, s.Length - 1);
        }

        /// <summary>
        /// Вывод разрядов числа.
        /// </summary>
        /// <param name="n">Число.</param>
        public static void PrintDigits(int n)
        {
            n = Math.Abs(n);

            if (n > 9)
            {
                PrintDigits(n / 10);
                Console.Write($", {n % 10}");
            }
            else
                Console.Write(n);
        }


        /// <summary>
        /// Максимальный элемент массива. Если масив пуст - int.MinValue.
        /// </summary>
        /// <param name="arr">Массив целых чисел.</param>
        /// <returns>Максимальный элемент.</returns>
        public static int MaxElem(int[] arr)
        {
            if (arr == null || arr.Count() == 0) return int.MinValue;

            int FindMax(int n)
            {
                if (n == arr.Length - 1) return arr[n];
                return Math.Max(arr[n], FindMax(++n));
            }

            return FindMax(0);
        }

        // <summary>
        /// Возвращает максимальный эдемент связанного списка.
        /// </summary>
        /// <param name="lst">Линейный односвязный список</param>
        /// <returns>Первый элемент с максимальным значением</returns>
        public static LinkedListNode<double> MaxElem(LinkedList<double> lst)
        {
            LinkedListNode<double> FindMax(LinkedListNode<double> head)
            {
                if (head == null) return null;
                var node = FindMax(head.Next);

                return head.Value >= (node?.Value ?? double.MinValue) ? head : node;
            }

            return FindMax(lst.First);
        }



        /// <summary>
        /// Возвращает первый элемент, удовлетворяющий предикату.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst">Линейный односвязный список</param>
        /// <param name="pred">Предикат</param>
        /// <returns>Первый элемент, удовлетворяющий предикату</returns>
        public static LinkedListNode<T> FirstPredElem<T>(LinkedList<T> lst, Predicate<T> pred)
        {
            LinkedListNode<T> FindPredElem(LinkedListNode<T> head)
            {
                if (head == null) return null;
                return pred(head.Value) ? head : FindPredElem(head.Next);
            }

            return FindPredElem(lst.First);
        }


        /// <summary>
        /// Возвращает количество элементов, удовлетворяющих предикату.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lst">Линейный односвязный список</param>
        /// <param name="pred">Предикат</param>
        /// <returns>Количество элементов, удовлетворяющих предикату</returns>
        public static int CountPredElems<T>(LinkedList<T> lst, Predicate<T> pred)
        {
            int CountPred(LinkedListNode<T> head)
            {
                if (head == null) return 0;
                return (pred(head.Value) ? 1 : 0) + CountPred(head.Next);
            }

            return CountPred(lst.First);
        }
        /// <summary>
        /// Проверяет, начинается ли первый список со второго.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="l1">Первый список</param>
        /// <param name="l2">Втрой спиков</param>
        /// <returns>true, если начинается. false - иначе</returns>
        public static bool StartWith<T>(LinkedList<T> l1, LinkedList<T> l2)
        {
            if (l2 == null) return true;

            bool StartFind(LinkedListNode<T> head1, LinkedListNode<T> head2)
            {
                if (head1 == null && head2 != null) return false;
                if (head2 == null) return true;
                if (!head1.Value.Equals(head2.Value)) return false;
                return StartFind(head1.Next, head2.Next);
            }

            return StartFind(l1.First, l2.First);
        }



        /// <summary>
        /// Возвращает ссылку на голову списка, содержащего первые N чиел последовательности Фибоначчи.
        /// </summary>
        /// <param name="n">N</param>
        /// <returns>Односвязный список, содержащий числа Фибоначчи</returns>
        public static LinkedList<int> FibList(int n)
        {
            if (n < 0)
                throw new ArgumentException("Нельзя посчитать отрицательное количесвто чисел Фибоначчи.");
            if (n == 0) return null;

            var res = MyFuncs.CreateDList(0);

            void BuildList(LinkedList<int> lst, int n, int a = 0, int b = 1)
            {
                if (n == 1) return;
                lst.AddLast(b);

                BuildList(lst, --n, b, a + b);
            }
            BuildList(res, n);
            return res;
        }
    }
}
