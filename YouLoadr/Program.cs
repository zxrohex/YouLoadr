using Spectre.Console.Cli;

using YouLoadr.CLI.Commands;

namespace YouLoadr
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var app = new CommandApp();

            app.Configure(c =>
            {
                c.AddBranch<BaseVideoCommandSettings>("video", vc =>
                {
                    vc.AddCommand<VideoMetadataCommand>("metadata");
                });
            });

            app.SetDefaultCommand<BaseVideoCommand>();

            await app.RunAsync(args);
        }
    }
}
