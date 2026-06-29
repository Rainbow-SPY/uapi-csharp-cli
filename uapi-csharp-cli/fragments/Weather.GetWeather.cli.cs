using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Weather_GetWeather
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_weather_data_json_1 = CliCommandTree.GetOrAdd(root, new[] { "weather", "data-json" });
            cmd_weather_data_json_1.Description = "获取天气信息";
            var opt_weather_data_json_1_city = new Option<string>("--city")
            {
                Required = true, Description = "城市名称"
            };
            cmd_weather_data_json_1.Options.Add(opt_weather_data_json_1_city);
            var opt_weather_data_json_1_extended = new Option<bool>("--extended")
            {
                Required = false, Description = "是否返回扩展气象字段(体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量)。",
                DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_1.Options.Add(opt_weather_data_json_1_extended);
            var opt_weather_data_json_1_indices = new Option<bool>("--indices")
            {
                Required = false, Description = "是否返回生活指数(穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度)。", DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_1.Options.Add(opt_weather_data_json_1_indices);
            var opt_weather_data_json_1_forecast = new Option<bool>("--forecast")
            {
                Required = false, Description = "是否返回预报数据(当日最高/最低气温及未来3天天气预报)。", DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_1.Options.Add(opt_weather_data_json_1_forecast);
            var opt_weather_data_json_1_hourly = new Option<bool>("--hourly")
            {
                Required = false, Description = "逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等", DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_1.Options.Add(opt_weather_data_json_1_hourly);
            var opt_weather_data_json_1_minutely = new Option<bool>("--minutely")
            {
                Required = false, Description = "分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个", DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_1.Options.Add(opt_weather_data_json_1_minutely);
            cmd_weather_data_json_1.SetAction(parseResult =>
            {
                var city = parseResult.GetValue(opt_weather_data_json_1_city);
                var extended = parseResult.GetValue(opt_weather_data_json_1_extended);
                var indices = parseResult.GetValue(opt_weather_data_json_1_indices);
                var forecast = parseResult.GetValue(opt_weather_data_json_1_forecast);
                var hourly = parseResult.GetValue(opt_weather_data_json_1_hourly);
                var minutely = parseResult.GetValue(opt_weather_data_json_1_minutely);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Weather
                    .GetWeatherDataJson(city, extended, indices, forecast, hourly, minutely, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_weather_data_json_by_adcode_2 =
                CliCommandTree.GetOrAdd(root, new[] { "weather", "data-json", "by-adcode" });
            cmd_weather_data_json_by_adcode_2.Description = "获取天气信息";
            var opt_weather_data_json_by_adcode_2_adcode = new Option<int>("--adcode")
            {
                Required = true, Description = "高德地图的6位数字城市编码"
            };
            cmd_weather_data_json_by_adcode_2.Options.Add(opt_weather_data_json_by_adcode_2_adcode);
            var opt_weather_data_json_by_adcode_2_extended = new Option<bool>("--extended")
            {
                Required = false, Description = "是否返回扩展气象字段(体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量)。",
                DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_by_adcode_2.Options.Add(opt_weather_data_json_by_adcode_2_extended);
            var opt_weather_data_json_by_adcode_2_indices = new Option<bool>("--indices")
            {
                Required = false, Description = "是否返回生活指数(穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度)。", DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_by_adcode_2.Options.Add(opt_weather_data_json_by_adcode_2_indices);
            var opt_weather_data_json_by_adcode_2_forecast = new Option<bool>("--forecast")
            {
                Required = false, Description = "是否返回预报数据(当日最高/最低气温及未来3天天气预报)。", DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_by_adcode_2.Options.Add(opt_weather_data_json_by_adcode_2_forecast);
            var opt_weather_data_json_by_adcode_2_hourly = new Option<bool>("--hourly")
            {
                Required = false, Description = "逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等", DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_by_adcode_2.Options.Add(opt_weather_data_json_by_adcode_2_hourly);
            var opt_weather_data_json_by_adcode_2_minutely = new Option<bool>("--minutely")
            {
                Required = false, Description = "分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个", DefaultValueFactory = _ => false
            };
            cmd_weather_data_json_by_adcode_2.Options.Add(opt_weather_data_json_by_adcode_2_minutely);
            cmd_weather_data_json_by_adcode_2.SetAction(parseResult =>
            {
                var adcode = parseResult.GetValue(opt_weather_data_json_by_adcode_2_adcode);
                var extended = parseResult.GetValue(opt_weather_data_json_by_adcode_2_extended);
                var indices = parseResult.GetValue(opt_weather_data_json_by_adcode_2_indices);
                var forecast = parseResult.GetValue(opt_weather_data_json_by_adcode_2_forecast);
                var hourly = parseResult.GetValue(opt_weather_data_json_by_adcode_2_hourly);
                var minutely = parseResult.GetValue(opt_weather_data_json_by_adcode_2_minutely);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Weather
                    .GetWeatherDataJson(adcode, extended, indices, forecast, hourly, minutely, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}