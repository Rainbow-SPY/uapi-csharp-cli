using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_random_Text
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
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
            cmd_random_string_1.SetAction(async parseResult =>
            {
                var length = parseResult.GetValue(opt_random_string_1_length);
                var stringType = parseResult.GetValue(opt_random_string_1_stringType);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Random.GetString(length, stringType, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}