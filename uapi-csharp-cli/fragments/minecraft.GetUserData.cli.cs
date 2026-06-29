using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_minecraft_GetUserData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_minecraft_user_data_1 = CliCommandTree.GetOrAdd(root, new[] { "minecraft", "user-data" });
            cmd_minecraft_user_data_1.Description = "获取 Minecraft 正版 Mojang 账号的数据";
            var opt_minecraft_user_data_1_username = new Option<string>("--username")
            {
                Required = true, Description = "Minecraft 用户名"
            };
            cmd_minecraft_user_data_1.Options.Add(opt_minecraft_user_data_1_username);
            cmd_minecraft_user_data_1.SetAction(parseResult =>
            {
                var username = parseResult.GetValue(opt_minecraft_user_data_1_username);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Minecraft.GetUserData(username, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}