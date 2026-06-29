using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_PostDateDiff
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_misc_date_diff_1 = CliCommandTree.GetOrAdd(root, new[] { "misc", "date-diff" });
            cmd_misc_date_diff_1.Description = "计算两个时间/日期之间的差值";
            var opt_misc_date_diff_1_start_date = new Option<string>("--start-date")
            {
                Required = true, Description = "开始时间/日期"
            };
            cmd_misc_date_diff_1.Options.Add(opt_misc_date_diff_1_start_date);
            var opt_misc_date_diff_1_end_date = new Option<string>("--end-date")
            {
                Required = true, Description = "结束时间/日期"
            };
            cmd_misc_date_diff_1.Options.Add(opt_misc_date_diff_1_end_date);
            var opt_misc_date_diff_1_format = new Option<string>("--format")
            {
                Required = false, Description = "时间格式, 默认为 YYYY-MM-DD", DefaultValueFactory = _ => "YYYY-MM-DD"
            };
            cmd_misc_date_diff_1.Options.Add(opt_misc_date_diff_1_format);
            cmd_misc_date_diff_1.SetAction(parseResult =>
            {
                var start_date = parseResult.GetValue(opt_misc_date_diff_1_start_date);
                var end_date = parseResult.GetValue(opt_misc_date_diff_1_end_date);
                var format = parseResult.GetValue(opt_misc_date_diff_1_format);
                var result = Misc.PostDateDiff(start_date, end_date, format).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}