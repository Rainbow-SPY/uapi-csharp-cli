using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_Image_ToBase64
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_image_to_base64_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "to-base64" });
            cmd_image_to_base64_1.Description = "图片转 Base64";
            var opt_image_to_base64_1_url = new Option<string>("--url")
            {
                Required = true, Description = "指定要转换Base 64 的 图像 Url 地址"
            };
            cmd_image_to_base64_1.Options.Add(opt_image_to_base64_1_url);
            cmd_image_to_base64_1.SetAction(parseResult =>
            {
                var url = parseResult.GetValue(opt_image_to_base64_1_url);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.ToBase64(url, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}