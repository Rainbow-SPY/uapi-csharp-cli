using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_Translate
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "translate" });
            o.Description = "翻译指定的文本";
            var o_l = new Option<SupportLanguages>("--language")
            {
                Required = true, Description = "指定要翻译的语言代码 (ISO 639-1)"
            };
            o.Options.Add(o_l);
            var o_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要翻译的文本"
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var Language = parseResult.GetValue(o_l);
                var Text = parseResult.GetValue(o_t);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = UAPI.Text.Translate(Language, Text, AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}