using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Github_GetRepoData
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_github_repos_data_1 = CliCommandTree.GetOrAdd(root, new[] { "github", "repos-data" });
            cmd_github_repos_data_1.Description = "获取github仓库数据";
            var opt_github_repos_data_1_owner_and_repo = new Option<string>("--owner-and-repo")
            {
                Required = true, Description = "所有者+仓库(owner/repo)"
            };
            cmd_github_repos_data_1.Options.Add(opt_github_repos_data_1_owner_and_repo);
            cmd_github_repos_data_1.SetAction(parseResult =>
            {
                var owner_and_repo = parseResult.GetValue(opt_github_repos_data_1_owner_and_repo);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Github.GetReposData(owner_and_repo, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}