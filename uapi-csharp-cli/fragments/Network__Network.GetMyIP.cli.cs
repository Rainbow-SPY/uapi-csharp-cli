using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_GetMyIP
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_network_my_ip_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "my-ip" });
            cmd_network_my_ip_1.Description = "获取本机的IP地址";
            var opt_network_my_ip_1_commercial = new Option<bool>("--commercial")
            {
                Required = false, Description = "指定是否使用商业级的数据源, 默认为 false", DefaultValueFactory = _ => false
            };
            cmd_network_my_ip_1.Options.Add(opt_network_my_ip_1_commercial);
            cmd_network_my_ip_1.SetAction(parseResult =>
            {
                var commercial = parseResult.GetValue(opt_network_my_ip_1_commercial);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.GetMyIP(commercial, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}