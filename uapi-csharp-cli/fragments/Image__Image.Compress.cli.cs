using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_Compress
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_image_compress_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "compress" });
            cmd_image_compress_1.Description = "图片无损压缩 (POST)，通过图片二进制数据";
            var opt_image_compress_1_image = new Option<string>("--image")
            {
                Required = true, Description = "图片的二进制数据"
            };
            cmd_image_compress_1.Options.Add(opt_image_compress_1_image);
            var opt_image_compress_1_level = new Option<int>("--level")
            {
                Required = false,
                Description = "压缩等级 (1-5)，数字越小压缩率越高 1: 极限压缩（推荐，体积最小，画质优异） 2: 高效压缩 3: 智能均衡（默认） 4: 画质优先 5: 专业保真",
                DefaultValueFactory = _ => 3
            };
            cmd_image_compress_1.Options.Add(opt_image_compress_1_level);
            cmd_image_compress_1.SetAction(async parseResult =>
            {
                var imagePath = parseResult.GetValue(opt_image_compress_1_image);
                var image = File.ReadAllBytes(imagePath);
                var level = parseResult.GetValue(opt_image_compress_1_level);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.PostImageCompress(image, level, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}