using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_WordMetaData
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_word_meta_data_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "word-meta-data" });
            cmd_text_word_meta_data_1.Description = "获取单词元信息";
            cmd_text_word_meta_data_1.SetAction(async parseResult =>
            {
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.GetWordMetaData(Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}