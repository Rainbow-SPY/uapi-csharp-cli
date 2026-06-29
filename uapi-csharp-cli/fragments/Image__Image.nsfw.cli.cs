using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_nsfw
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_image_nsfw_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "nsfw" });
            cmd_image_nsfw_1.Description = "图像敏感度检查";
            var opt_image_nsfw_1_image = new Option<string>("--image")
            {
                Required = true, Description = "图像的二进制文件"
            };
            cmd_image_nsfw_1.Options.Add(opt_image_nsfw_1_image);
            cmd_image_nsfw_1.SetAction(parseResult =>
            {
                var imagePath = parseResult.GetValue(opt_image_nsfw_1_image);
                var image = File.ReadAllBytes(imagePath);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.CheckImageNSFW(image, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_image_nsfw_by_url_2 = CliCommandTree.GetOrAdd(root, new[] { "image", "nsfw", "by-url" });
            cmd_image_nsfw_by_url_2.Description = "图像敏感度检查";
            var opt_image_nsfw_by_url_2_url = new Option<string>("--url")
            {
                Required = true, Description = "图像的URL地址"
            };
            cmd_image_nsfw_by_url_2.Options.Add(opt_image_nsfw_by_url_2_url);
            cmd_image_nsfw_by_url_2.SetAction(parseResult =>
            {
                var url = parseResult.GetValue(opt_image_nsfw_by_url_2_url);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.CheckImageNSFW(url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}