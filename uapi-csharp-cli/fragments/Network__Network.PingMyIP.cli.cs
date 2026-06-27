using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_PingMyIP
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_network_ping_my_ip_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "ping-my-ip" });
            cmd_network_ping_my_ip_1.Description = "Ping 我的 IP, 返回检测到的IP地址 注意! IPv6 Ping失败为已知问题, 请耐心等待修复";
            cmd_network_ping_my_ip_1.SetAction(async parseResult =>
            {
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = await Network.PingMyIP(AuthenticationAPITokenKey);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}