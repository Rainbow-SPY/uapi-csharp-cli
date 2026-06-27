using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_CheckSensitiveWords_Fast
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_sensitive_words_fast_1 =
                CliCommandTree.GetOrAdd(root, new[] { "text", "sensitive-words", "fast" });
            cmd_text_sensitive_words_fast_1.Description = "快速检测审查敏感词 (POST)";
            var opt_text_sensitive_words_fast_1_text = new Option<string>("--text")
            {
                Required = true, Description = "指定要审查的文本"
            };
            cmd_text_sensitive_words_fast_1.Options.Add(opt_text_sensitive_words_fast_1_text);
            cmd_text_sensitive_words_fast_1.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_text_sensitive_words_fast_1_text);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = await Text.SensitiveWords.CheckFast(text, AuthenticationAPITokenKey);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}