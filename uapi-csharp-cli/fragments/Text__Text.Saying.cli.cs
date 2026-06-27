using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_Saying
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_saying_1 = CliCommandTree.GetOrAdd(root, new[] { "saying" });
            cmd_saying_1.Description = "获取随心一言";
            cmd_saying_1.SetAction(async parseResult =>
            {
                var AuthenticationAPITokenKey = parseResult.GetValue(authenticationOption);
                var result = await Saying.GetSaying(AuthenticationAPITokenKey);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}