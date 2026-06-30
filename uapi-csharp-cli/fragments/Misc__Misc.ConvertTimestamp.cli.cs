using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_ConvertTimestamp
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "misc", "covert-timestamp-to-date" });
            o.Description = "将Unix时间戳转换为人类可读日期时间的旧版接口。";
            var o_ts = new Option<string>("--ts")
            {
                Required = true,
                Description = "Unix 时间戳"
            };
            o.Options.Add(o_ts);
            o.SetAction(parseResult =>
            {
                var ts = parseResult.GetValue(o_ts);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.CovertTimestamp(ts, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}