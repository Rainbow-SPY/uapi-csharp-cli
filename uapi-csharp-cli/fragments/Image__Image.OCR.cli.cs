using System.CommandLine;
using System.IO;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_OCR
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_image_ocr_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "ocr" });
            cmd_image_ocr_1.Description = "通用 OCR 文字识别 (POST)，通过图片二进制数据";
            var opt_image_ocr_1_image = new Option<string>("--image")
            {
                Required = true, Description = "图片的二进制数据"
            };
            cmd_image_ocr_1.Options.Add(opt_image_ocr_1_image);
            var opt_image_ocr_1_needLocation = new Option<bool>("--need-location")
            {
                Required = false, Description = "是否返回坐标信息（默认 true）", DefaultValueFactory = _ => true
            };
            cmd_image_ocr_1.Options.Add(opt_image_ocr_1_needLocation);
            var opt_image_ocr_1_enableCls = new Option<bool>("--enable-cls")
            {
                Required = false, Description = "是否启用方向预校正（默认 false，适用于手机拍摄的旋转/倾斜图片）", DefaultValueFactory = _ => false
            };
            cmd_image_ocr_1.Options.Add(opt_image_ocr_1_enableCls);
            cmd_image_ocr_1.SetAction(parseResult =>
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

            var cmd_image_ocr_by_image_url_2 = CliCommandTree.GetOrAdd(root, new[] { "image", "ocr", "by-image-url" });
            cmd_image_ocr_by_image_url_2.Description = "通用 OCR 文字识别 (POST)，通过图片 URL";
            var opt_image_ocr_by_image_url_2_imageUrl = new Option<string>("--image-url")
            {
                Required = true, Description = "图片的 URL 地址"
            };
            cmd_image_ocr_by_image_url_2.Options.Add(opt_image_ocr_by_image_url_2_imageUrl);
            var opt_image_ocr_by_image_url_2_needLocation = new Option<bool>("--need-location")
            {
                Required = false, Description = "是否返回坐标信息（默认 true）", DefaultValueFactory = _ => true
            };
            cmd_image_ocr_by_image_url_2.Options.Add(opt_image_ocr_by_image_url_2_needLocation);
            var opt_image_ocr_by_image_url_2_enableCls = new Option<bool>("--enable-cls")
            {
                Required = false, Description = "是否启用方向预校正（默认 false，适用于手机拍摄的旋转/倾斜图片）", DefaultValueFactory = _ => false
            };
            cmd_image_ocr_by_image_url_2.Options.Add(opt_image_ocr_by_image_url_2_enableCls);
            cmd_image_ocr_by_image_url_2.SetAction(parseResult =>
            {
                var imageUrl = parseResult.GetValue(opt_image_ocr_by_image_url_2_imageUrl);
                var needLocation = parseResult.GetValue(opt_image_ocr_by_image_url_2_needLocation);
                var enableCls = parseResult.GetValue(opt_image_ocr_by_image_url_2_enableCls);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.PostImageOCR(imageUrl, needLocation, enableCls, Authentication).GetAwaiter()
                    .GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}