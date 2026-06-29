using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_UrlStatus
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_network_url_status_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "url-status" });
            cmd_network_url_status_1.Description = "检查Url的可访问状态";
            var opt_network_url_status_1_Url = new Option<string>("--url")
            {
                Required = true, Description = "要体检的Url"
            };
            cmd_network_url_status_1.Options.Add(opt_network_url_status_1_Url);
            cmd_network_url_status_1.SetAction(parseResult =>
            {
                var Url = parseResult.GetValue(opt_network_url_status_1_Url);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.CheckUrlStatus(Url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}