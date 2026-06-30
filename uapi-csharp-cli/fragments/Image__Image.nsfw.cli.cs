using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_nsfw
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "image", "nsfw" });
            o.Description = "图像敏感度检查";
            var oi_ma = new Option<string>("--image")
            {
                Required = true, Description = "图像的二进制文件"
            };
            o.Options.Add(oi_ma);
            o.SetAction(parseResult =>
            {
                var imagePath = parseResult.GetValue(oi_ma);
                var image = File.ReadAllBytes(imagePath);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.CheckImageNSFW(image, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "image", "nsfw"});
            o2.Description = "图像敏感度检查";
            var o2_url = new Option<string>("--url")
            {
                Required = true, Description = "图像的URL地址"
            };
            o2.Options.Add(o2_url);
            o2.SetAction(parseResult =>
            {
                var url = parseResult.GetValue(o2_url);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.CheckImageNSFW(url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}