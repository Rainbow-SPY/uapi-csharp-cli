using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_random_Text
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "random", "string" });
            o.Description = "生成随机不同格式的字符串";
            var o_l = new Option<int>("--length")
            {
                Required = true, Description = "长度"
            };
            o.Options.Add(o_l);
            var o_t = new Option<Type.RandomStringType.StringType>("--type")
            {
                Required = true, Description = "构成字符串的方式"
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var length = parseResult.GetValue(o_l);
                var stringType = parseResult.GetValue(o_t);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Random.GetString(length, stringType, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}