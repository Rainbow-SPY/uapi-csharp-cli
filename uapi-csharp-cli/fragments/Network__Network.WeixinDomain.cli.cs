using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_WeixinDomain
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_network_domain_in_weixin_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "domain-in-weixin" });
            cmd_network_domain_in_weixin_1.Description = "检查指定的主机在微信网页中的访问情况";
            var opt_network_domain_in_weixin_1_domain = new Option<string>("--domain")
            {
                Required = true, Description = "指定的主机"
            };
            cmd_network_domain_in_weixin_1.Options.Add(opt_network_domain_in_weixin_1_domain);
            cmd_network_domain_in_weixin_1.SetAction(parseResult =>
            {
                var domain = parseResult.GetValue(opt_network_domain_in_weixin_1_domain);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.CheckDomainInWeixin(domain, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}