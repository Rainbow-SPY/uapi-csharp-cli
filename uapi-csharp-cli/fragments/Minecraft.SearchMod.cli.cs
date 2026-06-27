using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Minecraft_SearchMod
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_minecraft_search_mods_1 = CliCommandTree.GetOrAdd(root, new[] { "minecraft", "search-mods" });
            cmd_minecraft_search_mods_1.Description = "搜索 MC Mod/插件";
            var opt_minecraft_search_mods_1_query = new Option<string>("--query")
            {
                Required = true, Description = "搜索关键词，也可使用别名 q。"
            };
            cmd_minecraft_search_mods_1.Options.Add(opt_minecraft_search_mods_1_query);
            var opt_minecraft_search_mods_1_source = new Option<Type.MinecraftSearchMods.Source>("--source")
            {
                Required = false, Description = "搜索来源，默认 all。",
                DefaultValueFactory = _ => Type.MinecraftSearchMods.Source.all
            };
            cmd_minecraft_search_mods_1.Options.Add(opt_minecraft_search_mods_1_source);
            var opt_minecraft_search_mods_1_type = new Option<string>("--type")
            {
                Required = false, Description = "资源类型过滤，例如 mod 或 plugin。", DefaultValueFactory = _ => ""
            };
            cmd_minecraft_search_mods_1.Options.Add(opt_minecraft_search_mods_1_type);
            var opt_minecraft_search_mods_1_limit = new Option<int>("--limit")
            {
                Required = false, Description = "每个来源返回的最大条数，默认 10，最大 50。", DefaultValueFactory = _ => 10
            };
            cmd_minecraft_search_mods_1.Options.Add(opt_minecraft_search_mods_1_limit);
            var opt_minecraft_search_mods_1_entich = new Option<bool>("--entich")
            {
                Required = false, Description = "是否补全下载直链与作者名，默认 true；传 false 可降低延迟。", DefaultValueFactory = _ => true
            };
            cmd_minecraft_search_mods_1.Options.Add(opt_minecraft_search_mods_1_entich);
            cmd_minecraft_search_mods_1.SetAction(async parseResult =>
            {
                var query = parseResult.GetValue(opt_minecraft_search_mods_1_query);
                var source = parseResult.GetValue(opt_minecraft_search_mods_1_source);
                var type = parseResult.GetValue(opt_minecraft_search_mods_1_type);
                var limit = parseResult.GetValue(opt_minecraft_search_mods_1_limit);
                var entich = parseResult.GetValue(opt_minecraft_search_mods_1_entich);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Minecraft.SearchMods(query, source, type, limit, entich, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}