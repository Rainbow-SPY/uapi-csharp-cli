using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetLunarTime
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_misc_lunar_time_1 = CliCommandTree.GetOrAdd(root, new[] { "misc", "lunar-time" });
            cmd_misc_lunar_time_1.Description = "查询农历时间";
            var opt_misc_lunar_time_1_ts = new Option<string>("--ts")
            {
                Required = false, Description = "Unix 时间戳，支持 10 位秒级或 13 位毫秒级。默认以当前时间。", DefaultValueFactory = _ => ""
            };
            cmd_misc_lunar_time_1.Options.Add(opt_misc_lunar_time_1_ts);
            var opt_misc_lunar_time_1_timezone = new Option<string>("--timezone")
            {
                Required = false,
                Description = "时区名称。支持 IANA 时区(如 Asia/Shanghai)和别名(Shanghai、Beijing)。默认 Asia/Shanghai。",
                DefaultValueFactory = _ => "Asia/Shanghai"
            };
            cmd_misc_lunar_time_1.Options.Add(opt_misc_lunar_time_1_timezone);
            cmd_misc_lunar_time_1.SetAction(async parseResult =>
            {
                var ts = parseResult.GetValue(opt_misc_lunar_time_1_ts);
                var timezone = parseResult.GetValue(opt_misc_lunar_time_1_timezone);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Misc.GetLunarTime(ts, timezone, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}