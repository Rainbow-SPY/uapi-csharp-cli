using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_text_Markdown
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o =
                CliCommandTree.GetOrAdd(root, new[] { "text", "markdown", "to-html", "json" });
            o.Description = "把 Markdown 文本转换成带样式的 HTML";
            var o_t = new Option<string>("--text")
            {
                Required = true, Description = "原始 Markdown 字符串，最大不超过 1MB。"
            };
            o.Options.Add(o_t);
            var o_s = new Option<bool>("--sanitize")
            {
                Required = false, Description = "是否开启安全模式，过滤掉用户输入中的风险脚本。默认是 true。", DefaultValueFactory = _ => true
            };
            o.Options.Add(o_s);
            o.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o_t);
                var sanitize = parseResult.GetValue(o_s);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Markdown.ToHTML.ReturnedJson(text, sanitize, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "markdown", "to-html", "html" });
            o2.Description = "把 Markdown 文本转换成带样式的 HTML";
            var o2_t = new Option<string>("--text")
            {
                Required = true
            };
            o2.Options.Add(o2_t);
            var o2_s = new Option<bool>("--sanitize")
            {
                Required = false, DefaultValueFactory = _ => true
            };
            o2.Options.Add(o2_s);
            o2.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o2_t);
                var sanitize = parseResult.GetValue(o2_s);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Markdown.ToHTML.ReturnedHTMLCode(text, sanitize, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o3 = CliCommandTree.GetOrAdd(root, new[] { "text", "markdown", "pdf" });
            o3.Description = "转换为可下载的二进制 PDF 文档";
            var o3_t = new Option<string>("--text")
            {
                Required = true
            };
            o3.Options.Add(o3_t);
            var o3_theme = new Option<Type.MarkdownType.Theme>("--theme")
            {
                Required = false, DefaultValueFactory = _ => Type.MarkdownType.Theme.github
            };
            o3.Options.Add(o3_theme);
            var o3_s = new Option<Type.MarkdownType.Size>("--size")
            {
                Required = false, DefaultValueFactory = _ => Type.MarkdownType.Size.A4
            };
            o3.Options.Add(o3_s);
            o3.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o3_t);
                var theme = parseResult.GetValue(o3_theme);
                var size = parseResult.GetValue(o3_s);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.Markdown.ToPDF(text, theme, size, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}