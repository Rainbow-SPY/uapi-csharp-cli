using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_minecraft_GetServerStatus
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_minecraft_server_status_1 = CliCommandTree.GetOrAdd(root, new[] { "minecraft", "server-status" });
            cmd_minecraft_server_status_1.Description = "查询Minecraft游戏服务器";
            var opt_minecraft_server_status_1_server = new Option<string>("--server")
            {
                Required = true, Description = "服务器的IP地址或域名"
            };
            cmd_minecraft_server_status_1.Options.Add(opt_minecraft_server_status_1_server);
            cmd_minecraft_server_status_1.SetAction(async parseResult =>
            {
                var server = parseResult.GetValue(opt_minecraft_server_status_1_server);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Minecraft.GetServerStatus(server, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_minecraft_server_status_by_server_2 =
                CliCommandTree.GetOrAdd(root, new[] { "minecraft", "server-status", "by-server" });
            cmd_minecraft_server_status_by_server_2.Description = "查询Minecraft游戏服务器";
            var opt_minecraft_server_status_by_server_2_server = new Option<string>("--server")
            {
                Required = true, Description = "服务器的IP地址或域名"
            };
            cmd_minecraft_server_status_by_server_2.Options.Add(opt_minecraft_server_status_by_server_2_server);
            cmd_minecraft_server_status_by_server_2.SetAction(async parseResult =>
            {
                var server = parseResult.GetValue(opt_minecraft_server_status_by_server_2_server);
                var result = await Minecraft.GetServerStatus(server);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_minecraft_server_status_by_server_3 =
                CliCommandTree.GetOrAdd(root, new[] { "minecraft", "server-status", "by-server" });
            cmd_minecraft_server_status_by_server_3.Description = "查询Minecraft游戏服务器";
            var opt_minecraft_server_status_by_server_3_server = new Option<string>("--server")
            {
                Required = true, Description = "服务器的IP地址或域名"
            };
            cmd_minecraft_server_status_by_server_3.Options.Add(opt_minecraft_server_status_by_server_3_server);
            var opt_minecraft_server_status_by_server_3_port = new Option<int>("--port")
            {
                Required = false, Description = "端口号", DefaultValueFactory = _ => 25565
            };
            cmd_minecraft_server_status_by_server_3.Options.Add(opt_minecraft_server_status_by_server_3_port);
            cmd_minecraft_server_status_by_server_3.SetAction(async parseResult =>
            {
                var server = parseResult.GetValue(opt_minecraft_server_status_by_server_3_server);
                var port = parseResult.GetValue(opt_minecraft_server_status_by_server_3_port);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Minecraft.GetServerStatus(server, port, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}