using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_AnalyzeText
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_analyze_text_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "analyze-text" });
            cmd_text_analyze_text_1.Description = "分析文本的字符数、词数、句子数、段落数和行数";
            var opt_text_analyze_text_1_texts = new Option<string>("--texts")
            {
                Required = true, Description = "指定要分析的文本"
            };
            cmd_text_analyze_text_1.Options.Add(opt_text_analyze_text_1_texts);
            cmd_text_analyze_text_1.SetAction(async parseResult =>
            {
                var texts = parseResult.GetValue(opt_text_analyze_text_1_texts);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.AnalyzeText(texts, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}