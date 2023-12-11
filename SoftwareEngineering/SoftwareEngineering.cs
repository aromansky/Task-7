using static Funcs.Funcs;
using static Funcs.MyFuncs;

namespace SoftwareEngineering
{
    internal class SoftwareEngineering
    {
        static void Main()
        {
            Console.Write("First 10 numbers in the Fibonacci sequence: ");
            PrintDList(FibList(10).First);
        }
    }
}
