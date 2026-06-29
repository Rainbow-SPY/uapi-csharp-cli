using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_WordMetaData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_text_word_meta_data_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "word-meta-data" });
            cmd_text_word_meta_data_1.Description = "获取单词元信息";
            cmd_text_word_meta_data_1.SetAction(parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.GetWordMetaData(Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}