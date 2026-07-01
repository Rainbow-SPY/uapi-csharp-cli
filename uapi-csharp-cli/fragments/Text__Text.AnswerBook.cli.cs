using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_AnswerBook
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "text", "answer-book" });
            o.Description = "提问并获得随机的神秘答案";
            var o_q = new Option<string>("--question")
            {
                Required = true, Description = "指定要提出的问题"
            };
            o.Options.Add(o_q);
            var o_t = new Option<Interface.SendRequestType>("--type")
            {
                Required = true, Description = "请求方式, SendRequestType.GET or SendRequestType.POST"
            };
            o.Options.Add(o_t);
            o.SetAction(parseResult =>
            {
                var question = parseResult.GetValue(o_q);
                var requestType = parseResult.GetValue(o_t);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Text.AskAnswerBook(question, requestType, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}