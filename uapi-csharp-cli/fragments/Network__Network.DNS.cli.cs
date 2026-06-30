using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_DNS
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "network", "lookup-dns" });
            o.Description = "DNS解析查询";
            var od = new Option<string>("--domain")
            {
                Required = true, Description = "指定要查询的主机"
            };
            o.Options.Add(od);
            var ot = new Option<Network.DNSRecordType>("--type")
            {
                Required = true, Description = "选择查询DNS的类型"
            };
            o.Options.Add(ot);
            o.SetAction(parseResult =>
            {
                var domain = parseResult.GetValue(od);
                var DNSRecordType = parseResult.GetValue(ot);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.LookUpDNS(domain, DNSRecordType, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}