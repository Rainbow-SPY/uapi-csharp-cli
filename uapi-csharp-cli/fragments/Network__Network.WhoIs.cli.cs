using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_WhoIs
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o =
                CliCommandTree.GetOrAdd(root, new[] { "network", "whois-info", "text" });
            o.Description = "获取指定要查询的主机的WhoIs注册信息";
            var od = new Option<string>("--domain")
            {
                Required = true, Description = "指定要查询的主机"
            };
            o.Options.Add(od);
            o.SetAction(parseResult =>
            {
                var domain = parseResult.GetValue(od);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.WHOISInfo.AsText(domain, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 =
                CliCommandTree.GetOrAdd(root, new[] { "network", "whois-info", "json" });
            o2.Description = "获取指定要查询的主机的WhoIs注册信息";
            var o2d = new Option<string>("--domain")
            {
                Required = true, Description = "指定要查询的主机"
            };
            o2.Options.Add(o2d);
            o2.SetAction(parseResult =>
            {
                var domain = parseResult.GetValue(o2d);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.WHOISInfo.AsJson(domain, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}