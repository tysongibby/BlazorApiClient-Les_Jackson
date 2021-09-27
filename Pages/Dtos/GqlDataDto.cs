using System.Text.Json.Serialization;

namespace BlazorApiClient.Dtos
{
    public partial class GqlDataDto
    {
        [JsonPropertyName("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonPropertyName("launches")]
        public LaunchDto[] Launches { get; set; }
    }

}