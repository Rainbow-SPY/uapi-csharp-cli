using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_image_QRCode
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "image", "qr-code", "bytes" });
            var ot = new Option<string>("--text")
            {
                Required = true
            };
            o.Options.Add(ot);
            var osize = new Option<int>("--size")
            {
                Required = false, DefaultValueFactory = _ => 256
            };
            o.Options.Add(osize);
            var o_t = new Option<bool>("--transparent")
            {
                Required = false, DefaultValueFactory = _ => false
            };
            o.Options.Add(o_t);
            var oa = new Option<string>("--front-color")
            {
                Required = false, DefaultValueFactory = _ => "#000000"
            };
            o.Options.Add(oa);
            var ob = new Option<string>("--background-color")
            {
                Required = false, DefaultValueFactory = _ => "#FFFFFF"
            };
            o.Options.Add(ob);
            o.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(ot);
                var size = parseResult.GetValue(osize);
                var transparent = parseResult.GetValue(o_t);
                var FrontColor = parseResult.GetValue(oa);
                var BackgroundColor = parseResult.GetValue(ob);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.QRCode
                    .GetBytes(text, size, transparent, FrontColor, BackgroundColor, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var oj = CliCommandTree.GetOrAdd(root, new[] { "image", "qr-code", "json" });
            oj.Description = "获取二维码的Json源数据";
            var ojt = new Option<string>("--text")
            {
                Required = true, Description = "你希望编码到二维码中的任何文本内容，比如一个URL、一段话或者一个JSON字符串。"
            };
            oj.Options.Add(ojt);
            var ojsize = new Option<int>("--size")
            {
                Required = false, Description = "二维码图片的边长（正方形），单位是像素。有效范围是 256 到 2048 之间。",
                DefaultValueFactory = _ => 256
            };
            oj.Options.Add(ojsize);
            var ojs = new Option<Type.QRCodeType.Format>("--format")
            {
                Required = false, Description = "指定响应内容的格式。可选值为 `image`, `json`, `json_url`。",
                DefaultValueFactory = _ => Type.QRCodeType.Format.Json
            };
            oj.Options.Add(ojs);
            var oj_t = new Option<bool>("--transparent")
            {
                Required = false, Description = "是否使用透明背景。启用后生成的 PNG 图片将具有 alpha 通道，背景透明",
                DefaultValueFactory = _ => false
            };
            oj.Options.Add(oj_t);
            var ojf = new Option<string>("--front-color")
            {
                Required = false, Description = "二维码前景色（即二维码本身的颜色），使用十六进制格式。", DefaultValueFactory = _ => "#000000"
            };
            oj.Options.Add(ojf);
            var ojb = new Option<string>("--background-color")
            {
                Required = false, Description = "二维码背景色，使用十六进制格式。当 transparent=true 时此参数会被忽略",
                DefaultValueFactory = _ => "#FFFFFF"
            };
            oj.Options.Add(ojb);
            oj.SetAction(parseResult =>
            {
                var text = parseResult.GetValue(ojt);
                var size = parseResult.GetValue(ojsize);
                var format = parseResult.GetValue(ojs);
                var transparent = parseResult.GetValue(oj_t);
                var FrontColor = parseResult.GetValue(ojf);
                var BackgroundColor = parseResult.GetValue(ojb);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.QRCode
                    .GetJson(text, size, format, transparent, FrontColor, BackgroundColor, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}