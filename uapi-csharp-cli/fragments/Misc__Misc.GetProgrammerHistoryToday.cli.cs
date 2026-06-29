using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetProgrammerHistoryToday
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_misc_programmer_history_today_1 =
                CliCommandTree.GetOrAdd(root, new[] { "misc", "programmer-history-today" });
            cmd_misc_programmer_history_today_1.Description = "获取程序员历史上的今天的事件";
            cmd_misc_programmer_history_today_1.SetAction(parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.GetProgrammerHistoryToday(Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}