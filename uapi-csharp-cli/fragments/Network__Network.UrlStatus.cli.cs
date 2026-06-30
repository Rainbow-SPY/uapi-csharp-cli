using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_UrlStatus
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "network", "url-status" });
            o.Description = "检查Url的可访问状态";
            var ou = new Option<string>("--url")
            {
                Required = true, Description = "要检查的Url"
            };
            o.Options.Add(ou);
            o.SetAction(parseResult =>
            {
                var Url = parseResult.GetValue(ou);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.CheckUrlStatus(Url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}