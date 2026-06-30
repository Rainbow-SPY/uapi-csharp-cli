using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_BingDaily
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            #region metadata

            var o =
                CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily", "json", "date" });
            o.Description = "获取必应每日壁纸";
            var o_d = new Option<string>("--date")
            {
                Required = true, Description = "指定获取日期的当天壁纸, 为空则返回今天的壁纸"
            };
            o.Options.Add(o_d);
            var o_r = new Option<Type.BingDailyType.Resolutions>("--resolutions")
            {
                Required = false, Description = "指定返回图像的分辨率, 默认4K, 可选 1080P",
                DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
            };
            o.Options.Add(o_r);
            o.SetAction(parseResult =>
            {
                var date = parseResult.GetValue(o_d);
                var resolutions = parseResult.GetValue(o_r);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetBingDailyMetaJsonData(date, resolutions, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily", "json", "random" });
            o2.Description = "获取必应每日壁纸";
            var o2_re = new Option<Type.BingDailyType.Resolutions>("--resolutions")
            {
                Required = false, Description = "指定返回图像的分辨率, 默认4K, 可选 1080P",
                DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
            };
            o2.Options.Add(o2_re);
            o2.SetAction(parseResult =>
            {
                var resolutions = parseResult.GetValue(o2_re);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetBingDailyMetaJsonData(true, resolutions, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            #endregion

            #region image

            var o3 = CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily", "date" });
            o3.Description = "获取必应每日壁纸";
            var o3_d = new Option<string>("--date")
            {
                Required = true, Description = "指定获取日期的当天壁纸, 为空则返回今天的壁纸"
            };
            o3.Options.Add(o3_d);
            var o3_r = new Option<Type.BingDailyType.Resolutions>("--resolutions")
            {
                Required = false, Description = "指定返回图像的分辨率, 默认4K, 可选 1080P",
                DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
            };
            o3.Options.Add(o3_r);
            var o3_f = new Option<Type.BingDailyType.Format>("--format")
            {
                Required = false, Description = "指定返回的格式, 默认二进制byte[], 可选302重定向后的图片URL的二进制byte[]",
                DefaultValueFactory = _ => Type.BingDailyType.Format.image
            };
            o3.Options.Add(o3_f);
            o3.SetAction(parseResult =>
            {
                var date = parseResult.GetValue(o3_d);
                var resolutions = parseResult.GetValue(o3_r);
                var format = parseResult.GetValue(o3_f);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetBingDailyImage(date, resolutions, format, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o4 = CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily", "random" });
            o4.Description = "获取必应每日壁纸";
            var o4_r = new Option<Type.BingDailyType.Resolutions>("--resolutions")
            {
                Required = false, Description = "指定返回图像的分辨率, 默认4K, 可选 1080P",
                DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
            };
            o4.Options.Add(o4_r);
            var o4_f = new Option<Type.BingDailyType.Format>("--format")
            {
                Required = false, Description = "指定返回的格式, 默认二进制byte[], 可选302重定向后的图片URL的二进制byte[]",
                DefaultValueFactory = _ => Type.BingDailyType.Format.image
            };
            o4.Options.Add(o4_f);
            o4.SetAction(parseResult =>
            {
                var resolutions = parseResult.GetValue(o4_r);
                var format = parseResult.GetValue(o4_f);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetBingDailyImage(true, resolutions, format, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            #endregion

            var o5 = CliCommandTree.GetOrAdd(root, new[] { "image", "bing-daily", "history" });
            o5.Description = "获取必应每日壁纸历史列表";
            var o5_d = new Option<string>("--date")
            {
                Required = false, Description = "指定日期精确查询 (YYYY-MM-DD)，传此参数时 page/pageSize 不生效",
                DefaultValueFactory = _ => ""
            };
            o5.Options.Add(o5_d);
            var o5_r = new Option<Type.BingDailyType.Resolutions>("--resolution")
            {
                Required = false, Description = "指定返回图像的分辨率，默认 4K",
                DefaultValueFactory = _ => Type.BingDailyType.Resolutions._4K
            };
            o5.Options.Add(o5_r);
            var o5_p = new Option<int>("--page")
            {
                Required = false, Description = "页码，默认 1", DefaultValueFactory = _ => 1
            };
            o5.Options.Add(o5_p);
            var o5_ps = new Option<int>("--page-size")
            {
                Required = false, Description = "每页数量，默认 30，最大 100", DefaultValueFactory = _ => 30
            };
            o5.Options.Add(o5_ps);
            o5.SetAction(parseResult =>
            {
                var date = parseResult.GetValue(o5_d);
                var resolution = parseResult.GetValue(o5_r);
                var page = parseResult.GetValue(o5_p);
                var pageSize = parseResult.GetValue(o5_ps);
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