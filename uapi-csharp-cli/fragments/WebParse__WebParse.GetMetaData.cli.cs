using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_WebParse_WebParse_GetMetaData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_web_parse_web_page_metadata_1 =
                CliCommandTree.GetOrAdd(root, new[] { "web-parse", "web-page-metadata" });
            cmd_web_parse_web_page_metadata_1.Description = "提取网页元数据 (GET)";
            var opt_web_parse_web_page_metadata_1_url = new Option<string>("--url")
            {
                Required = true, Description = "网页 URL"
            };
            cmd_web_parse_web_page_metadata_1.Options.Add(opt_web_parse_web_page_metadata_1_url);
            cmd_web_parse_web_page_metadata_1.SetAction(parseResult =>
            {
                var url = parseResult.GetValue(opt_web_parse_web_page_metadata_1_url);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = WebParse.GetWebPageMetadata(url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}