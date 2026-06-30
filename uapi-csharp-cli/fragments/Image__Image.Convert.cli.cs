using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_Convert
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o =
                CliCommandTree.GetOrAdd(root, new[] { "image", "convert", "svg-to-bit" });
            o.Description = "将 SVG 矢量图转换为位图或矢量图 (POST)";
            var o_svg = new Option<string>("--svg")
            {
                Required = true, Description = "SVG 文件的二进制数据"
            };
            o.Options.Add(o_svg);
            var o_f = new Option<Type.SVGConvertType.SVGFormat>("--format")
            {
                Required = false, Description = "输出图片格式 (默认 png)",
                DefaultValueFactory = _ => Type.SVGConvertType.SVGFormat.png
            };
            o.Options.Add(o_f);
            var o_w = new Option<int?>("--width")
            {
                Required = false, Description = "输出宽度 (像素)，不传则保持 SVG 原始宽高比", DefaultValueFactory = _ => null
            };
            o.Options.Add(o_w);
            var o_h = new Option<int?>("--height")
            {
                Required = false, Description = "输出高度 (像素)，不传则保持 SVG 原始宽高比", DefaultValueFactory = _ => null
            };
            o.Options.Add(o_h);
            var o_q = new Option<int>("--quality")
            {
                Required = false, Description = "输出质量 (1-100，默认 90)，仅 JPEG 格式有效", DefaultValueFactory = _ => 90
            };
            o.Options.Add(o_q);
            o.SetAction(parseResult =>
            {
                var svgPath = parseResult.GetValue(o_svg);
                var svg = File.ReadAllBytes(svgPath);
                var format = parseResult.GetValue(o_f);
                var width = parseResult.GetValue(o_w);
                var height = parseResult.GetValue(o_h);
                var quality = parseResult.GetValue(o_q);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostSVGConvertToBitImage(svg, format, width, height, quality, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}