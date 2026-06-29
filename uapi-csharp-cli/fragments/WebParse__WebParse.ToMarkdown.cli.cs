using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_WebParse_WebParse_ToMarkdown
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_web_parse_web_to_markdown_async_1 =
                CliCommandTree.GetOrAdd(root, new[] { "web-parse", "web-to-markdown-async" });
            cmd_web_parse_web_to_markdown_async_1.Description = "提交网页转 Markdown 任务 (POST)";
            var opt_web_parse_web_to_markdown_async_1_url = new Option<string>("--url")
            {
                Required = true, Description = "需要转换的网页 URL"
            };
            cmd_web_parse_web_to_markdown_async_1.Options.Add(opt_web_parse_web_to_markdown_async_1_url);
            cmd_web_parse_web_to_markdown_async_1.SetAction(parseResult =>
            {
                var url = parseResult.GetValue(opt_web_parse_web_to_markdown_async_1_url);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = WebParse.PostWebToMarkdownAsync(url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_web_parse_web_to_markdown_result_2 =
                CliCommandTree.GetOrAdd(root, new[] { "web-parse", "web-to-markdown-result" });
            cmd_web_parse_web_to_markdown_result_2.Description = "查询网页转 Markdown 任务结果 (GET)";
            var opt_web_parse_web_to_markdown_result_2_taskId = new Option<string>("--task-id")
            {
                Required = true, Description = "任务 ID（由提交接口返回）"
            };
            cmd_web_parse_web_to_markdown_result_2.Options.Add(opt_web_parse_web_to_markdown_result_2_taskId);
            cmd_web_parse_web_to_markdown_result_2.SetAction(parseResult =>
            {
                var taskId = parseResult.GetValue(opt_web_parse_web_to_markdown_result_2_taskId);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = WebParse.GetWebToMarkdownResult(taskId, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}