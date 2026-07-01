using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_CheckSemsitiveWords_Get
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "sensitive-words", "check" });
            o.Description = "分析敏感词 (GET), 仅支持单个字符串, 要使用字符串数组请使用 SensitiveWords.Analyze";
            var o_t = new Option<string>("--text")
            {
                Required = true, Description = "指定要识别的敏感词"
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o_t);
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