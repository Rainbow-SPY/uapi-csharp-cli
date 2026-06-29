using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_random_Text
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_random_string_1 = CliCommandTree.GetOrAdd(root, new[] { "random", "string" });
            cmd_random_string_1.Description = "生成随机不同格式的字符串";
            var opt_random_string_1_length = new Option<int>("--length")
            {
                Required = true, Description = "长度"
            };
            cmd_random_string_1.Options.Add(opt_random_string_1_length);
            var opt_random_string_1_stringType = new Option<Type.RandomStringType.StringType>("--string-type")
            {
                Required = true, Description = "构成字符串的方式"
            };
            cmd_random_string_1.Options.Add(opt_random_string_1_stringType);
            cmd_random_string_1.SetAction(parseResult =>
            {
                var length = parseResult.GetValue(opt_random_string_1_length);
                var stringType = parseResult.GetValue(opt_random_string_1_stringType);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Random.GetString(length, stringType, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}