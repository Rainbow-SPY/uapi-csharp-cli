using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Minecraft_SearchMod
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "minecraft", "search-mods" });
            o.Description = "搜索 MC Mod/插件";
            var o_q = new Option<string>("--query")
            {
                Required = true, Description = "搜索关键词，也可使用别名 q。"
            };
            o.Options.Add(o_q);
            var o_s = new Option<Type.MinecraftSearchMods.Source>("--source")
            {
                Required = false, Description = "搜索来源，默认 all。",
                DefaultValueFactory = _ => Type.MinecraftSearchMods.Source.all
            };
            o.Options.Add(o_s);
            var o_t = new Option<string>("--type")
            {
                Required = false, Description = "资源类型过滤，例如 mod 或 plugin。", DefaultValueFactory = _ => ""
            };
            o.Options.Add(o_t);
            var o_l = new Option<int>("--limit")
            {
                Required = false, Description = "每个来源返回的最大条数，默认 10，最大 50。", DefaultValueFactory = _ => 10
            };
            o.Options.Add(o_l);
            var o_e = new Option<bool>("--entich")
            {
                Required = false, Description = "是否补全下载直链与作者名，默认 true；传 false 可降低延迟。", DefaultValueFactory = _ => true
            };
            o.Options.Add(o_e);
            o.SetAction(parseResult =>
            {
                var query = parseResult.GetValue(o_q);
                var source = parseResult.GetValue(o_s);
                var type = parseResult.GetValue(o_t);
                var limit = parseResult.GetValue(o_l);
                var entich = parseResult.GetValue(o_e);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Minecraft.SearchMods(query, source, type, limit, entich, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}