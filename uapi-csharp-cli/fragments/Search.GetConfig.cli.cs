using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Search_GetConfig
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_search_config_1 = CliCommandTree.GetOrAdd(root, new[] { "search", "config" });
            cmd_search_config_1.Description = "获取搜索引擎配置 (GET)";
            cmd_search_config_1.SetAction(async parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Search.GetConfig(Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}