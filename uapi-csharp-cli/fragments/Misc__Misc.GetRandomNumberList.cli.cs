using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetRandomNumberList
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "misc", "random-number" });
            o.Description = "获取一组随机数字";
            var o_min = new Option<int>("--min")
            {
                Required = false, Description = "生成随机数的最小值(包含)。", DefaultValueFactory = _ => 0
            };
            o.Options.Add(o_min);
            var o_max = new Option<int>("--max")
            {
                Required = false, Description = "生成随机数的最大值(包含)。", DefaultValueFactory = _ => 0
            };
            o.Options.Add(o_max);
            var o_c = new Option<int>("--count")
            {
                Required = false, Description = "需要生成的随机数的数量。", DefaultValueFactory = _ => 0
            };
            o.Options.Add(o_c);
            var o_al = new Option<bool>("--allow-repeat")
            {
                Required = false, Description = "是否允许生成的多个数字中出现重复值。", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_al);
            var o_de = new Option<bool>("--allow-decimal")
            {
                Required = false, Description = "是否生成小(浮点)数。如果为 false，则只生成整数。", DefaultValueFactory = _ => false
            };
            o.Options.Add(o_de);
            var o_dp = new Option<int>("--decimal-places")
            {
                Required = false, Description = "如果 allow_decimal=true，这里可以指定小数的位数。", DefaultValueFactory = _ => 0
            };
            o.Options.Add(o_dp);
            o.SetAction(parseResult =>
            {
                var min = parseResult.GetValue(o_min);
                var max = parseResult.GetValue(o_max);
                var count = parseResult.GetValue(o_c);
                var allow_repeat = parseResult.GetValue(o_al);
                var allow_decimal = parseResult.GetValue(o_de);
                var decimal_places = parseResult.GetValue(o_dp);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc
                    .GetRandomNumberList(min, max, count, allow_repeat, allow_decimal, decimal_places, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var o2 = CliCommandTree.GetOrAdd(root, new[] { "random", "number" });
            var o2_min = new Option<int>("--min")
            {
                Required = false, DefaultValueFactory = _ => 0
            };
            o2.Options.Add(o2_min);
            var o2_max = new Option<int>("--max")
            {
                Required = false, DefaultValueFactory = _ => 0
            };
            o2.Options.Add(o2_max);
            var o2_c = new Option<int>("--count")
            {
                Required = false, DefaultValueFactory = _ => 0
            };
            o2.Options.Add(o2_c);
            var o2_ar = new Option<bool>("--allow-repeat")
            {
                Required = false, DefaultValueFactory = _ => false
            };
            o2.Options.Add(o2_ar);
            var o2_ad = new Option<bool>("--allow-decimal")
            {
                Required = false, DefaultValueFactory = _ => false
            };
            o2.Options.Add(o2_ad);
            var o2_dp = new Option<int>("--decimal-places")
            {
                Required = false, DefaultValueFactory = _ => 0
            };
            o2.Options.Add(o2_dp);
            o2.SetAction(parseResult =>
            {
                var min = parseResult.GetValue(o2_min);
                var max = parseResult.GetValue(o2_max);
                var count = parseResult.GetValue(o2_c);
                var allow_repeat = parseResult.GetValue(o2_ar);
                var allow_decimal = parseResult.GetValue(o2_ad);
                var decimal_places = parseResult.GetValue(o2_dp);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Random
                    .GetNumberList(min, max, count, allow_repeat, allow_decimal, decimal_places, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}