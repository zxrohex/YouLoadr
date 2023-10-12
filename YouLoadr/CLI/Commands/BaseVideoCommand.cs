using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Spectre.Console.Cli;

namespace YouLoadr.CLI.Commands
{
    public class BaseVideoCommandSettings : CommandSettings
    {
        [CommandArgument(0, "<url>")]
        public string Url { get; set; }
    }

    public class BaseVideoCommand : AsyncCommand<BaseVideoCommandSettings>
    {
        public override Task<int> ExecuteAsync(CommandContext context, BaseVideoCommandSettings settings)
        {
            Type t = settings.GetType();
            PropertyInfo[] props = t.GetProperties();
            foreach (PropertyInfo prop in props)
            {
                Console.WriteLine("{0} = {1}", prop.Name, prop.GetValue(settings, null));
            }

            return Task.FromResult(0);
        }
    }
}
