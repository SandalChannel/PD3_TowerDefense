using Codice.Client.BaseCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    public static class CommandHistory
    {
        public static List<ICommand> ReplayStack { get; private set; } = new List<ICommand>();

        public static void ExecuteCommand(ICommand command)
        {
            command.Execute();
            ReplayStack.Add(command);
        }
        
        public static void ReplayCommand(ICommand command)
        {
            if (ReplayStack.Count <= 0)
                return;

            //ICommand command = ReplayStack.Pop();
            command.Execute();
        }

        public static void ClearCommandStack()
        {
            ReplayStack.Clear();
        }
    }
}
