using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_ToBase64
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_image_to_base64_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "to-base64" });
            cmd_image_to_base64_1.Description = "图片转 Base64";
            var opt_image_to_base64_1_url = new Option<string>("--url")
            {
                Required = true, Description = "指定要转换Base 64 的 图像 Url 地址"
            };
            cmd_image_to_base64_1.Options.Add(opt_image_to_base64_1_url);
            cmd_image_to_base64_1.SetAction(async parseResult =>
            {
                var url = parseResult.GetValue(opt_image_to_base64_1_url);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.ToBase64(url, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}