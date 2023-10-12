using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Spectre.Console.Cli;

namespace YouLoadr.CLI.Commands
{
    public class VideoMetadataCommandSettings : BaseVideoCommandSettings
    {
        public enum DataType
        {
            All,
            Video,
            Stream
        }

        [CommandOption("--type|-t")]
        public DataType MetadataType { get; set; } = DataType.Video;
    }

    public class VideoMetadataCommand : AsyncCommand<VideoMetadataCommandSettings>
    {
        public override Task<int> ExecuteAsync(CommandContext context, VideoMetadataCommandSettings settings)
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
