using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_PortScan
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            var o = CliCommandTree.GetOrAdd(root, new[] { "network", "scan-port" });
            o.Description = "使用指定的协议扫描指定主机的指定端口";
            var oip = new Option<string>("--host")
            {
                Required = true, Description = "扫描的主机"
            };
            o.Options.Add(oip);
            var op = new Option<int>("--port")
            {
                Required = true, Description = "扫描的端口"
            };
            o.Options.Add(op);
            var ot = new Option<string>("--protocol")
            {
                Required = false, Description = "扫描的协议", DefaultValueFactory = _ => "tcp"
            };
            o.Options.Add(ot);
            o.SetAction(parseResult =>
            {
                var host = parseResult.GetValue(oip);
                var port = parseResult.GetValue(op);
                var protocol = parseResult.GetValue(ot);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = Network.ScanPort(host, port, protocol, Authentication).GetAwaiter().GetResult();
                CliOutput.WriteObject(result, parseResult.GetValue(outputOption), parseResult.GetValue(appendOption),
                    parseResult.GetValue(resultOption), parseResult.GetValue(selectOption));
                return 0;
            });
        }
    }
}