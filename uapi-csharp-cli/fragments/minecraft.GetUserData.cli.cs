using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_minecraft_GetUserData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "minecraft", "user" });
            o.Description = "获取 Minecraft 正版 Mojang 账号的数据";
            var o_n = new Option<string>("--name")
            {
                Required = true, Description = "Minecraft 用户名"
            };
            o.Options.Add(o_n);
            o.SetAction(parseResult =>
            {
                var username = parseResult.GetValue(o_n);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Minecraft.GetUserData(username, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}