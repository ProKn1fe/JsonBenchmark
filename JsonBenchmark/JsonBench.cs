using System.Text;

using BenchmarkDotNet.Attributes;

using Jil;

using Newtonsoft.Json;

namespace JsonBenchmark
{
    [MemoryDiagnoser]
    [CategoriesColumn]
    public class JsonBench
    {
        private readonly string SmallJsonInline;
        private readonly string SmallJsonFormatted;
        private readonly string LargeJsonInline;
        private readonly string LargeJsonFormatted;
        private readonly List<Friend> ListSmallJson;
        private readonly List<Friend> ListLargeJson;
        private readonly object ObjectSmallJson;
        private readonly object ObjectLargeJson;

        public JsonBench()
        {
            SmallJsonInline = File.ReadAllText("SmallJsonInline.json");
            SmallJsonFormatted = File.ReadAllText("SmallJsonFormatted.json");
            LargeJsonInline = File.ReadAllText("LargeJsonInline.json");
            LargeJsonFormatted = File.ReadAllText("LargeJsonFormatted.json");

            ListSmallJson = JsonConvert.DeserializeObject<List<Friend>>(SmallJsonInline);
            ListLargeJson = JsonConvert.DeserializeObject<List<Friend>>(LargeJsonInline);

            ObjectSmallJson = JsonConvert.DeserializeObject<List<Friend>>(SmallJsonInline);
            ObjectLargeJson = JsonConvert.DeserializeObject<List<Friend>>(LargeJsonInline);
        }

        [Benchmark, BenchmarkCategory("Deserialize")]
        [ArgumentsSource(nameof(GetJson))]
        public void NewtonSoftJsonDeserialize(string json)
        {
            var a = JsonConvert.DeserializeObject<List<Friend>>(json);
        }

        [Benchmark, BenchmarkCategory("Deserialize")]
        [ArgumentsSource(nameof(GetJson))]
        public void JilDeserialize(string json)
        {
            using var input = new StringReader(json);
            var a = JSON.Deserialize<List<Friend>>(input);
        }

        [Benchmark, BenchmarkCategory("Deserialize")]
        [ArgumentsSource(nameof(GetJson))]
        public void MicrosoftJsonDeserialize(string json)
        {
            var a = System.Text.Json.JsonSerializer.Deserialize<List<Friend>>(json);
        }

        [Benchmark, BenchmarkCategory("Deserialize")]
        [ArgumentsSource(nameof(GetJson))]
        public async Task MicrosoftJsonDeserializeAsync(string json)
        {
            using var input = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var a = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Friend>>(input);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        [ArgumentsSource(nameof(GetList))]
        public void NewtonSoftJsonSerialize(List<Friend> friends)
        {
            var a = JsonConvert.SerializeObject(friends);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        [ArgumentsSource(nameof(GetList))]
        public void JilSerialize(List<Friend> friends)
        {
            var a = JSON.Serialize(friends);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        [ArgumentsSource(nameof(GetList))]
        public void MicrosoftJsonSerialize(List<Friend> friends)
        {
            var a = System.Text.Json.JsonSerializer.Serialize(friends);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        [ArgumentsSource(nameof(GetList))]
        public void MicrosoftJsonUtf8Serialize(List<Friend> friends)
        {
            var a = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(friends);
            var str = Encoding.UTF8.GetString(a);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        [ArgumentsSource(nameof(GetList))]
        public void MicrosoftJsonSerializeWithContext(List<Friend> friends)
        {
            var a = System.Text.Json.JsonSerializer.Serialize(friends, typeof(List<Friend>), FriendJson.Default);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        [ArgumentsSource(nameof(GetList))]
        public void MicrosoftJsonUtf8SerializeWithContext(List<Friend> friends)
        {
            var a = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(friends, typeof(List<Friend>), FriendJson.Default);
            var str = Encoding.UTF8.GetString(a);
        }

        [Benchmark, BenchmarkCategory("SerializeObject")]
        [ArgumentsSource(nameof(GetObject))]
        public void NewtonSoftJsonSerializeAnon(object obj)
        {
            var a = JsonConvert.SerializeObject(obj);
        }

        [Benchmark, BenchmarkCategory("SerializeObject")]
        [ArgumentsSource(nameof(GetObject))]
        public void JilSerializeAnon(object obj)
        {
            var a = JSON.Serialize(obj);
        }

        [Benchmark, BenchmarkCategory("SerializeObject")]
        [ArgumentsSource(nameof(GetObject))]
        public void MicrosoftJsonSerializeAnon(object obj)
        {
            var a = System.Text.Json.JsonSerializer.Serialize(obj);
        }

        [Benchmark, BenchmarkCategory("SerializeObject")]
        [ArgumentsSource(nameof(GetObject))]
        public void MicrosoftJsonUtf8SerializeAnon(object obj)
        {
            var a = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(obj);
            var str = Encoding.UTF8.GetString(a);
        }

        public IEnumerable<string> GetJson()
        {
            yield return SmallJsonInline;
            yield return SmallJsonFormatted;
            yield return LargeJsonInline;
            yield return LargeJsonFormatted;
        }

        public IEnumerable<List<Friend>> GetList()
        {
            yield return ListSmallJson;
            yield return ListLargeJson;
        }

        public IEnumerable<object> GetObject()
        {
            yield return ObjectSmallJson;
            yield return ObjectLargeJson;
        }
    }
}
