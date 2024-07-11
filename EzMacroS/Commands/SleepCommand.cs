using System.Threading;

namespace EzMacroS.Commands
{
    public class SleepCommand : ICommand
    {
        public SleepCommand(int sleepTime)
        {
            SleepTime = sleepTime;
        }

        public int SleepTime { get; }

        public void Execute()
        {
            Thread.Sleep(SleepTime);
        }
    }
}