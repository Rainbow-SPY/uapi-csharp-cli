using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Steam_Steam_Servers
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o_s = CliCommandTree.GetOrAdd(root, new[] { "steam", "find-servers" });
            o_s.Description = "查询 Steam 游戏服务器";
            var o_i = new Option<string>("--appid")
            {
                Required = true, Description = "指定要进行查询的Steam AppID"
            };
            o_s.Options.Add(o_i);
            var o_q = new Option<string>("--query")
            {
                Required = true, Description = "查询的关键词"
            };
            o_s.Options.Add(o_q);
            var o_c = new Option<int>("--count")
            {
                Required = true, Description = "根据关键词返回的服务器数量"
            };
            o_s.Options.Add(o_c);
            o_s.SetAction(parseResult =>
            {
                var appid = parseResult.GetValue(o_i);
                var query = parseResult.GetValue(o_q);
                var count = parseResult.GetValue(o_c);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Steam.FindServers(appid, query, count, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}