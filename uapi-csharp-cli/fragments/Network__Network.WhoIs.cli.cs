using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_WhoIs
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_network_whois_info_as_text_1 =
                CliCommandTree.GetOrAdd(root, new[] { "network", "whois-info", "as-text" });
            cmd_network_whois_info_as_text_1.Description = "获取指定要查询的主机的WhoIs注册信息";
            var opt_network_whois_info_as_text_1_domain = new Option<string>("--domain")
            {
                Required = true, Description = "指定要查询的主机"
            };
            cmd_network_whois_info_as_text_1.Options.Add(opt_network_whois_info_as_text_1_domain);
            cmd_network_whois_info_as_text_1.SetAction(parseResult =>
            {
                var domain = parseResult.GetValue(opt_network_whois_info_as_text_1_domain);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.WHOISInfo.AsText(domain, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_network_whois_info_as_json_2 =
                CliCommandTree.GetOrAdd(root, new[] { "network", "whois-info", "as-json" });
            cmd_network_whois_info_as_json_2.Description = "获取指定要查询的主机的WhoIs注册信息";
            var opt_network_whois_info_as_json_2_domain = new Option<string>("--domain")
            {
                Required = true, Description = "指定要查询的主机"
            };
            cmd_network_whois_info_as_json_2.Options.Add(opt_network_whois_info_as_json_2_domain);
            cmd_network_whois_info_as_json_2.SetAction(parseResult =>
            {
                var domain = parseResult.GetValue(opt_network_whois_info_as_json_2_domain);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.WHOISInfo.AsJson(domain, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}