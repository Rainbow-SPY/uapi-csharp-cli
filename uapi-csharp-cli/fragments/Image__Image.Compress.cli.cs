using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_Compress
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "image", "compress" });
            o.Description = "图片无损压缩 (POST)，通过图片二进制数据";
            var o_byte = new Option<string>("--image")
            {
                Required = true, Description = "图片的二进制数据"
            };
            o.Options.Add(o_byte);
            var o_l = new Option<int>("--level")
            {
                Required = false,
                Description = "压缩等级 (1-5)，数字越小压缩率越高 1: 极限压缩（推荐，体积最小，画质优异） 2: 高效压缩 3: 智能均衡（默认） 4: 画质优先 5: 专业保真",
                DefaultValueFactory = _ => 3
            };
            o.Options.Add(o_l);
            o.SetAction(parseResult =>
            {
                var imagePath = parseResult.GetValue(o_byte);
                var image = File.ReadAllBytes(imagePath);
                var level = parseResult.GetValue(o_l);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostImageCompress(image, level, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}