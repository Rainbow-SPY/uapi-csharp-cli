using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_PostDateDiff
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "misc", "date-diff" });
            o.Description = "计算两个时间/日期之间的差值";
            var osd = new Option<string>("--start")
            {
                Required = true, Description = "开始时间/日期"
            };
            o.Options.Add(osd);
            var oed = new Option<string>("--end")
            {
                Required = true, Description = "结束时间/日期"
            };
            o.Options.Add(oed);
            var of = new Option<string>("--format")
            {
                Required = false, Description = "时间格式, 默认为 YYYY-MM-DD", DefaultValueFactory = _ => "YYYY-MM-DD"
            };
            o.Options.Add(of);
            o.SetAction(parseResult =>
            {
                var start_date = parseResult.GetValue(osd);
                var end_date = parseResult.GetValue(oed);
                var format = parseResult.GetValue(of);
                var result = Misc.PostDateDiff(start_date, end_date, format).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}