using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_WebParse_WebParse_ExtractImages
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_web_parse_web_page_images_1 =
                CliCommandTree.GetOrAdd(root, new[] { "web-parse", "web-page-images" });
            cmd_web_parse_web_page_images_1.Description = "提取网页图片 (GET)";
            var opt_web_parse_web_page_images_1_url = new Option<string>("--url")
            {
                Required = true, Description = "网页 URL"
            };
            cmd_web_parse_web_page_images_1.Options.Add(opt_web_parse_web_page_images_1_url);
            cmd_web_parse_web_page_images_1.SetAction(async parseResult =>
            {
                var url = parseResult.GetValue(opt_web_parse_web_page_images_1_url);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await WebParse.GetWebPageImages(url, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}