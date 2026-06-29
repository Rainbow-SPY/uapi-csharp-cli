using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_Translate
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_text_translate_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "translate" });
            cmd_text_translate_1.Description = "翻译指定的文本";
            var opt_text_translate_1_Language = new Option<SupportLanguages>("--language")
            {
                Required = true, Description = "指定要翻译的语言代码 (ISO 639-1)"
            };
            cmd_text_translate_1.Options.Add(opt_text_translate_1_Language);
            var opt_text_translate_1_Text = new Option<string>("--text")
            {
                Required = true, Description = "指定要翻译的文本"
            };
            cmd_text_translate_1.Options.Add(opt_text_translate_1_Text);
            cmd_text_translate_1.SetAction(parseResult =>
            {
                var Language = parseResult.GetValue(opt_text_translate_1_Language);
                var Text = parseResult.GetValue(opt_text_translate_1_Text);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = UAPI.Text.Translate(Language, Text, AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}