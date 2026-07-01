using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Search_GetConfig
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "search", "config" });
            o.Description = "获取搜索引擎配置 (GET)";
            o.SetAction(parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Search.GetConfig(Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}