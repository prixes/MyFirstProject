using Newtonsoft.Json;

public class User
{
    [JsonProperty("user_id")]
    public int Id { get; set; }

    [JsonProperty("full_name")]
    public string Name { get; set; }

    [JsonProperty("email_address")]
    public string Email { get; set; }
}

//public class User {
//    public string Name { get; set; }

//    [JsonExtensionData]
//    public IDictionary<string, JToken> ExtraData { get; set; }
//}