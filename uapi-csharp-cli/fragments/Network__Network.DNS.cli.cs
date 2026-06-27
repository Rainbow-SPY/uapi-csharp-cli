using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_DNS
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_network_look_up_dns_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "look-up-dns" });
            cmd_network_look_up_dns_1.Description = "DNS解析查询";
            var opt_network_look_up_dns_1_domain = new Option<string>("--domain")
            {
                Required = true, Description = "指定要查询的主机"
            };
            cmd_network_look_up_dns_1.Options.Add(opt_network_look_up_dns_1_domain);
            var opt_network_look_up_dns_1_DNSRecordType = new Option<Network.DNSRecordType>("--dns-record-type")
            {
                Required = true, Description = "选择查询DNS的类型"
            };
            cmd_network_look_up_dns_1.Options.Add(opt_network_look_up_dns_1_DNSRecordType);
            cmd_network_look_up_dns_1.SetAction(async parseResult =>
            {
                var domain = parseResult.GetValue(opt_network_look_up_dns_1_domain);
                var DNSRecordType = parseResult.GetValue(opt_network_look_up_dns_1_DNSRecordType);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Network.LookUpDNS(domain, DNSRecordType, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}