using static Funcs.Funcs;
using static Funcs.MyFuncs;

namespace SoftwareEngineering
{
    internal class SoftwareEngineering
    {
        static void Main()
        {
            try
            {
                Console.Write("First 10 numbers in the Fibonacci sequence: ");
                PrintDList(FibList(-10).First);
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Something goes wrong\n");
                Console.Write("A task has been created in Yandex Tracker\n");
                TaskController.PostTask(TaskController.httpClient);
            }
        }
    }
}
