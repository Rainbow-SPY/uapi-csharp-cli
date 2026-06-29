using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Misc_Misc_GetRandomNumberList
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var cmd_misc_random_number_list_1 = CliCommandTree.GetOrAdd(root, new[] { "misc", "random-number-list" });
            cmd_misc_random_number_list_1.Description = "获取一组随机数字";
            var opt_misc_random_number_list_1_min = new Option<int>("--min")
            {
                Required = false, Description = "生成随机数的最小值(包含)。", DefaultValueFactory = _ => 0
            };
            cmd_misc_random_number_list_1.Options.Add(opt_misc_random_number_list_1_min);
            var opt_misc_random_number_list_1_max = new Option<int>("--max")
            {
                Required = false, Description = "生成随机数的最大值(包含)。", DefaultValueFactory = _ => 0
            };
            cmd_misc_random_number_list_1.Options.Add(opt_misc_random_number_list_1_max);
            var opt_misc_random_number_list_1_count = new Option<int>("--count")
            {
                Required = false, Description = "需要生成的随机数的数量。", DefaultValueFactory = _ => 0
            };
            cmd_misc_random_number_list_1.Options.Add(opt_misc_random_number_list_1_count);
            var opt_misc_random_number_list_1_allow_repeat = new Option<bool>("--allow-repeat")
            {
                Required = false, Description = "是否允许生成的多个数字中出现重复值。", DefaultValueFactory = _ => false
            };
            cmd_misc_random_number_list_1.Options.Add(opt_misc_random_number_list_1_allow_repeat);
            var opt_misc_random_number_list_1_allow_decimal = new Option<bool>("--allow-decimal")
            {
                Required = false, Description = "是否生成小(浮点)数。如果为 false，则只生成整数。", DefaultValueFactory = _ => false
            };
            cmd_misc_random_number_list_1.Options.Add(opt_misc_random_number_list_1_allow_decimal);
            var opt_misc_random_number_list_1_decimal_places = new Option<int>("--decimal-places")
            {
                Required = false, Description = "如果 allow_decimal=true，这里可以指定小数的位数。", DefaultValueFactory = _ => 0
            };
            cmd_misc_random_number_list_1.Options.Add(opt_misc_random_number_list_1_decimal_places);
            cmd_misc_random_number_list_1.SetAction(parseResult =>
            {
                var min = parseResult.GetValue(opt_misc_random_number_list_1_min);
                var max = parseResult.GetValue(opt_misc_random_number_list_1_max);
                var count = parseResult.GetValue(opt_misc_random_number_list_1_count);
                var allow_repeat = parseResult.GetValue(opt_misc_random_number_list_1_allow_repeat);
                var allow_decimal = parseResult.GetValue(opt_misc_random_number_list_1_allow_decimal);
                var decimal_places = parseResult.GetValue(opt_misc_random_number_list_1_decimal_places);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Misc
                    .GetRandomNumberList(min, max, count, allow_repeat, allow_decimal, decimal_places, Authentication)
                    .GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });

            var cmd_random_number_list_2 = CliCommandTree.GetOrAdd(root, new[] { "random", "number-list" });
            var opt_random_number_list_2_min = new Option<int>("--min")
            {
                Required = false, DefaultValueFactory = _ => 0
            };
            cmd_random_number_list_2.Options.Add(opt_random_number_list_2_min);
            var opt_random_number_list_2_max = new Option<int>("--max")
            {
                Required = false, DefaultValueFactory = _ => 0
            };
            cmd_random_number_list_2.Options.Add(opt_random_number_list_2_max);
            var opt_random_number_list_2_count = new Option<int>("--count")
            {
                Required = false, DefaultValueFactory = _ => 0
            };
            cmd_random_number_list_2.Options.Add(opt_random_number_list_2_count);
            var opt_random_number_list_2_allow_repeat = new Option<bool>("--allow-repeat")
            {
                Required = false, DefaultValueFactory = _ => false
            };
            cmd_random_number_list_2.Options.Add(opt_random_number_list_2_allow_repeat);
            var opt_random_number_list_2_allow_decimal = new Option<bool>("--allow-decimal")
            {
                Required = false, DefaultValueFactory = _ => false
            };
            cmd_random_number_list_2.Options.Add(opt_random_number_list_2_allow_decimal);
            var opt_random_number_list_2_decimal_places = new Option<int>("--decimal-places")
            {
                Required = false, DefaultValueFactory = _ => 0
            };
            cmd_random_number_list_2.Options.Add(opt_random_number_list_2_decimal_places);
            cmd_random_number_list_2.SetAction(parseResult =>
            {
                var min = parseResult.GetValue(opt_random_number_list_2_min);
                var max = parseResult.GetValue(opt_random_number_list_2_max);
                var count = parseResult.GetValue(opt_random_number_list_2_count);
                var allow_repeat = parseResult.GetValue(opt_random_number_list_2_allow_repeat);
                var allow_decimal = parseResult.GetValue(opt_random_number_list_2_allow_decimal);
                var decimal_places = parseResult.GetValue(opt_random_number_list_2_decimal_places);
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