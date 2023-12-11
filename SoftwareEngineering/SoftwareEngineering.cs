using static Funcs.Funcs;
using static Funcs.MyFuncs;

namespace SoftwareEngineering
{
    internal class SoftwareEngineering
    {
        static void Main()
        {
            Console.Write("Первые 10 чисел последовательности Фибоначчи: ");
            PrintDList(FibList(10).First);
        }
    }
}