using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_API_HealthPlatformStatus
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_api_health_platform_status_1 =
                CliCommandTree.GetOrAdd(root, new[] { "api", "health-platform-status" });
            cmd_api_health_platform_status_1.Description = "查询UAPI的 API HPS";
            cmd_api_health_platform_status_1.SetAction(async parseResult =>
            {
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = await API.HealthPlatformStatus(AuthenticationAPITokenKey);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}