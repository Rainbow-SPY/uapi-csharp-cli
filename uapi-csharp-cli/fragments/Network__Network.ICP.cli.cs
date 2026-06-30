using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_ICP
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "network", "icp-info" });
            o.Description = "查询ICP备案信息";
            var od = new Option<string>("--domain")
            {
                Required = true, Description = "要查询的主机"
            };
            o.Options.Add(od);
            o.SetAction(parseResult =>
            {
                var domain = parseResult.GetValue(od);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.GetICPInfo(domain, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}