using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_CheckSensitiveWords_Analyze
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_sensitive_words_analyze_1 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "sensitive-words", "analyze" });
            cmd_text_sensitive_words_analyze_1.Description = "分析审查敏感词并返回对象";
            var opt_text_sensitive_words_analyze_1_text = new Option<string[]>("--text")
            {
                Required = true, Description = "分析的敏感词"
            };
            cmd_text_sensitive_words_analyze_1.Options.Add(opt_text_sensitive_words_analyze_1_text);
            cmd_text_sensitive_words_analyze_1.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_sensitive_words_analyze_1_text);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = await Text.SensitiveWords.Analyze(text, AuthenticationAPITokenKey);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}