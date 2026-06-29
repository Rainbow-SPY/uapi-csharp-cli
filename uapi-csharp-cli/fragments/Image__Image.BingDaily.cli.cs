using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_BingDaily
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_image_bing_daily_meta_json_data_1 =
                CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily-meta-json-data" });
            cmd_image_bing_daily_meta_json_data_1.Description = "获取必应每日壁纸";
            var opt_image_bing_daily_meta_json_data_1_date = new Option<string>("--date")
            {
                Required = true, Description = "指定获取日期的当天壁纸, 为空则返回今天的壁纸"
            };
            cmd_image_bing_daily_meta_json_data_1.Options.Add(opt_image_bing_daily_meta_json_data_1_date);
            var opt_image_bing_daily_meta_json_data_1_resolutions =
                new Option<Type.BingDailyType.Resolutions>("--resolutions")
                {
                    Required = false, Description = "指定返回图像的分辨率, 默认4K, 可选 1080P",
                    DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
                };
            cmd_image_bing_daily_meta_json_data_1.Options.Add(opt_image_bing_daily_meta_json_data_1_resolutions);
            cmd_image_bing_daily_meta_json_data_1.SetAction(parseResult =>
            {
                var date = parseResult.GetValue(opt_image_bing_daily_meta_json_data_1_date);
                var resolutions = parseResult.GetValue(opt_image_bing_daily_meta_json_data_1_resolutions);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetBingDailyMetaJsonData(date, resolutions, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_image_bing_daily_meta_json_data_by_2_2 =
                CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily-meta-json-data", "by-2" });
            cmd_image_bing_daily_meta_json_data_by_2_2.Description = "获取必应每日壁纸";
            var opt_image_bing_daily_meta_json_data_by_2_2_random = new Option<bool>("--random")
            {
                Required = false, Description = "指定是否每次请求随机返回一张历史壁纸。false则默认返回今天的壁纸", DefaultValueFactory = _ => false
            };
            cmd_image_bing_daily_meta_json_data_by_2_2.Options.Add(opt_image_bing_daily_meta_json_data_by_2_2_random);
            var opt_image_bing_daily_meta_json_data_by_2_2_resolutions =
                new Option<Type.BingDailyType.Resolutions>("--resolutions")
                {
                    Required = false, Description = "指定返回图像的分辨率, 默认4K, 可选 1080P",
                    DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
                };
            cmd_image_bing_daily_meta_json_data_by_2_2.Options.Add(
                opt_image_bing_daily_meta_json_data_by_2_2_resolutions);
            cmd_image_bing_daily_meta_json_data_by_2_2.SetAction(parseResult =>
            {
                var random = parseResult.GetValue(opt_image_bing_daily_meta_json_data_by_2_2_random);
                var resolutions = parseResult.GetValue(opt_image_bing_daily_meta_json_data_by_2_2_resolutions);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetBingDailyMetaJsonData(random, resolutions, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_image_bing_daily_image_3 = CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily-image" });
            cmd_image_bing_daily_image_3.Description = "获取必应每日壁纸";
            var opt_image_bing_daily_image_3_date = new Option<string>("--date")
            {
                Required = true, Description = "指定获取日期的当天壁纸, 为空则返回今天的壁纸"
            };
            cmd_image_bing_daily_image_3.Options.Add(opt_image_bing_daily_image_3_date);
            var opt_image_bing_daily_image_3_resolutions =
                new Option<Type.BingDailyType.Resolutions>("--resolutions")
                {
                    Required = false, Description = "指定返回图像的分辨率, 默认4K, 可选 1080P",
                    DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
                };
            cmd_image_bing_daily_image_3.Options.Add(opt_image_bing_daily_image_3_resolutions);
            var opt_image_bing_daily_image_3_format = new Option<Type.BingDailyType.Format>("--format")
            {
                Required = false, Description = "指定返回的格式, 默认二进制byte[], 可选302重定向后的图片URL的二进制byte[]",
                DefaultValueFactory = _ => Type.BingDailyType.Format.image
            };
            cmd_image_bing_daily_image_3.Options.Add(opt_image_bing_daily_image_3_format);
            cmd_image_bing_daily_image_3.SetAction(parseResult =>
            {
                var date = parseResult.GetValue(opt_image_bing_daily_image_3_date);
                var resolutions = parseResult.GetValue(opt_image_bing_daily_image_3_resolutions);
                var format = parseResult.GetValue(opt_image_bing_daily_image_3_format);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetBingDailyImage(date, resolutions, format, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_image_bing_daily_image_by_2_4 =
                CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily-image", "by-2" });
            cmd_image_bing_daily_image_by_2_4.Description = "获取必应每日壁纸";
            var opt_image_bing_daily_image_by_2_4_random = new Option<bool>("--random")
            {
                Required = false, Description = "指定是否每次请求随机返回一张历史壁纸。false则默认返回今天的壁纸", DefaultValueFactory = _ => false
            };
            cmd_image_bing_daily_image_by_2_4.Options.Add(opt_image_bing_daily_image_by_2_4_random);
            var opt_image_bing_daily_image_by_2_4_resolutions =
                new Option<Type.BingDailyType.Resolutions>("--resolutions")
                {
                    Required = false, Description = "指定返回图像的分辨率, 默认4K, 可选 1080P",
                    DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
                };
            cmd_image_bing_daily_image_by_2_4.Options.Add(opt_image_bing_daily_image_by_2_4_resolutions);
            var opt_image_bing_daily_image_by_2_4_format = new Option<Type.BingDailyType.Format>("--format")
            {
                Required = false, Description = "指定返回的格式, 默认二进制byte[], 可选302重定向后的图片URL的二进制byte[]",
                DefaultValueFactory = _ => Type.BingDailyType.Format.image
            };
            cmd_image_bing_daily_image_by_2_4.Options.Add(opt_image_bing_daily_image_by_2_4_format);
            cmd_image_bing_daily_image_by_2_4.SetAction(parseResult =>
            {
                var random = parseResult.GetValue(opt_image_bing_daily_image_by_2_4_random);
                var resolutions = parseResult.GetValue(opt_image_bing_daily_image_by_2_4_resolutions);
                var format = parseResult.GetValue(opt_image_bing_daily_image_by_2_4_format);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetBingDailyImage(random, resolutions, format, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_image_bing_daily_history_5 = CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily-history" });
            cmd_image_bing_daily_history_5.Description = "获取必应每日壁纸历史列表";
            var opt_image_bing_daily_history_5_date = new Option<string>("--date")
            {
                Required = false, Description = "指定日期精确查询 (YYYY-MM-DD)，传此参数时 page/pageSize 不生效",
                DefaultValueFactory = _ => ""
            };
            cmd_image_bing_daily_history_5.Options.Add(opt_image_bing_daily_history_5_date);
            var opt_image_bing_daily_history_5_resolution =
                new Option<Type.BingDailyType.Resolutions>("--resolution")
                {
                    Required = false, Description = "指定返回图像的分辨率，默认 4K",
                    DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
                };
            cmd_image_bing_daily_history_5.Options.Add(opt_image_bing_daily_history_5_resolution);
            var opt_image_bing_daily_history_5_page = new Option<int>("--page")
            {
                Required = false, Description = "页码，默认 1", DefaultValueFactory = _ => 1
            };
            cmd_image_bing_daily_history_5.Options.Add(opt_image_bing_daily_history_5_page);
            var opt_image_bing_daily_history_5_pageSize = new Option<int>("--page-size")
            {
                Required = false, Description = "每页数量，默认 30，最大 100", DefaultValueFactory = _ => 30
            };
            cmd_image_bing_daily_history_5.Options.Add(opt_image_bing_daily_history_5_pageSize);
            cmd_image_bing_daily_history_5.SetAction(parseResult =>
            {
                var date = parseResult.GetValue(opt_image_bing_daily_history_5_date);
                var resolution = parseResult.GetValue(opt_image_bing_daily_history_5_resolution);
                var page = parseResult.GetValue(opt_image_bing_daily_history_5_page);
                var pageSize = parseResult.GetValue(opt_image_bing_daily_history_5_pageSize);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetBingDailyHistory(date, resolution, page, pageSize, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}