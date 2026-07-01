using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Steam_Steam_GetUserData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "steam", "user" });
            o.Description = "新版请求Steam Web API Json的方法";
            var o_i = new Option<string>("--id")
            {
                Required = true, Description = "其中一种的 SteamIDType"
            };
            o.Options.Add(o_i);
            var o_k = new Option<string>("--key")
            {
                Required = false, Description = "Steam Web API Key", DefaultValueFactory = _ => null
            };
            o.Options.Add(o_k);
            o.SetAction(parseResult =>
            {
                var SteamID = parseResult.GetValue(o_i);
                var key = parseResult.GetValue(o_k);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Steam.GetUserData(SteamID, key, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}