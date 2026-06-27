using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_IPInfo
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_network_ip_info_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "ip-info" });
            cmd_network_ip_info_1.Description = "查询IP的相关信息";
            var opt_network_ip_info_1_ip = new Option<string>("--ip")
            {
                Required = true, Description = "指定要查询的IP地址"
            };
            cmd_network_ip_info_1.Options.Add(opt_network_ip_info_1_ip);
            var opt_network_ip_info_1_IsUseCommercial = new Option<bool>("--is-use-commercial")
            {
                Required = false, Description = "是否使用商业数据源", DefaultValueFactory = _ => false
            };
            cmd_network_ip_info_1.Options.Add(opt_network_ip_info_1_IsUseCommercial);
            cmd_network_ip_info_1.SetAction(async parseResult =>
            {
                var ip = parseResult.GetValue(opt_network_ip_info_1_ip);
                var IsUseCommercial = parseResult.GetValue(opt_network_ip_info_1_IsUseCommercial);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Network.GetIPInfo(ip, IsUseCommercial, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}