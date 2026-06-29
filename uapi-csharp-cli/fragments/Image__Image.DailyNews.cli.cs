using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_DailyNews
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_image_daily_news_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "daily-news" });
            cmd_image_daily_news_1.Description = "获取每日新闻图片 (GET)";
            cmd_image_daily_news_1.SetAction(parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetDailyNews(Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}