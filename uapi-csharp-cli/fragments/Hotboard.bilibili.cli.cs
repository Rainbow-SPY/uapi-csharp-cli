using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Hotboard_bilibili
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_hotboard_bilibili_hotboard_1 =
                CliCommandTree.GetOrAdd(root, new[] { "hotboard", "bilibili-hotboard" });
            cmd_hotboard_bilibili_hotboard_1.Description = "获取bilibili热榜信息";
            cmd_hotboard_bilibili_hotboard_1.SetAction(async parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Hotboard.GetBilibiliHotboard(Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}