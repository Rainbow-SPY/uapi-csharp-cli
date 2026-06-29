using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_Convert
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_image_svg_convert_to_bit_image_1 =
                CliCommandTree.GetOrAdd(root, new[] { "image", "svg-convert-to-bit-image" });
            cmd_image_svg_convert_to_bit_image_1.Description = "将 SVG 矢量图转换为位图或矢量图 (POST)";
            var opt_image_svg_convert_to_bit_image_1_svg = new Option<string>("--svg")
            {
                Required = true, Description = "SVG 文件的二进制数据"
            };
            cmd_image_svg_convert_to_bit_image_1.Options.Add(opt_image_svg_convert_to_bit_image_1_svg);
            var opt_image_svg_convert_to_bit_image_1_format = new Option<Type.SVGConvertType.SVGFormat>("--format")
            {
                Required = false, Description = "输出图片格式 (默认 png)",
                DefaultValueFactory = _ => Type.SVGConvertType.SVGFormat.png
            };
            cmd_image_svg_convert_to_bit_image_1.Options.Add(opt_image_svg_convert_to_bit_image_1_format);
            var opt_image_svg_convert_to_bit_image_1_width = new Option<int?>("--width")
            {
                Required = false, Description = "输出宽度 (像素)，不传则保持 SVG 原始宽高比", DefaultValueFactory = _ => null
            };
            cmd_image_svg_convert_to_bit_image_1.Options.Add(opt_image_svg_convert_to_bit_image_1_width);
            var opt_image_svg_convert_to_bit_image_1_height = new Option<int?>("--height")
            {
                Required = false, Description = "输出高度 (像素)，不传则保持 SVG 原始宽高比", DefaultValueFactory = _ => null
            };
            cmd_image_svg_convert_to_bit_image_1.Options.Add(opt_image_svg_convert_to_bit_image_1_height);
            var opt_image_svg_convert_to_bit_image_1_quality = new Option<int>("--quality")
            {
                Required = false, Description = "输出质量 (1-100，默认 90)，仅 JPEG 格式有效", DefaultValueFactory = _ => 90
            };
            cmd_image_svg_convert_to_bit_image_1.Options.Add(opt_image_svg_convert_to_bit_image_1_quality);
            cmd_image_svg_convert_to_bit_image_1.SetAction(parseResult =>
            {
                var svgPath = parseResult.GetValue(opt_image_svg_convert_to_bit_image_1_svg);
                var svg = File.ReadAllBytes(svgPath);
                var format = parseResult.GetValue(opt_image_svg_convert_to_bit_image_1_format);
                var width = parseResult.GetValue(opt_image_svg_convert_to_bit_image_1_width);
                var height = parseResult.GetValue(opt_image_svg_convert_to_bit_image_1_height);
                var quality = parseResult.GetValue(opt_image_svg_convert_to_bit_image_1_quality);
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