using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Steam_Steam_Servers
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_steam_find_servers_1 = CliCommandTree.GetOrAdd(root, new[] { "steam", "find-servers" });
            cmd_steam_find_servers_1.Description = "查询 Steam 游戏服务器";
            var opt_steam_find_servers_1_appid = new Option<string>("--appid")
            {
                Required = true, Description = "指定要进行查询的Steam AppID"
            };
            cmd_steam_find_servers_1.Options.Add(opt_steam_find_servers_1_appid);
            var opt_steam_find_servers_1_query = new Option<string>("--query")
            {
                Required = true, Description = "查询的关键词"
            };
            cmd_steam_find_servers_1.Options.Add(opt_steam_find_servers_1_query);
            var opt_steam_find_servers_1_count = new Option<int>("--count")
            {
                Required = true, Description = "根据关键词返回的服务器数量"
            };
            cmd_steam_find_servers_1.Options.Add(opt_steam_find_servers_1_count);
            cmd_steam_find_servers_1.SetAction(async parseResult =>
            {
                var appid = parseResult.GetValue(opt_steam_find_servers_1_appid);
                var query = parseResult.GetValue(opt_steam_find_servers_1_query);
                var count = parseResult.GetValue(opt_steam_find_servers_1_count);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Steam.FindServers(appid, query, count, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}