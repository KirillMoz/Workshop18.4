using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeCommandExample
{
    public class Command
    {
        public async Task ExecuteCommand(ICommand command)
        {
            await command.Execute();
        }
    }
}
