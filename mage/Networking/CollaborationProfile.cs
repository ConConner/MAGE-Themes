using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace mage.Networking;

/// <summary>
/// Holds information about the Collaboration Sessions and Settings
/// </summary>
public class CollaborationProfile
{
    public string Username { get; set; } = "MAGE User";
    public string JoinAddress { get; set; } = "localhost";
    public int JoinPort { get; set; } = 1234;
    public int HostPort { get; set; } = 1234;

    [JsonIgnore]
    public IPAddress JoinIPAddress => IPAddress.Parse(JoinAddress);
}
