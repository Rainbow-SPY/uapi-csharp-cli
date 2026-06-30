using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_Ping
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "network", "ping" });
            o.Description = "获取从 UAPI 到指定主机的延迟";
            var ip = new Option<string>("--host")
            {
                Required = true, Description = "指定要查询的主机"
            };
            o.Options.Add(ip);
            o.SetAction(parseResult =>
            {
                var host = parseResult.GetValue(ip);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.GetPingDelay(host, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}