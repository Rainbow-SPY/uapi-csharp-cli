using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_image_QRCode
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_image_qr_code_bytes_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "qr-code", "bytes" });
            var opt_image_qr_code_bytes_1_text = new Option<string>("--text")
            {
                Required = true
            };
            cmd_image_qr_code_bytes_1.Options.Add(opt_image_qr_code_bytes_1_text);
            var opt_image_qr_code_bytes_1_size = new Option<int>("--size")
            {
                Required = false, DefaultValueFactory = _ => 256
            };
            cmd_image_qr_code_bytes_1.Options.Add(opt_image_qr_code_bytes_1_size);
            var opt_image_qr_code_bytes_1_transparent = new Option<bool>("--transparent")
            {
                Required = false, DefaultValueFactory = _ => false
            };
            cmd_image_qr_code_bytes_1.Options.Add(opt_image_qr_code_bytes_1_transparent);
            var opt_image_qr_code_bytes_1_FrontColor = new Option<string>("--front-color")
            {
                Required = false, DefaultValueFactory = _ => "#000000"
            };
            cmd_image_qr_code_bytes_1.Options.Add(opt_image_qr_code_bytes_1_FrontColor);
            var opt_image_qr_code_bytes_1_BackgroundColor = new Option<string>("--background-color")
            {
                Required = false, DefaultValueFactory = _ => "#FFFFFF"
            };
            cmd_image_qr_code_bytes_1.Options.Add(opt_image_qr_code_bytes_1_BackgroundColor);
            cmd_image_qr_code_bytes_1.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_image_qr_code_bytes_1_text);
                var size = parseResult.GetValue(opt_image_qr_code_bytes_1_size);
                var transparent = parseResult.GetValue(opt_image_qr_code_bytes_1_transparent);
                var FrontColor = parseResult.GetValue(opt_image_qr_code_bytes_1_FrontColor);
                var BackgroundColor = parseResult.GetValue(opt_image_qr_code_bytes_1_BackgroundColor);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.QRCode.GetBytes(text, size, transparent, FrontColor, BackgroundColor,
                    Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });

            var cmd_image_qr_code_json_2 = CliCommandTree.GetOrAdd(root, new[] { "image", "qr-code", "json" });
            cmd_image_qr_code_json_2.Description = "获取二维码的Json源数据";
            var opt_image_qr_code_json_2_text = new Option<string>("--text")
            {
                Required = true, Description = "你希望编码到二维码中的任何文本内容，比如一个URL、一段话或者一个JSON字符串。"
            };
            cmd_image_qr_code_json_2.Options.Add(opt_image_qr_code_json_2_text);
            var opt_image_qr_code_json_2_size = new Option<int>("--size")
            {
                Required = false, Description = "二维码图片的边长（正方形），单位是像素。有效范围是 256 到 2048 之间。",
                DefaultValueFactory = _ => 256
            };
            cmd_image_qr_code_json_2.Options.Add(opt_image_qr_code_json_2_size);
            var opt_image_qr_code_json_2_format = new Option<Type.QRCodeType.Format>("--format")
            {
                Required = false, Description = "指定响应内容的格式。可选值为 `image`, `json`, `json_url`。",
                DefaultValueFactory = _ => Type.QRCodeType.Format.Json
            };
            cmd_image_qr_code_json_2.Options.Add(opt_image_qr_code_json_2_format);
            var opt_image_qr_code_json_2_transparent = new Option<bool>("--transparent")
            {
                Required = false, Description = "是否使用透明背景。启用后生成的 PNG 图片将具有 alpha 通道，背景透明",
                DefaultValueFactory = _ => false
            };
            cmd_image_qr_code_json_2.Options.Add(opt_image_qr_code_json_2_transparent);
            var opt_image_qr_code_json_2_FrontColor = new Option<string>("--front-color")
            {
                Required = false, Description = "二维码前景色（即二维码本身的颜色），使用十六进制格式。", DefaultValueFactory = _ => "#000000"
            };
            cmd_image_qr_code_json_2.Options.Add(opt_image_qr_code_json_2_FrontColor);
            var opt_image_qr_code_json_2_BackgroundColor = new Option<string>("--background-color")
            {
                Required = false, Description = "二维码背景色，使用十六进制格式。当 transparent=true 时此参数会被忽略",
                DefaultValueFactory = _ => "#FFFFFF"
            };
            cmd_image_qr_code_json_2.Options.Add(opt_image_qr_code_json_2_BackgroundColor);
            cmd_image_qr_code_json_2.SetAction(async parseResult =>
            {
                var text = parseResult.GetValue(opt_image_qr_code_json_2_text);
                var size = parseResult.GetValue(opt_image_qr_code_json_2_size);
                var format = parseResult.GetValue(opt_image_qr_code_json_2_format);
                var transparent = parseResult.GetValue(opt_image_qr_code_json_2_transparent);
                var FrontColor = parseResult.GetValue(opt_image_qr_code_json_2_FrontColor);
                var BackgroundColor = parseResult.GetValue(opt_image_qr_code_json_2_BackgroundColor);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.QRCode.GetJson(text, size, format, transparent, FrontColor, BackgroundColor,
                    Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}