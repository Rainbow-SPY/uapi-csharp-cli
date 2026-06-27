using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_Ping
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_network_ping_delay_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "ping-delay" });
            cmd_network_ping_delay_1.Description = "获取从 UAPI 到指定主机的延迟";
            var opt_network_ping_delay_1_host = new Option<string>("--host")
            {
                Required = true, Description = "指定要查询的主机"
            };
            cmd_network_ping_delay_1.Options.Add(opt_network_ping_delay_1_host);
            cmd_network_ping_delay_1.SetAction(async parseResult =>
            {
                var host = parseResult.GetValue(opt_network_ping_delay_1_host);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Network.GetPingDelay(host, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}