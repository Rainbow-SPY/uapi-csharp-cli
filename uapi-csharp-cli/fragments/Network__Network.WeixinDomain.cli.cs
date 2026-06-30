using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_WeixinDomain
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "network", "weixin" });
            o.Description = "检查指定的主机在微信网页中的访问情况";
            var od = new Option<string>("--domain")
            {
                Required = true, Description = "指定的主机"
            };
            o.Options.Add(od);
            o.SetAction(parseResult =>
            {
                var domain = parseResult.GetValue(od);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.CheckDomainInWeixin(domain, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}