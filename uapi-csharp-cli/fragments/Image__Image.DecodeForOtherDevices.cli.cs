using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_DecodeForOtherDevices
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_image_decode_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "decode" });
            cmd_image_decode_1.Description = "解码并缩放图片 (POST)，通过图片二进制数据";
            var opt_image_decode_1_image = new Option<string>("--image")
            {
                Required = true, Description = "图片的二进制数据"
            };
            cmd_image_decode_1.Options.Add(opt_image_decode_1_image);
            var opt_image_decode_1_format = new Option<Type.DecodeForOtherDevicesType.DecodeFormat>("--format")
            {
                Required = false, Description = "输出格式 (默认 bmp)",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.DecodeFormat.bmp
            };
            cmd_image_decode_1.Options.Add(opt_image_decode_1_format);
            var opt_image_decode_1_colorMode = new Option<Type.DecodeForOtherDevicesType.ColorMode>("--color-mode")
            {
                Required = false, Description = "色彩模式 (默认 rgb888)，仅在 format=rgb565/rgb888 时生效",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.ColorMode.rgb888
            };
            cmd_image_decode_1.Options.Add(opt_image_decode_1_colorMode);
            var opt_image_decode_1_width = new Option<int?>("--width")
            {
                Required = false, Description = "目标宽度 (像素)，不传则保持原图比例", DefaultValueFactory = _ => null
            };
            cmd_image_decode_1.Options.Add(opt_image_decode_1_width);
            var opt_image_decode_1_height = new Option<int?>("--height")
            {
                Required = false, Description = "目标高度 (像素)，不传则保持原图比例", DefaultValueFactory = _ => null
            };
            cmd_image_decode_1.Options.Add(opt_image_decode_1_height);
            var opt_image_decode_1_maxWidth = new Option<int?>("--max-width")
            {
                Required = false, Description = "最大宽度 (像素)", DefaultValueFactory = _ => null
            };
            cmd_image_decode_1.Options.Add(opt_image_decode_1_maxWidth);
            var opt_image_decode_1_maxHeight = new Option<int?>("--max-height")
            {
                Required = false, Description = "最大高度 (像素)", DefaultValueFactory = _ => null
            };
            cmd_image_decode_1.Options.Add(opt_image_decode_1_maxHeight);
            var opt_image_decode_1_fit = new Option<Type.DecodeForOtherDevicesType.FitMode>("--fit")
            {
                Required = false, Description = "缩放模式 (默认 contain)",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.FitMode.contain
            };
            cmd_image_decode_1.Options.Add(opt_image_decode_1_fit);
            var opt_image_decode_1_background = new Option<string>("--background")
            {
                Required = false, Description = "填充背景色 (默认 black)，仅 fit=contain 时生效", DefaultValueFactory = _ => "black"
            };
            cmd_image_decode_1.Options.Add(opt_image_decode_1_background);
            cmd_image_decode_1.SetAction(parseResult =>
            {
                var imagePath = parseResult.GetValue(opt_image_decode_1_image);
                var image = File.ReadAllBytes(imagePath);
                var format = parseResult.GetValue(opt_image_decode_1_format);
                var colorMode = parseResult.GetValue(opt_image_decode_1_colorMode);
                var width = parseResult.GetValue(opt_image_decode_1_width);
                var height = parseResult.GetValue(opt_image_decode_1_height);
                var maxWidth = parseResult.GetValue(opt_image_decode_1_maxWidth);
                var maxHeight = parseResult.GetValue(opt_image_decode_1_maxHeight);
                var fit = parseResult.GetValue(opt_image_decode_1_fit);
                var background = parseResult.GetValue(opt_image_decode_1_background);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostImageDecode(image, format, colorMode, width, height, maxWidth, maxHeight,
                    fit, background, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_image_decode_by_image_url_2 =
                CliCommandTree.GetOrAdd(root, new[] { "image", "decode", "by-image-url" });
            cmd_image_decode_by_image_url_2.Description = "解码并缩放图片 (POST)，通过图片链接";
            var opt_image_decode_by_image_url_2_imageUrl = new Option<string>("--image-url")
            {
                Required = true, Description = "图片的公开访问链接"
            };
            cmd_image_decode_by_image_url_2.Options.Add(opt_image_decode_by_image_url_2_imageUrl);
            var opt_image_decode_by_image_url_2_format =
                new Option<Type.DecodeForOtherDevicesType.DecodeFormat>("--format")
                {
                    Required = false, Description = "输出格式 (默认 bmp)",
                    DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.DecodeFormat.bmp
                };
            cmd_image_decode_by_image_url_2.Options.Add(opt_image_decode_by_image_url_2_format);
            var opt_image_decode_by_image_url_2_colorMode =
                new Option<Type.DecodeForOtherDevicesType.ColorMode>("--color-mode")
                {
                    Required = false, Description = "色彩模式 (默认 rgb888)",
                    DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.ColorMode.rgb888
                };
            cmd_image_decode_by_image_url_2.Options.Add(opt_image_decode_by_image_url_2_colorMode);
            var opt_image_decode_by_image_url_2_width = new Option<int?>("--width")
            {
                Required = false, Description = "目标宽度 (像素)", DefaultValueFactory = _ => null
            };
            cmd_image_decode_by_image_url_2.Options.Add(opt_image_decode_by_image_url_2_width);
            var opt_image_decode_by_image_url_2_height = new Option<int?>("--height")
            {
                Required = false, Description = "目标高度 (像素)", DefaultValueFactory = _ => null
            };
            cmd_image_decode_by_image_url_2.Options.Add(opt_image_decode_by_image_url_2_height);
            var opt_image_decode_by_image_url_2_maxWidth = new Option<int?>("--max-width")
            {
                Required = false, Description = "最大宽度 (像素)", DefaultValueFactory = _ => null
            };
            cmd_image_decode_by_image_url_2.Options.Add(opt_image_decode_by_image_url_2_maxWidth);
            var opt_image_decode_by_image_url_2_maxHeight = new Option<int?>("--max-height")
            {
                Required = false, Description = "最大高度 (像素)", DefaultValueFactory = _ => null
            };
            cmd_image_decode_by_image_url_2.Options.Add(opt_image_decode_by_image_url_2_maxHeight);
            var opt_image_decode_by_image_url_2_fit = new Option<Type.DecodeForOtherDevicesType.FitMode>("--fit")
            {
                Required = false, Description = "缩放模式 (默认 contain)",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.FitMode.contain
            };
            cmd_image_decode_by_image_url_2.Options.Add(opt_image_decode_by_image_url_2_fit);
            var opt_image_decode_by_image_url_2_background = new Option<string>("--background")
            {
                Required = false, Description = "填充背景色 (默认 black)", DefaultValueFactory = _ => "black"
            };
            cmd_image_decode_by_image_url_2.Options.Add(opt_image_decode_by_image_url_2_background);
            cmd_image_decode_by_image_url_2.SetAction(parseResult =>
            {
                var imageUrl = parseResult.GetValue(opt_image_decode_by_image_url_2_imageUrl);
                var format = parseResult.GetValue(opt_image_decode_by_image_url_2_format);
                var colorMode = parseResult.GetValue(opt_image_decode_by_image_url_2_colorMode);
                var width = parseResult.GetValue(opt_image_decode_by_image_url_2_width);
                var height = parseResult.GetValue(opt_image_decode_by_image_url_2_height);
                var maxWidth = parseResult.GetValue(opt_image_decode_by_image_url_2_maxWidth);
                var maxHeight = parseResult.GetValue(opt_image_decode_by_image_url_2_maxHeight);
                var fit = parseResult.GetValue(opt_image_decode_by_image_url_2_fit);
                var background = parseResult.GetValue(opt_image_decode_by_image_url_2_background);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostImageDecode(imageUrl, format, colorMode, width, height, maxWidth, maxHeight,
                    fit, background, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}