using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_minecraft_GetServerStatus
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "minecraft", "server" });
            o.Description = "查询Minecraft游戏服务器";
            var o_ip = new Option<string>("--ip")
            {
                Required = true, Description = "服务器的IP地址或域名"
            };
            o.Options.Add(o_ip);
            var o_p = new Option<int>("--port")
            {
                Required = false, Description = "端口号", DefaultValueFactory = _ => 25565
            };
            o.Options.Add(o_p);
            o.SetAction(parseResult =>
            {
                var server = parseResult.GetValue(o_ip);
                var port = parseResult.GetValue(o_p);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Minecraft.GetServerStatus(server, port, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}