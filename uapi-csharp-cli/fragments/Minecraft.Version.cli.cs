using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Minecraft_Version
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_minecraft_latest_version_from_mojang_1 =
                CliCommandTree.GetOrAdd(root, new[] { "minecraft", "latest-version", "from-mojang" });
            cmd_minecraft_latest_version_from_mojang_1.Description = "通过 Mojang API 获取Minecraft Java 最新快照和正式版";
            cmd_minecraft_latest_version_from_mojang_1.SetAction(parseResult =>
            {
                var result = Minecraft.GetLatestVersion.FromMojang().GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_minecraft_latest_version_from_uapi_2 =
                CliCommandTree.GetOrAdd(root, new[] { "minecraft", "latest-version", "from-uapi" });
            cmd_minecraft_latest_version_from_uapi_2.Description = "通过 Mojang API 获取Minecraft Java 最新快照和正式版";
            cmd_minecraft_latest_version_from_uapi_2.SetAction(parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Minecraft.GetLatestVersion.FromUAPI(Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}