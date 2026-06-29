using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Hotboard_bilibili
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_hotboard_bilibili_hotboard_1 =
                CliCommandTree.GetOrAdd(root, new[] { "hotboard", "bilibili-hotboard" });
            cmd_hotboard_bilibili_hotboard_1.Description = "获取bilibili热榜信息";
            cmd_hotboard_bilibili_hotboard_1.SetAction(parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Hotboard.GetBilibiliHotboard(Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}