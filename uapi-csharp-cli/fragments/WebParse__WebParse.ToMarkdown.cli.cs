using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_WebParse_WebParse_ToMarkdown
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o =
                CliCommandTree.GetOrAdd(root, new[] { "web-parse", "web-to-markdown", "post" });
            o.Description = "提交网页转 Markdown 任务 (POST)";
            var o_u = new Option<string>("--url")
            {
                Required = true, Description = "需要转换的网页 URL"
            };
            o.Options.Add(o_u);
            o.SetAction(parseResult =>
            {
                var url = parseResult.GetValue(o_u);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = WebParse.PostWebToMarkdownAsync(url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 =
                CliCommandTree.GetOrAdd(root, new[] { "web-parse", "web-to-markdown", "lookup" });
            o2.Description = "查询网页转 Markdown 任务结果 (GET)";
            var o2_id = new Option<string>("--task-id")
            {
                Required = true, Description = "任务 ID（由提交接口返回）"
            };
            o2.Options.Add(o2_id);
            o2.SetAction(parseResult =>
            {
                var taskId = parseResult.GetValue(o2_id);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = WebParse.GetWebToMarkdownResult(taskId, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}