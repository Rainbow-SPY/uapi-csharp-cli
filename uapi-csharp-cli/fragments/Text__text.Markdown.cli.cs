using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_text_Markdown
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_markdown_to_html_ed_json_1 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "markdown", "to-html", "ed-json" });
            cmd_text_markdown_to_html_ed_json_1.Description = "把 Markdown 文本转换成带样式的 HTML";
            var opt_text_markdown_to_html_ed_json_1_text = new Option<string>("--text")
            {
                Required = true, Description = "原始 Markdown 字符串，最大不超过 1MB。"
            };
            cmd_text_markdown_to_html_ed_json_1.Options.Add(opt_text_markdown_to_html_ed_json_1_text);
            var opt_text_markdown_to_html_ed_json_1_sanitize = new Option<bool>("--sanitize")
            {
                Required = false, Description = "是否开启安全模式，过滤掉用户输入中的风险脚本。默认是 true。", DefaultValueFactory = _ => true
            };
            cmd_text_markdown_to_html_ed_json_1.Options.Add(opt_text_markdown_to_html_ed_json_1_sanitize);
            cmd_text_markdown_to_html_ed_json_1.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_markdown_to_html_ed_json_1_text);
                var sanitize = parseResult.GetValue(opt_text_markdown_to_html_ed_json_1_sanitize);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Markdown.ToHTML.ReturnedJson(text, sanitize, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_markdown_to_html_ed_html_code_2 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "markdown", "to-html", "ed-html-code" });
            cmd_text_markdown_to_html_ed_html_code_2.Description = "把 Markdown 文本转换成带样式的 HTML";
            var opt_text_markdown_to_html_ed_html_code_2_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_text_markdown_to_html_ed_html_code_2.Options.Add(opt_text_markdown_to_html_ed_html_code_2_text);
            var opt_text_markdown_to_html_ed_html_code_2_sanitize = new Option<bool>("--sanitize")
            {
                Required = false, DefaultValueFactory = _ => true
            };
            cmd_text_markdown_to_html_ed_html_code_2.Options.Add(opt_text_markdown_to_html_ed_html_code_2_sanitize);
            cmd_text_markdown_to_html_ed_html_code_2.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_markdown_to_html_ed_html_code_2_text);
                var sanitize = parseResult.GetValue(opt_text_markdown_to_html_ed_html_code_2_sanitize);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Markdown.ToHTML.ReturnedHTMLCode(text, sanitize, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_text_markdown_to_pdf_3 = CliCommandTree.GetOrAdd(root, new[] { "text", "markdown", "to-pdf" });
            cmd_text_markdown_to_pdf_3.Description = "转换为可下载的二进制 PDF 文档";
            var opt_text_markdown_to_pdf_3_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_text_markdown_to_pdf_3.Options.Add(opt_text_markdown_to_pdf_3_text);
            var opt_text_markdown_to_pdf_3_theme = new Option<Type.MarkdownType.Theme>("--theme")
            {
                Required = false, DefaultValueFactory = _ => Type.MarkdownType.Theme.github
            };
            cmd_text_markdown_to_pdf_3.Options.Add(opt_text_markdown_to_pdf_3_theme);
            var opt_text_markdown_to_pdf_3_size = new Option<Type.MarkdownType.Size>("--size")
            {
                Required = false, DefaultValueFactory = _ => Type.MarkdownType.Size.A4
            };
            cmd_text_markdown_to_pdf_3.Options.Add(opt_text_markdown_to_pdf_3_size);
            cmd_text_markdown_to_pdf_3.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_markdown_to_pdf_3_text);
                var theme = parseResult.GetValue(opt_text_markdown_to_pdf_3_theme);
                var size = parseResult.GetValue(opt_text_markdown_to_pdf_3_size);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.Markdown.ToPDF(text, theme, size, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}