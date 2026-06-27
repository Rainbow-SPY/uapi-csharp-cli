using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetProgrammerHistoryToday
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_misc_programmer_history_today_1 =
                CliCommandTree.GetOrAdd(root, new[] { "misc", "programmer-history-today" });
            cmd_misc_programmer_history_today_1.Description = "获取程序员历史上的今天的事件";
            cmd_misc_programmer_history_today_1.SetAction(async parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Misc.GetProgrammerHistoryToday(Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}