using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_API_Usage
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_api_usage_1 = CliCommandTree.GetOrAdd(root, new[] { "api", "usage" });
            cmd_api_usage_1.Description = "获取 API 使用统计";
            cmd_api_usage_1.SetAction(parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = API.GetUsage(Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}