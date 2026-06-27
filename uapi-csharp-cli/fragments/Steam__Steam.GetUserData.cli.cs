using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Steam_Steam_GetUserData
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_steam_user_data_1 = CliCommandTree.GetOrAdd(root, new[] { "steam", "user-data" });
            cmd_steam_user_data_1.Description = "新版请求Steam Web API Json的方法";
            var opt_steam_user_data_1_SteamID = new Option<string>("--steam-id")
            {
                Required = true, Description = "其中一种的 SteamIDType"
            };
            cmd_steam_user_data_1.Options.Add(opt_steam_user_data_1_SteamID);
            var opt_steam_user_data_1_key = new Option<string>("--key")
            {
                Required = false, Description = "Steam Web API Key", DefaultValueFactory = _ => null
            };
            cmd_steam_user_data_1.Options.Add(opt_steam_user_data_1_key);
            cmd_steam_user_data_1.SetAction(async parseResult =>
            {
                var SteamID = parseResult.GetValue(opt_steam_user_data_1_SteamID);
                var key = parseResult.GetValue(opt_steam_user_data_1_key);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Steam.GetUserData(SteamID, key, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}