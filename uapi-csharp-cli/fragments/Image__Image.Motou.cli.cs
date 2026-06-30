using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_Motou
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "image", "motou-image", "get" });
            o.Description = "获取摸摸头表情包处理后的图像 (GET)";
            var o_qq = new Option<string>("--qq")
            {
                Required = true, Description = "要摸头的QQ"
            };
            o.Options.Add(o_qq);
            var o_back = new Option<Type.MotouType.BackgroundColor>("--background-color")
            {
                Required = true, Description = "指定图片生成的背景颜色"
            };
            o.Options.Add(o_back);
            o.SetAction(parseResult =>
            {
                var qq = parseResult.GetValue(o_qq);
                var backgroundColor = parseResult.GetValue(o_back);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetMotouImage(qq, backgroundColor, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "image", "motou-image", "post" });
            o2.Description = "上传图片生成摸摸头表情包 (POST)，通过图片URL";
            var o2_url = new Option<string>("--image-url")
            {
                Required = true, Description = "图片URL地址"
            };
            o2.Options.Add(o2_url);
            var o2_back = new Option<Type.MotouType.BackgroundColor>("--background-color")
            {
                Required = true, Description = "指定图片生成的背景颜色"
            };
            o2.Options.Add(o2_back);
            o2.SetAction(parseResult =>
            {
                var imageUrl = parseResult.GetValue(o2_url);
                var backgroundColor =
                    parseResult.GetValue(o2_back);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostMotouImage(imageUrl, backgroundColor, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o3 = CliCommandTree.GetOrAdd(root, new[] { "image", "motou-image", "upload" });
            o3.Description = "上传图片生成摸摸头表情包 (POST)，通过图片二进制数据";
            var o3_img = new Option<string>("--image")
            {
                Required = true, Description = "图片的二进制数据"
            };
            o3.Options.Add(o3_img);
            var o3_back = new Option<Type.MotouType.BackgroundColor>("--background-color")
            {
                Required = true, Description = "指定图片生成的背景颜色"
            };
            o3.Options.Add(o3_back);
            o3.SetAction(parseResult =>
            {
                var imagePath = parseResult.GetValue(o3_img);
                var image = File.ReadAllBytes(imagePath);
                var backgroundColor =
                    parseResult.GetValue(o3_back);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostMotouImage(image, backgroundColor, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}