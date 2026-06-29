using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_ConvertTimestamp
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_misc_covert_timestamp_1 = CliCommandTree.GetOrAdd(root, new[] { "misc", "covert-timestamp" });
            var opt_misc_covert_timestamp_1_ts = new Option<string>("--ts")
            {
                Required = true
            };
            cmd_misc_covert_timestamp_1.Options.Add(opt_misc_covert_timestamp_1_ts);
            cmd_misc_covert_timestamp_1.SetAction(parseResult =>
            {
                var ts = parseResult.GetValue(opt_misc_covert_timestamp_1_ts);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.CovertTimestamp(ts, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}