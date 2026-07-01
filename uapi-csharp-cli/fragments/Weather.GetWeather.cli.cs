using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Weather_GetWeather
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "weather", "city" });
            o.Description = "获取天气信息";
            var o_c = new Option<string>("--city")
            {
                Required = true, Description = "城市名称"
            };
            o.Options.Add(o_c);
            var o_e = new Option<bool>("--extended")
            {
                Required = false, Description = "是否返回扩展气象字段(体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量)。",
                DefaultValueFactory = _ => false
            };
            o.Options.Add(o_e);
            var o_i = new Option<bool>("--indices")
            {
                Required = false, Description = "是否返回生活指数(穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度)。", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_i);
            var o_f = new Option<bool>("--forecast")
            {
                Required = false, Description = "是否返回预报数据(当日最高/最低气温及未来3天天气预报)。", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_f);
            var o_h = new Option<bool>("--hourly")
            {
                Required = false, Description = "逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_h);
            var o_m = new Option<bool>("--minutely")
            {
                Required = false, Description = "分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_m);
            o.SetAction(parseResult =>
            {
                var city = parseResult.GetValue(o_c);
                var extended = parseResult.GetValue(o_e);
                var indices = parseResult.GetValue(o_i);
                var forecast = parseResult.GetValue(o_f);
                var hourly = parseResult.GetValue(o_h);
                var minutely = parseResult.GetValue(o_m);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Weather
                    .GetWeatherDataJson(city, extended, indices, forecast, hourly, minutely, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 =
                CliCommandTree.GetOrAdd(root, new[] { "weather", "data-json", "adcode" });
            o2.Description = "获取天气信息";
            var o2_a = new Option<int>("--adcode")
            {
                Required = true, Description = "高德地图的6位数字城市编码"
            };
            o2.Options.Add(o2_a);
            var o2_e = new Option<bool>("--extended")
            {
                Required = false, Description = "是否返回扩展气象字段(体感温度、能见度、气压、紫外线指数、空气质量、降水量、云量)。",
                DefaultValueFactory = _ => false
            };
            o2.Options.Add(o2_e);
            var o2_i = new Option<bool>("--indices")
            {
                Required = false, Description = "是否返回生活指数(穿衣、紫外线、洗车、晾晒、空调、感冒、运动、舒适度)。", DefaultValueFactory = _ => false
            };
            o2.Options.Add(o2_i);
            var o2_f = new Option<bool>("--forecast")
            {
                Required = false, Description = "是否返回预报数据(当日最高/最低气温及未来3天天气预报)。", DefaultValueFactory = _ => false
            };
            o2.Options.Add(o2_f);
            var o2_h = new Option<bool>("--hourly")
            {
                Required = false, Description = "逐小时预报 (24小时)，含温度、天气、风向风速、湿度、降水概率等", DefaultValueFactory = _ => false
            };
            o2.Options.Add(o2_h);
            var o2_m = new Option<bool>("--minutely")
            {
                Required = false, Description = "分钟级降水预报 (仅国内城市)，每5分钟一个数据点，共24个", DefaultValueFactory = _ => false
            };
            o2.Options.Add(o2_m);
            o2.SetAction(parseResult =>
            {
                var adcode = parseResult.GetValue(o2_a);
                var extended = parseResult.GetValue(o2_e);
                var indices = parseResult.GetValue(o2_i);
                var forecast = parseResult.GetValue(o2_f);
                var hourly = parseResult.GetValue(o2_h);
                var minutely = parseResult.GetValue(o2_m);
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