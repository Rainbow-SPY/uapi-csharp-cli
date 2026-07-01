using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_WebParse_WebParse_GetMetaData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o =
                CliCommandTree.GetOrAdd(root, new[] { "web-parse", "web-page-metadata" });
            o.Description = "提取网页元数据 (GET)";
            var o_u = new Option<string>("--url")
            {
                Required = true, Description = "网页 URL"
            };
            o.Options.Add(o_u);
            o.SetAction(parseResult =>
            {
                var url = parseResult.GetValue(o_u);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = WebParse.GetWebPageMetadata(url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}