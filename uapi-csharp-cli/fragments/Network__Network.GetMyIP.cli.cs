using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_GetMyIP
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "network", "my-ip" });
            o.Description = "获取本机的IP地址";
            var o_pro = new Option<bool>("--pro")
            {
                Required = false, Description = "指定是否使用商业级的数据源, 默认为 false", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_pro);
            o.SetAction(parseResult =>
            {
                var commercial = parseResult.GetValue(o_pro);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.GetMyIP(commercial, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}