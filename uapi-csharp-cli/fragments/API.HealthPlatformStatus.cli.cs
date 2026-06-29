using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_API_HealthPlatformStatus
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_api_health_platform_status_1 =
                CliCommandTree.GetOrAdd(root, new[] { "api", "hps" });
            cmd_api_health_platform_status_1.Description = "查询UAPI的 API HPS (Health Platform Status 平台 API 使用情况)";
            cmd_api_health_platform_status_1.SetAction(parseResult =>
            {
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = API.HealthPlatformStatus(AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}