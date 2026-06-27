using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_image_Gravator
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_image_gravator_image_1 = CliCommandTree.GetOrAdd(root, new[] { "image", "gravator-image" });
            cmd_image_gravator_image_1.Description = "获取Gravatar头像";
            var opt_image_gravator_image_1_email = new Option<string>("--email")
            {
                Required = true, Description = "用户的 Email 地址。如果未提供 hash 参数，则此参数为必需"
            };
            cmd_image_gravator_image_1.Options.Add(opt_image_gravator_image_1_email);
            var opt_image_gravator_image_1_hash = new Option<string>("--hash")
            {
                Required = true, Description = "用户 Email 地址的小写 MD5 哈希值。如果提供此参数，将忽略 email 参数"
            };
            cmd_image_gravator_image_1.Options.Add(opt_image_gravator_image_1_hash);
            var opt_image_gravator_image_1_s = new Option<int>("--s")
            {
                Required = true, Description = "头像的尺寸，单位为像素, 有效范围是 1 到 2048"
            };
            cmd_image_gravator_image_1.Options.Add(opt_image_gravator_image_1_s);
            var opt_image_gravator_image_1_d = new Option<Type.GravatorType.dType>("--d")
            {
                Required = false, Description = "当用户没有自己的 Gravatar 头像时，显示的默认头像类型",
                DefaultValueFactory = _ => Type.GravatorType.dType.None
            };
            cmd_image_gravator_image_1.Options.Add(opt_image_gravator_image_1_d);
            var opt_image_gravator_image_1_r = new Option<Type.GravatorType.rType>("--r")
            {
                Required = false, Description = "头像分级", DefaultValueFactory = _ => Type.GravatorType.rType.None
            };
            cmd_image_gravator_image_1.Options.Add(opt_image_gravator_image_1_r);
            cmd_image_gravator_image_1.SetAction(async parseResult =>
            {
                var email = parseResult.GetValue(opt_image_gravator_image_1_email);
                var hash = parseResult.GetValue(opt_image_gravator_image_1_hash);
                var s = parseResult.GetValue(opt_image_gravator_image_1_s);
                var d = parseResult.GetValue(opt_image_gravator_image_1_d);
                var r = parseResult.GetValue(opt_image_gravator_image_1_r);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Image.GetGravatorImage(email, hash, s, d, r, Authentication);
                CliOutput.WriteBytes(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}