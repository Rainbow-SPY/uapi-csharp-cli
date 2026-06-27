using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetHolidayCalendar
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_misc_holiday_calendar_1 = CliCommandTree.GetOrAdd(root, new[] { "misc", "holiday-calendar" });
            cmd_misc_holiday_calendar_1.Description = "查询指定日期、月份或年份的万年历与节假日信息";
            var opt_misc_holiday_calendar_1_date = new Option<string>("--date")
            {
                Required = false, Description = "按天查询时填写这个参数，例如查某一天", DefaultValueFactory = _ => ""
            };
            cmd_misc_holiday_calendar_1.Options.Add(opt_misc_holiday_calendar_1_date);
            var opt_misc_holiday_calendar_1_month = new Option<string>("--month")
            {
                Required = false, Description = "按月查询时填写这个参数，例如查某个月", DefaultValueFactory = _ => ""
            };
            cmd_misc_holiday_calendar_1.Options.Add(opt_misc_holiday_calendar_1_month);
            var opt_misc_holiday_calendar_1_year = new Option<string>("--year")
            {
                Required = false, Description = "按年查询时填写这个参数，例如查某一年", DefaultValueFactory = _ => ""
            };
            cmd_misc_holiday_calendar_1.Options.Add(opt_misc_holiday_calendar_1_year);
            var opt_misc_holiday_calendar_1_timezone = new Option<string>("--timezone")
            {
                Required = false, Description = "时区名称，默认 Asia/Shanghai", DefaultValueFactory = _ => "Asia/Shanghai"
            };
            cmd_misc_holiday_calendar_1.Options.Add(opt_misc_holiday_calendar_1_timezone);
            var opt_misc_holiday_calendar_1_HolidayType = new Option<string>("--holiday-type")
            {
                Required = false, Description = "节日筛选类型，默认 all", DefaultValueFactory = _ => "all"
            };
            cmd_misc_holiday_calendar_1.Options.Add(opt_misc_holiday_calendar_1_HolidayType);
            var opt_misc_holiday_calendar_1_include_nearby = new Option<bool>("--include-nearby")
            {
                Required = false, Description = "是否返回前后最近节日，仅 date 模式生效，默认 false。month/year 模式会忽略此参数",
                DefaultValueFactory = _ => false
            };
            cmd_misc_holiday_calendar_1.Options.Add(opt_misc_holiday_calendar_1_include_nearby);
            var opt_misc_holiday_calendar_1_nearby_limit = new Option<int>("--nearby-limit")
            {
                Required = false, Description = "返回最近节日数量限制，默认 7，最大 30。仅 date 模式 + include_nearby=true 生效",
                DefaultValueFactory = _ => 7
            };
            cmd_misc_holiday_calendar_1.Options.Add(opt_misc_holiday_calendar_1_nearby_limit);
            cmd_misc_holiday_calendar_1.SetAction(async parseResult =>
            {
                var date = parseResult.GetValue(opt_misc_holiday_calendar_1_date);
                var month = parseResult.GetValue(opt_misc_holiday_calendar_1_month);
                var year = parseResult.GetValue(opt_misc_holiday_calendar_1_year);
                var timezone = parseResult.GetValue(opt_misc_holiday_calendar_1_timezone);
                var HolidayType = parseResult.GetValue(opt_misc_holiday_calendar_1_HolidayType);
                var include_nearby = parseResult.GetValue(opt_misc_holiday_calendar_1_include_nearby);
                var nearby_limit = parseResult.GetValue(opt_misc_holiday_calendar_1_nearby_limit);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Misc.GetHolidayCalendar(date, month, year, timezone, HolidayType, include_nearby,
                    nearby_limit, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}