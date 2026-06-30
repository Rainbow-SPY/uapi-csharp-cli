using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_random_Image
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "random", "image" });
            o.Description = "获取随机图片, 302重定向到图像";
            var oc = new Option<Type.RandomImage>("--category")
            {
                Required = false, Description = "指定图像的主类别", DefaultValueFactory = _ => Type.RandomImage.None
            };
            o.Options.Add(oc);
            var ot = new Option<Type.WallpaperType>("--type")
            {
                Required = false, Description = "指定图像的子类别, 仅 Uapi-Pro 服务器图床支持",
                DefaultValueFactory = _ => Type.WallpaperType.None
            };
            o.Options.Add(ot);
            o.SetAction(parseResult =>
            {
                var category = parseResult.GetValue(oc);
                var type = parseResult.GetValue(ot);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Random.GetImage(category, type, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}