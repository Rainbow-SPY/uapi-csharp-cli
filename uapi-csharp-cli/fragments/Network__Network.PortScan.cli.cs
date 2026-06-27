using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class Cli_Network_Network_PortScan
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            var cmd_network_scan_port_1 = CliCommandTree.GetOrAdd(root, new[] { "network", "scan-port" });
            cmd_network_scan_port_1.Description = "使用指定的协议扫描指定主机的指定端口";
            var opt_network_scan_port_1_host = new Option<string>("--host")
            {
                Required = true, Description = "扫描的主机"
            };
            cmd_network_scan_port_1.Options.Add(opt_network_scan_port_1_host);
            var opt_network_scan_port_1_port = new Option<int>("--port")
            {
                Required = true, Description = "扫描的端口"
            };
            cmd_network_scan_port_1.Options.Add(opt_network_scan_port_1_port);
            var opt_network_scan_port_1_protocol = new Option<string>("--protocol")
            {
                Required = false, Description = "扫描的协议", DefaultValueFactory = _ => "tcp"
            };
            cmd_network_scan_port_1.Options.Add(opt_network_scan_port_1_protocol);
            cmd_network_scan_port_1.SetAction(async parseResult =>
            {
                var host = parseResult.GetValue(opt_network_scan_port_1_host);
                var port = parseResult.GetValue(opt_network_scan_port_1_port);
                var protocol = parseResult.GetValue(opt_network_scan_port_1_protocol);
                var Authentication = parseResult.GetValue(authenticationOption);
                var result = await Network.ScanPort(host, port, protocol, Authentication);
                CliOutput.WriteObject(result, parseResult.GetValue(outOption), parseResult.GetValue(appendOption));
            });
        }
    }
}