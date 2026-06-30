using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetLunarTime
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "misc", "lunar-time" });
            o.Description = "查询农历时间";
            var o_ts = new Option<string>("--ts")
            {
                Required = false, Description = "Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_ts);
            var o_tz = new Option<string>("--timezone")
            {
                Required = false,
                Description = "时区名称。支持 IANA 时区(如 Asia/Shanghai)和别名(Shanghai、Beijing)。默认 Asia/Shanghai。",
                DefaultValueFactory = _ => "Asia/Shanghai"
            };
            o.Options.Add(o_tz);
            o.SetAction(parseResult =>
            {
                var ts = parseResult.GetValue(o_ts);
                var timezone = parseResult.GetValue(o_tz);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.GetLunarTime(ts, timezone, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}