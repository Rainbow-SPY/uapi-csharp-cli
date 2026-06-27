using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_API_Usage
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_api_usage_1 = CliCommandTree.GetOrAdd(root, new[] { "api", "usage" });
            cmd_api_usage_1.Description = "获取 API 使用统计";
            cmd_api_usage_1.SetAction(async parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await API.GetUsage(Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}