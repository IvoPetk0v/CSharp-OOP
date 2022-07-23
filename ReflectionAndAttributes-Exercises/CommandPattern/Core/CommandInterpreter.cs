using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmd = args
                    .Split();
            string cmdName = cmd[0];
            string[] cmdArg = cmd
                    .Skip(1)
                    .ToArray();
            Assembly assembly = Assembly.GetCallingAssembly();
            Type cmdType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{cmdName}Command" && t.GetInterfaces().Any(i => i == typeof(ICommand)));
            if (cmdType==null)
            {
                throw new Exception("Wrong command");
            }
            object cmdInstance = Activator.CreateInstance(cmdType);
            MethodInfo executeMethod = cmdType.GetMethods().FirstOrDefault(m => m.Name == "Execute");
            string result = (string)executeMethod.Invoke(cmdInstance, new object[] { cmdArg });
            return result;

        }
    }
}
