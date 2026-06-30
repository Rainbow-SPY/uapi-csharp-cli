using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetWorldTime
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "misc", "world-time" });
            o.Description = "请求获取全球时区的时间";
            var or = new Option<string>("--region")
            {
                Required = true,
                Description = "指定要查询的地区时间, 格式为 七大洲之一/地区或直接输入地区 例: Asia/Shanghai, America/Newyork, Tokyo"
            };
            o.Options.Add(or);
            o.SetAction(parseResult =>
            {
                var region = parseResult.GetValue(or);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc.GetWorldTime(region, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}