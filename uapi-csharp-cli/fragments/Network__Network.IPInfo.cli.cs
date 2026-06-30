using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_IPInfo
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "network", "ip-info" });
            o.Description = "查询IP的相关信息";
            var oip = new Option<string>("--ip")
            {
                Required = true, Description = "指定要查询的IP地址"
            };
            o.Options.Add(oip);
            var o_pro = new Option<bool>("--pro")
            {
                Required = false, Description = "是否使用商业数据源", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_pro);
            o.SetAction(parseResult =>
            {
                var ip = parseResult.GetValue(oip);
                var IsUseCommercial = parseResult.GetValue(o_pro);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.GetIPInfo(ip, IsUseCommercial, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}