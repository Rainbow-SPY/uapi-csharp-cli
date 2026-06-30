using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Github_GetRepoData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "github", "repo" });
            o.Description = "获取github仓库数据";
            var o_repo = new Option<string>("--repo")
            {
                Required = true, Description = "所有者+仓库(owner/repo)"
            };
            o.Options.Add(o_repo);
            o.SetAction(parseResult =>
            {
                var owner_and_repo = parseResult.GetValue(o_repo);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Github.GetReposData(owner_and_repo, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}