using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_GetMyIP
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_network_my_ip_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "my-ip" });
            cmd_network_my_ip_1.Description = "获取本机的IP地址";
            var opt_network_my_ip_1_commercial = new Option<bool>("--commercial")
            {
                Required = false, Description = "指定是否使用商业级的数据源, 默认为 false", DefaultValueFactory = _ => false
            };
            cmd_network_my_ip_1.Options.Add(opt_network_my_ip_1_commercial);
            cmd_network_my_ip_1.SetAction(async parseResult =>
            {
                var commercial = parseResult.GetValue(opt_network_my_ip_1_commercial);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Network.GetMyIP(commercial, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}