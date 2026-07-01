using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_CheckSensitiveWords_Analyze
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o =
                CliCommandTree.GetOrAdd(root, new[] { "text", "sensitive-words", "analyze" });
            o.Description = "分析审查敏感词并返回对象";
            var o_t = new Option<string[]>("--text")
            {
                Required = true, Description = "分析的敏感词"
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(o_t);
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Text.SensitiveWords.Analyze(text, AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}