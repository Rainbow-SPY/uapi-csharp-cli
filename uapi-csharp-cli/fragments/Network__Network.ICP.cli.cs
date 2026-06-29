using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_ICP
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_network_icp_info_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "icp-info" });
            cmd_network_icp_info_1.Description = "查询ICP备案信息";
            var opt_network_icp_info_1_domain = new Option<string>("--domain")
            {
                Required = true, Description = "要查询的主机"
            };
            cmd_network_icp_info_1.Options.Add(opt_network_icp_info_1_domain);
            cmd_network_icp_info_1.SetAction(parseResult =>
            {
                var domain = parseResult.GetValue(opt_network_icp_info_1_domain);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.GetICPInfo(domain, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}