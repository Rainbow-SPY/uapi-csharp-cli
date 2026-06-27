using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_DailyNews
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_image_daily_news_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "daily-news" });
            cmd_image_daily_news_1.Description = "获取每日新闻图片 (GET)";
            cmd_image_daily_news_1.SetAction(async parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.GetDailyNews(Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}