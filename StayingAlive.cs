using System.Runtime.InteropServices;

//This will keep a pc alive and running so the scrren saver or sleep mode will not be activated.
//This is useful if you attached to a network where this is enforced. 

namespace StayingAlive
{
    internal class Program
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern EXECUTION_STATE SetThreadExecutionState(EXECUTION_STATE esFlags);

        [FlagsAttribute]
        private enum EXECUTION_STATE : uint
        {
            EsAwaymodeRequired = 0x00000040,
            EsContinuous = 0x80000000,
            EsDisplayRequired = 0x00000002,
            EsSystemRequired = 0x00000001
        }
        static void Main(string[] args)
        {
            SetThreadExecutionState(EXECUTION_STATE.EsSystemRequired | EXECUTION_STATE.EsDisplayRequired | EXECUTION_STATE.EsContinuous | EXECUTION_STATE.EsAwaymodeRequired);

            Console.WriteLine("Running");
            Console.ReadLine();
        }
    }
}