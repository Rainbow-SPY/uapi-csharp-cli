using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetHolidayCalendar
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "misc", "holiday-calendar" });
            o.Description = "查询指定日期、月份或年份的万年历与节假日信息";
            var o_d = new Option<string>("--date")
            {
                Required = false, Description = "按天查询时填写这个参数，例如查某一天", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_d);
            var o_m = new Option<string>("--month")
            {
                Required = false, Description = "按月查询时填写这个参数，例如查某个月", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_m);
            var o_y = new Option<string>("--year")
            {
                Required = false, Description = "按年查询时填写这个参数，例如查某一年", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_y);
            var o_tz = new Option<string>("--timezone")
            {
                Required = false, Description = "时区名称，默认 Asia/Shanghai", DefaultValueFactory = _ => "Asia/Shanghai"
            };
            o.Options.Add(o_tz);
            var o_ty = new Option<string>("--holiday-type")
            {
                Required = false, Description = "节日筛选类型，默认 all", DefaultValueFactory = _ => "all"
            };
            o.Options.Add(o_ty);
            var o_in = new Option<bool>("--include-nearby")
            {
                Required = false, Description = "是否返回前后最近节日，仅 date 模式生效，默认 false。month/year 模式会忽略此参数",
                DefaultValueFactory = _ => false
            };
            o.Options.Add(o_in);
            var o_ne = new Option<int>("--nearby-limit")
            {
                Required = false, Description = "返回最近节日数量限制，默认 7，最大 30。仅 date 模式 + include_nearby=true 生效",
                DefaultValueFactory = _ => 7
            };
            o.Options.Add(o_ne);
            o.SetAction(parseResult =>
            {
                var date = parseResult.GetValue(o_d);
                var month = parseResult.GetValue(o_m);
                var year = parseResult.GetValue(o_y);
                var timezone = parseResult.GetValue(o_tz);
                var HolidayType = parseResult.GetValue(o_ty);
                var include_nearby = parseResult.GetValue(o_in);
                var nearby_limit = parseResult.GetValue(o_ne);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.GetHolidayCalendar(date, month, year, timezone, HolidayType, include_nearby,
                    nearby_limit, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}