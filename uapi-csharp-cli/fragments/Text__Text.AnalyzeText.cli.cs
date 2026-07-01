using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_AnalyzeText
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "analyze-text" });
            o.Description = "分析文本的字符数、词数、句子数、段落数和行数";
            var o_t = new Option<string>("--texts")
            {
                Required = true, Description = "指定要分析的文本"
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var texts = parseResult.GetValue(o_t);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AnalyzeText(texts, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}