using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_QQ_GetUserData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "qq", "user" });
            o.Description = "获取QQ用户公开摘要";
            var oq = new Option<string>("--qq")
            {
                Required = true, Description = "QQ号"
            };
            o.Options.Add(oq);
            o.SetAction(parseResult =>
            {
                var qq = parseResult.GetValue(oq);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = QQ.GetUserData(qq, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}