using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_CheckSemsitiveWords_Get
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_text_sensitive_words_check_1 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "sensitive-words", "check" });
            cmd_text_sensitive_words_check_1.Description = "分析敏感词 (GET), 仅支持单个字符串, 要使用字符串数组请使用 SensitiveWords.Analyze";
            var opt_text_sensitive_words_check_1_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要识别的敏感词"
            };
            cmd_text_sensitive_words_check_1.Options.Add(opt_text_sensitive_words_check_1_text);
            cmd_text_sensitive_words_check_1.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(opt_text_sensitive_words_check_1_text);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Text.SensitiveWords.GetCheck(text, AuthenticationAPITokenKey).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}