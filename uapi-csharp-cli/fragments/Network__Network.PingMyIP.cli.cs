using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_PingMyIP
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "network", "ping-my-ip" });
            o.Description = "Ping 我的 IP, 返回检测到的IP地址 注意! IPv6 Ping失败为已知问题, 请耐心等待修复";
            o.SetAction(parseResult =>
            {
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Network.PingMyIP(AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}