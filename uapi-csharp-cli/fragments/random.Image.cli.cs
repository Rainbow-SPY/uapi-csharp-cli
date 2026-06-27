using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_random_Image
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_random_image_1 = CliCommandTree.GetOrAdd(root, new[] { "random", "image" });
            cmd_random_image_1.Description = "获取随机图片, 302重定向到图像";
            var opt_random_image_1_category = new Option<Type.RandomImage>("--category")
            {
                Required = false, Description = "指定图像的主类别", DefaultValueFactory = _ => Type.RandomImage.None
            };
            cmd_random_image_1.Options.Add(opt_random_image_1_category);
            var opt_random_image_1_type = new Option<Type.WallpaperType>("--type")
            {
                Required = false, Description = "指定图像的子类别, 仅 Uapi-Pro 服务器图床支持",
                DefaultValueFactory = _ => Type.WallpaperType.None
            };
            cmd_random_image_1.Options.Add(opt_random_image_1_type);
            cmd_random_image_1.SetAction(async parseResult =>
            {
                var category = parseResult.GetValue(opt_random_image_1_category);
                var type = parseResult.GetValue(opt_random_image_1_type);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Random.GetImage(category, type, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}