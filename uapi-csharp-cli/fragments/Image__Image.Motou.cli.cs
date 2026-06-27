using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_Motou
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_image_motou_image_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "motou-image" });
            cmd_image_motou_image_1.Description = "获取摸摸头表情包处理后的图像 (GET)";
            var opt_image_motou_image_1_qq = new Option<string>("--qq")
            {
                Required = true, Description = "要摸头的QQ"
            };
            cmd_image_motou_image_1.Options.Add(opt_image_motou_image_1_qq);
            var opt_image_motou_image_1_backgroundColor =
                new Option<Type.MotouType.BackgroundColor>("--background-color")
                {
                    Required = true, Description = "指定图片生成的背景颜色"
                };
            cmd_image_motou_image_1.Options.Add(opt_image_motou_image_1_backgroundColor);
            cmd_image_motou_image_1.SetAction(async parseResult =>
            {
                var qq = parseResult.GetValue(opt_image_motou_image_1_qq);
                var backgroundColor = parseResult.GetValue(opt_image_motou_image_1_backgroundColor);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.GetMotouImage(qq, backgroundColor, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_image_motou_image_by_image_url_background_color_2 = CliCommandTree.GetOrAdd(root,
                new[] { "image", "motou-image", "by-image-url-background-color" });
            cmd_image_motou_image_by_image_url_background_color_2.Description = "上传图片生成摸摸头表情包 (POST)，通过图片URL";
            var opt_image_motou_image_by_image_url_background_color_2_imageUrl = new Option<string>("--image-url")
            {
                Required = true, Description = "图片URL地址"
            };
            cmd_image_motou_image_by_image_url_background_color_2.Options.Add(
                opt_image_motou_image_by_image_url_background_color_2_imageUrl);
            var opt_image_motou_image_by_image_url_background_color_2_backgroundColor =
                new Option<Type.MotouType.BackgroundColor>("--background-color")
                {
                    Required = true, Description = "指定图片生成的背景颜色"
                };
            cmd_image_motou_image_by_image_url_background_color_2.Options.Add(
                opt_image_motou_image_by_image_url_background_color_2_backgroundColor);
            cmd_image_motou_image_by_image_url_background_color_2.SetAction(async parseResult =>
            {
                var imageUrl = parseResult.GetValue(opt_image_motou_image_by_image_url_background_color_2_imageUrl);
                var backgroundColor =
                    parseResult.GetValue(opt_image_motou_image_by_image_url_background_color_2_backgroundColor);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.PostMotouImage(imageUrl, backgroundColor, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_image_motou_image_by_image_background_color_3 = CliCommandTree.GetOrAdd(root,
                new[] { "image", "motou-image", "by-image-background-color" });
            cmd_image_motou_image_by_image_background_color_3.Description = "上传图片生成摸摸头表情包 (POST)，通过图片二进制数据";
            var opt_image_motou_image_by_image_background_color_3_image = new Option<string>("--image")
            {
                Required = true, Description = "图片的二进制数据"
            };
            cmd_image_motou_image_by_image_background_color_3.Options.Add(
                opt_image_motou_image_by_image_background_color_3_image);
            var opt_image_motou_image_by_image_background_color_3_backgroundColor =
                new Option<Type.MotouType.BackgroundColor>("--background-color")
                {
                    Required = true, Description = "指定图片生成的背景颜色"
                };
            cmd_image_motou_image_by_image_background_color_3.Options.Add(
                opt_image_motou_image_by_image_background_color_3_backgroundColor);
            cmd_image_motou_image_by_image_background_color_3.SetAction(async parseResult =>
            {
                var imagePath = parseResult.GetValue(opt_image_motou_image_by_image_background_color_3_image);
                var image = File.ReadAllBytes(imagePath);
                var backgroundColor =
                    parseResult.GetValue(opt_image_motou_image_by_image_background_color_3_backgroundColor);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.PostMotouImage(image, backgroundColor, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}