using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Text_Text_AnswerBook
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_text_ask_answer_book_1 = CliCommandTree.GetOrAdd(root, new[] { "text", "ask-answer-book" });
            cmd_text_ask_answer_book_1.Description = "提问并获得随机的神秘答案";
            var opt_text_ask_answer_book_1_question = new Option<string>("--question")
            {
                Required = true, Description = "指定要提出的问题"
            };
            cmd_text_ask_answer_book_1.Options.Add(opt_text_ask_answer_book_1_question);
            var opt_text_ask_answer_book_1_requestType = new Option<Interface.SendRequestType>("--request-type")
            {
                Required = true, Description = "请求方式, SendRequestType.GET or SendRequestType.POST"
            };
            cmd_text_ask_answer_book_1.Options.Add(opt_text_ask_answer_book_1_requestType);
            cmd_text_ask_answer_book_1.SetAction(async parseResult =>
            {
                var question = parseResult.GetValue(opt_text_ask_answer_book_1_question);
                var requestType = parseResult.GetValue(opt_text_ask_answer_book_1_requestType);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Text.AskAnswerBook(question, requestType, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}