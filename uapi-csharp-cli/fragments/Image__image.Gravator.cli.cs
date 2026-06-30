using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Image_image_Gravator
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "image", "gravator" });
            o.Description = "获取Gravatar头像";
            var o_email = new Option<string>("--email")
            {
                Required = true, Description = "用户的 Email 地址。如果未提供 hash 参数，则此参数为必需"
            };
            o.Options.Add(o_email);
            var o_hash = new Option<string>("--hash")
            {
                Required = true, Description = "用户 Email 地址的小写 MD5 哈希值。如果提供此参数，将忽略 email 参数"
            };
            o.Options.Add(o_hash);
            var o_s = new Option<int>("--s")
            {
                Required = true, Description = "头像的尺寸，单位为像素, 有效范围是 1 到 2048"
            };
            o.Options.Add(o_s);
            var o_d = new Option<Type.GravatorType.dType>("--d")
            {
                Required = false, Description = "当用户没有自己的 Gravatar 头像时，显示的默认头像类型",
                DefaultValueFactory = _ => Type.GravatorType.dType.None
            };
            o.Options.Add(o_d);
            var o_r = new Option<Type.GravatorType.rType>("--r")
            {
                Required = false, Description = "头像分级", DefaultValueFactory = _ => Type.GravatorType.rType.None
            };
            o.Options.Add(o_r);
            o.SetAction(parseResult =>
            {
                var email = parseResult.GetValue(o_email);
                var hash = parseResult.GetValue(o_hash);
                var s = parseResult.GetValue(o_s);
                var d = parseResult.GetValue(o_d);
                var r = parseResult.GetValue(o_r);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Image.GetGravatorImage(email, hash, s, d, r, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteBytes(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}