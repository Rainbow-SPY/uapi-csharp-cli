using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Minecraft_Version
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_minecraft_latest_version_from_mojang_1 =
                CliCommandTree.GetOrAdd(root, new[] { "minecraft", "latest-version", "from-mojang" });
            cmd_minecraft_latest_version_from_mojang_1.Description = "通过 Mojang API 获取Minecraft Java 最新快照和正式版";
            cmd_minecraft_latest_version_from_mojang_1.SetAction(async parseResult =>
            {
                var result = await Minecraft.GetLatestVersion.FromMojang();
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_minecraft_latest_version_from_uapi_2 =
                CliCommandTree.GetOrAdd(root, new[] { "minecraft", "latest-version", "from-uapi" });
            cmd_minecraft_latest_version_from_uapi_2.Description = "通过 Mojang API 获取Minecraft Java 最新快照和正式版";
            cmd_minecraft_latest_version_from_uapi_2.SetAction(async parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Minecraft.GetLatestVersion.FromUAPI(Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}