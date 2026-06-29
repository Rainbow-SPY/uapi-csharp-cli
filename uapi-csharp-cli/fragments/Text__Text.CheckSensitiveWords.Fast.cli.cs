using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_CheckSensitiveWords_Fast
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_text_sensitive_words_fast_1 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "sensitive-words", "fast" });
            cmd_text_sensitive_words_fast_1.Description = "快速检测审查敏感词 (POST)";
            var opt_text_sensitive_words_fast_1_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要审查的文本"
            };
            cmd_text_sensitive_words_fast_1.Options.Add(opt_text_sensitive_words_fast_1_text);
            cmd_text_sensitive_words_fast_1.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(opt_text_sensitive_words_fast_1_text);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Text.SensitiveWords.CheckFast(text, AuthenticationAPITokenKey).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}