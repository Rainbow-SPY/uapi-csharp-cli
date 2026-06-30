using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_OCR
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "image", "ocr" });
            o.Description = "通用 OCR 文字识别 (POST)，通过图片二进制数据";
            var opt_image_ocr_1_image = new Option<string>("--image")
            {
                Required = true, Description = "图片的二进制数据"
            };
            o.Options.Add(opt_image_ocr_1_image);
            var opt_image_ocr_1_needLocation = new Option<bool>("--return-location")
            {
                Required = false, Description = "是否返回坐标信息（默认 true）", DefaultValueFactory = _ => true
            };
            o.Options.Add(opt_image_ocr_1_needLocation);
            var opt_image_ocr_1_enableCls = new Option<bool>("--enable-cls")
            {
                Required = false, Description = "是否启用方向预校正（默认 false，适用于手机拍摄的旋转/倾斜图片）", DefaultValueFactory = _ => false
            };
            o.Options.Add(opt_image_ocr_1_enableCls);
            o.SetAction(parseResult =>
            {
                var imagePath = parseResult.GetValue(opt_image_ocr_1_image);
                var image = File.ReadAllBytes(imagePath);
                var needLocation = parseResult.GetValue(opt_image_ocr_1_needLocation);
                var enableCls = parseResult.GetValue(opt_image_ocr_1_enableCls);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostImageOCR(image, needLocation, enableCls, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}