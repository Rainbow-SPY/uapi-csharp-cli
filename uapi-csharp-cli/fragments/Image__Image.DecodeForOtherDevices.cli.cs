using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_DecodeForOtherDevices
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "image", "decode", "byte" });
            o.Description = "解码并缩放图片 (POST)，通过图片二进制数据";
            var o_img = new Option<string>("--image")
            {
                Required = true, Description = "图片的二进制数据"
            };
            o.Options.Add(o_img);
            var o_f = new Option<Type.DecodeForOtherDevicesType.DecodeFormat>("--format")
            {
                Required = false, Description = "输出格式 (默认 bmp)",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.DecodeFormat.bmp
            };
            o.Options.Add(o_f);
            var o_m = new Option<Type.DecodeForOtherDevicesType.ColorMode>("--color-mode")
            {
                Required = false, Description = "色彩模式 (默认 rgb888)，仅在 format=rgb565/rgb888 时生效",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.ColorMode.rgb888
            };
            o.Options.Add(o_m);
            var o_w = new Option<int?>("--width")
            {
                Required = false, Description = "目标宽度 (像素)，不传则保持原图比例", DefaultValueFactory = _ => null
            };
            o.Options.Add(o_w);
            var o_h = new Option<int?>("--height")
            {
                Required = false, Description = "目标高度 (像素)，不传则保持原图比例", DefaultValueFactory = _ => null
            };
            o.Options.Add(o_h);
            var o_max_width = new Option<int?>("--max-width")
            {
                Required = false, Description = "最大宽度 (像素)", DefaultValueFactory = _ => null
            };
            o.Options.Add(o_max_width);
            var o_max_height = new Option<int?>("--max-height")
            {
                Required = false, Description = "最大高度 (像素)", DefaultValueFactory = _ => null
            };
            o.Options.Add(o_max_height);
            var o_fit = new Option<Type.DecodeForOtherDevicesType.FitMode>("--fit")
            {
                Required = false, Description = "缩放模式 (默认 contain)",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.FitMode.contain
            };
            o.Options.Add(o_fit);
            var o_back = new Option<string>("--background")
            {
                Required = false, Description = "填充背景色 (默认 black)，仅 fit=contain 时生效", DefaultValueFactory = _ => "black"
            };
            o.Options.Add(o_back);
            o.SetAction(parseResult =>
            {
                var imagePath = parseResult.GetValue(o_img);
                var image = File.ReadAllBytes(imagePath);
                var format = parseResult.GetValue(o_f);
                var colorMode = parseResult.GetValue(o_m);
                var width = parseResult.GetValue(o_w);
                var height = parseResult.GetValue(o_h);
                var maxWidth = parseResult.GetValue(o_max_width);
                var maxHeight = parseResult.GetValue(o_max_height);
                var fit = parseResult.GetValue(o_fit);
                var background = parseResult.GetValue(o_back);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostImageDecode(image, format, colorMode, width, height, maxWidth, maxHeight,
                    fit, background, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 =
                CliCommandTree.GetOrAdd(root, new[] { "image", "decode", "url" });
            o2.Description = "解码并缩放图片 (POST)，通过图片链接";
            var o2_url = new Option<string>("--url")
            {
                Required = true, Description = "图片的公开访问链接"
            };
            o2.Options.Add(o2_url);
            var o2_format = new Option<Type.DecodeForOtherDevicesType.DecodeFormat>("--format")
            {
                Required = false, Description = "输出格式 (默认 bmp)",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.DecodeFormat.bmp
            };
            o2.Options.Add(o2_format);
            var o2_color = new Option<Type.DecodeForOtherDevicesType.ColorMode>("--color-mode")
            {
                Required = false, Description = "色彩模式 (默认 rgb888)",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.ColorMode.rgb888
            };
            o2.Options.Add(o2_color);
            var o2_w = new Option<int?>("--width")
            {
                Required = false, Description = "目标宽度 (像素)", DefaultValueFactory = _ => null
            };
            o2.Options.Add(o2_w);
            var o2_h = new Option<int?>("--height")
            {
                Required = false, Description = "目标高度 (像素)", DefaultValueFactory = _ => null
            };
            o2.Options.Add(o2_h);
            var o2_max_width = new Option<int?>("--max-width")
            {
                Required = false, Description = "最大宽度 (像素)", DefaultValueFactory = _ => null
            };
            o2.Options.Add(o2_max_width);
            var o2_max_height = new Option<int?>("--max-height")
            {
                Required = false, Description = "最大高度 (像素)", DefaultValueFactory = _ => null
            };
            o2.Options.Add(o2_max_height);
            var o2_fit = new Option<Type.DecodeForOtherDevicesType.FitMode>("--fit")
            {
                Required = false, Description = "缩放模式 (默认 contain)",
                DefaultValueFactory = _ => Type.DecodeForOtherDevicesType.FitMode.contain
            };
            o2.Options.Add(o2_fit);
            var o2_back = new Option<string>("--background")
            {
                Required = false, Description = "填充背景色 (默认 black)", DefaultValueFactory = _ => "black"
            };
            o2.Options.Add(o2_back);
            o2.SetAction(parseResult =>
            {
                var imageUrl = parseResult.GetValue(o2_url);
                var format = parseResult.GetValue(o2_format);
                var colorMode = parseResult.GetValue(o2_color);
                var width = parseResult.GetValue(o2_w);
                var height = parseResult.GetValue(o2_h);
                var maxWidth = parseResult.GetValue(o2_max_width);
                var maxHeight = parseResult.GetValue(o2_max_height);
                var fit = parseResult.GetValue(o2_fit);
                var background = parseResult.GetValue(o2_back);
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