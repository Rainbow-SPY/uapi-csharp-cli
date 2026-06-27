using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_minecraft_GetUserData
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_minecraft_user_data_1 = CliCommandTree.GetOrAdd(root, new[] { "minecraft", "user-data" });
            cmd_minecraft_user_data_1.Description = "获取 Minecraft 正版 Mojang 账号的数据";
            var opt_minecraft_user_data_1_username = new Option<string>("--username")
            {
                Required = true, Description = "Minecraft 用户名"
            };
            cmd_minecraft_user_data_1.Options.Add(opt_minecraft_user_data_1_username);
            cmd_minecraft_user_data_1.SetAction(async parseResult =>
            {
                var username = parseResult.GetValue(opt_minecraft_user_data_1_username);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Minecraft.GetUserData(username, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}