using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_Saying
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_saying_1 = CliCommandTree.GetOrAdd(root, new[] { "saying" });
            cmd_saying_1.Description = "获取随心一言";
            cmd_saying_1.SetAction(parseResult =>
            {
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = Saying.GetSaying(AuthenticationAPITokenKey).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}