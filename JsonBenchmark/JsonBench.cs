using System;
using System.Text;
using System.Text.Json;

using BenchmarkDotNet.Attributes;

using Jil;

using Newtonsoft.Json;

namespace JsonBenchmark
{
    [MemoryDiagnoser]
    public class JsonBench
    {
        private const string TestJson = "[{\"_id\":\"618c136d7b2315e0f1e7e0c5\",\"index\":0,\"guid\":\"bfa7b335-721e-43d2-a59e-b528784c42e0\",\"isActive\":true,\"balance\":\"$2,075.19\",\"picture\":\"http://placehold.it/32x32\",\"age\":39,\"eyeColor\":\"green\",\"name\":\"Coffey Hurley\",\"gender\":\"male\",\"company\":\"SUREMAX\",\"email\":\"coffeyhurley@suremax.com\",\"phone\":\"+1 (830) 444-3195\",\"address\":\"248 Beverly Road, Bellfountain, Federated States Of Micronesia, 9827\",\"about\":\"Dolor deserunt adipisicing excepteur nostrud qui minim laboris cupidatat magna dolore aliqua voluptate. Dolore cupidatat sunt non mollit irure mollit ad fugiat ea sit et consectetur magna fugiat. Ea commodo ea est laborum minim proident proident amet officia irure laborum. Dolore ex exercitation veniam ea consequat labore ad elit anim reprehenderit minim sunt. Exercitation est occaecat irure quis et id. Occaecat nisi ipsum fugiat occaecat veniam ex do dolore deserunt exercitation sunt sunt duis consectetur. Magna culpa excepteur minim fugiat dolore consectetur sit Lorem.\",\"registered\":\"2014-08-20T05:24:12 -04:00\",\"latitude\":-15.017735,\"longitude\":-42.996621,\"tags\":[\"excepteur\",\"ipsum\",\"nostrud\",\"sunt\",\"voluptate\",\"qui\",\"aute\"],\"friends\":[{\"id\":0,\"name\":\"Consuelo Bradford\"},{\"id\":1,\"name\":\"Hampton Santos\"},{\"id\":2,\"name\":\"Sasha Petersen\"}],\"greeting\":\"Hello, Coffey Hurley! You have 10 unread messages.\",\"favoriteFruit\":\"banana\"},{\"_id\":\"618c136de5ab621e21fb9096\",\"index\":1,\"guid\":\"d7f15fe2-f9f0-4ed6-ab71-e149eb33c1d2\",\"isActive\":false,\"balance\":\"$2,404.02\",\"picture\":\"http://placehold.it/32x32\",\"age\":39,\"eyeColor\":\"blue\",\"name\":\"Donna Ratliff\",\"gender\":\"female\",\"company\":\"ZIZZLE\",\"email\":\"donnaratliff@zizzle.com\",\"phone\":\"+1 (820) 572-2353\",\"address\":\"177 Doscher Street, Tyhee, Michigan, 330\",\"about\":\"Esse adipisicing cupidatat labore consequat. Exercitation irure quis reprehenderit cupidatat occaecat nostrud Lorem cupidatat deserunt amet aliqua irure veniam. Occaecat proident sint exercitation nulla id. Fugiat ullamco consectetur veniam exercitation adipisicing aliqua ad aute do sunt quis voluptate ipsum non.\",\"registered\":\"2019-10-09T10:10:35 -03:00\",\"latitude\":75.118737,\"longitude\":-78.720814,\"tags\":[\"pariatur\",\"qui\",\"id\",\"id\",\"aute\",\"reprehenderit\",\"mollit\"],\"friends\":[{\"id\":0,\"name\":\"Williams Harrison\"},{\"id\":1,\"name\":\"Berg Bowen\"},{\"id\":2,\"name\":\"Harrison Farley\"}],\"greeting\":\"Hello, Donna Ratliff! You have 7 unread messages.\",\"favoriteFruit\":\"strawberry\"},{\"_id\":\"618c136d7084577ca7c38954\",\"index\":2,\"guid\":\"c83b558a-e0f9-4caa-bad7-5d8dca78776b\",\"isActive\":true,\"balance\":\"$3,048.55\",\"picture\":\"http://placehold.it/32x32\",\"age\":25,\"eyeColor\":\"green\",\"name\":\"Morgan Fulton\",\"gender\":\"female\",\"company\":\"AVENETRO\",\"email\":\"morganfulton@avenetro.com\",\"phone\":\"+1 (893) 572-3419\",\"address\":\"605 Noble Street, Canoochee, Maine, 7232\",\"about\":\"Nulla ullamco nisi deserunt cupidatat ad officia. Sit enim nostrud nulla Lorem est est sunt aliqua duis adipisicing tempor. Quis fugiat ullamco minim nostrud consectetur ea eu aliquip ea labore sit.\",\"registered\":\"2015-07-20T10:12:47 -03:00\",\"latitude\":-57.212914,\"longitude\":-152.119402,\"tags\":[\"excepteur\",\"sit\",\"consectetur\",\"velit\",\"eiusmod\",\"officia\",\"est\"],\"friends\":[{\"id\":0,\"name\":\"Luz Sears\"},{\"id\":1,\"name\":\"Lang Slater\"},{\"id\":2,\"name\":\"Marshall Hurst\"}],\"greeting\":\"Hello, Morgan Fulton! You have 8 unread messages.\",\"favoriteFruit\":\"banana\"},{\"_id\":\"618c136d17a5fd4d4576c82f\",\"index\":3,\"guid\":\"7d9ad326-4907-4192-8f2e-e2641e06d1b3\",\"isActive\":false,\"balance\":\"$1,322.96\",\"picture\":\"http://placehold.it/32x32\",\"age\":32,\"eyeColor\":\"green\",\"name\":\"Kerri Holloway\",\"gender\":\"female\",\"company\":\"MOTOVATE\",\"email\":\"kerriholloway@motovate.com\",\"phone\":\"+1 (953) 456-3922\",\"address\":\"199 Classon Avenue, Marshall, Kentucky, 2840\",\"about\":\"Sit eu laboris Lorem id velit deserunt dolore commodo ipsum nisi. Eiusmod exercitation cupidatat id pariatur in Lorem ut do nisi. Ad in aliquip anim esse do. Nulla labore ullamco non et veniam laborum veniam anim commodo sunt dolore id reprehenderit. Ex nulla consequat nostrud voluptate non sit dolore ad.\",\"registered\":\"2021-04-06T06:40:34 -03:00\",\"latitude\":-48.536873,\"longitude\":121.902323,\"tags\":[\"amet\",\"in\",\"consequat\",\"nostrud\",\"qui\",\"ea\",\"reprehenderit\"],\"friends\":[{\"id\":0,\"name\":\"Mcleod Miranda\"},{\"id\":1,\"name\":\"Shannon Cohen\"},{\"id\":2,\"name\":\"Heidi Hoffman\"}],\"greeting\":\"Hello, Kerri Holloway! You have 6 unread messages.\",\"favoriteFruit\":\"banana\"},{\"_id\":\"618c136df4c961eb3d1afd62\",\"index\":4,\"guid\":\"caab36b0-89c2-4b94-84c6-ce85d38e695f\",\"isActive\":true,\"balance\":\"$2,953.90\",\"picture\":\"http://placehold.it/32x32\",\"age\":31,\"eyeColor\":\"green\",\"name\":\"Blair Collier\",\"gender\":\"male\",\"company\":\"XURBAN\",\"email\":\"blaircollier@xurban.com\",\"phone\":\"+1 (810) 581-3603\",\"address\":\"864 Box Street, Whitewater, Vermont, 845\",\"about\":\"Esse exercitation fugiat veniam elit ullamco. Et eu anim enim Lorem velit veniam consectetur cillum. Sunt duis magna nisi labore cillum ex. Cillum irure ad nostrud sit reprehenderit nulla anim nostrud.\",\"registered\":\"2018-03-04T07:00:15 -03:00\",\"latitude\":-27.657966,\"longitude\":-56.552617,\"tags\":[\"eu\",\"proident\",\"id\",\"excepteur\",\"et\",\"eiusmod\",\"reprehenderit\"],\"friends\":[{\"id\":0,\"name\":\"Gwendolyn Herring\"},{\"id\":1,\"name\":\"Earlene Cook\"},{\"id\":2,\"name\":\"Winnie Rowe\"}],\"greeting\":\"Hello, Blair Collier! You have 9 unread messages.\",\"favoriteFruit\":\"banana\"},{\"_id\":\"618c136d50f3c7db97f53c8a\",\"index\":5,\"guid\":\"f185e5d3-8958-4b8d-83cb-fcd47419309c\",\"isActive\":false,\"balance\":\"$1,134.20\",\"picture\":\"http://placehold.it/32x32\",\"age\":38,\"eyeColor\":\"green\",\"name\":\"Gilda Trujillo\",\"gender\":\"female\",\"company\":\"ZILLANET\",\"email\":\"gildatrujillo@zillanet.com\",\"phone\":\"+1 (890) 574-2977\",\"address\":\"690 Schermerhorn Street, Ruffin, West Virginia, 339\",\"about\":\"Proident aliqua eiusmod do occaecat. Dolor mollit laborum duis proident pariatur duis ipsum commodo eiusmod deserunt. Est ea reprehenderit exercitation dolore labore duis tempor.\",\"registered\":\"2015-11-26T01:48:34 -03:00\",\"latitude\":-89.361703,\"longitude\":82.054118,\"tags\":[\"fugiat\",\"nostrud\",\"occaecat\",\"do\",\"aute\",\"non\",\"ea\"],\"friends\":[{\"id\":0,\"name\":\"Floyd Levy\"},{\"id\":1,\"name\":\"Joyce Guzman\"},{\"id\":2,\"name\":\"Belinda Mathews\"}],\"greeting\":\"Hello, Gilda Trujillo! You have 8 unread messages.\",\"favoriteFruit\":\"strawberry\"},{\"_id\":\"618c136db33f6ddbf8c7ab2c\",\"index\":6,\"guid\":\"9d01c5d4-fbbe-4f0c-950b-e094709e70b4\",\"isActive\":true,\"balance\":\"$3,730.08\",\"picture\":\"http://placehold.it/32x32\",\"age\":33,\"eyeColor\":\"blue\",\"name\":\"Snider Walters\",\"gender\":\"male\",\"company\":\"BISBA\",\"email\":\"sniderwalters@bisba.com\",\"phone\":\"+1 (975) 578-3130\",\"address\":\"226 Georgia Avenue, Brenton, Virgin Islands, 6623\",\"about\":\"Mollit eiusmod consectetur incididunt eiusmod et esse consequat minim ea anim consequat incididunt enim est. Nulla dolor ea anim deserunt id anim officia ipsum aliqua do ad labore ex. Pariatur non incididunt cillum excepteur id commodo esse reprehenderit culpa eu elit mollit qui cupidatat.\",\"registered\":\"2015-12-01T08:22:15 -03:00\",\"latitude\":-9.396178,\"longitude\":-87.660351,\"tags\":[\"adipisicing\",\"irure\",\"occaecat\",\"magna\",\"sit\",\"magna\",\"ullamco\"],\"friends\":[{\"id\":0,\"name\":\"Mack Bonner\"},{\"id\":1,\"name\":\"Ashley Wheeler\"},{\"id\":2,\"name\":\"Aisha Jensen\"}],\"greeting\":\"Hello, Snider Walters! You have 4 unread messages.\",\"favoriteFruit\":\"apple\"}]";
        private readonly List<Friend> TestObject;
        private readonly object TestAnonimousObject;

        public JsonBench()
        {
            TestObject = JsonConvert.DeserializeObject<List<Friend>>(TestJson);
            TestAnonimousObject = JsonConvert.DeserializeObject(TestJson);
        }

        [Benchmark, BenchmarkCategory("Deserialize")]
        public void NewtonSoftJsonDeserialize()
        {
            var a = JsonConvert.DeserializeObject<List<Friend>>(TestJson);
        }

        [Benchmark, BenchmarkCategory("Deserialize")]
        public void JilDeserialize()
        {
            using var input = new StringReader(TestJson);
            var a = JSON.Deserialize<List<Friend>>(input);
        }

        [Benchmark, BenchmarkCategory("Deserialize")]
        public void MicrosoftJsonDeserialize()
        {
            var a = System.Text.Json.JsonSerializer.Deserialize<List<Friend>>(TestJson);
        }

        [Benchmark, BenchmarkCategory("Deserialize")]
        public async Task MicrosoftJsonDeserializeAsync()
        {
            using var input = new MemoryStream(Encoding.UTF8.GetBytes(TestJson));
            var a = await System.Text.Json.JsonSerializer.DeserializeAsync<List<Friend>>(input);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        public void NewtonSoftJsonSerialize()
        {
            var a = JsonConvert.SerializeObject(TestObject);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        public void JilSerialize()
        {
            var a = JSON.Serialize(TestObject);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        public void MicrosoftJsonSerialize()
        {
            var a = System.Text.Json.JsonSerializer.Serialize(TestObject);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        public void MicrosoftJsonUtf8Serialize()
        {
            var a = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(TestObject);
            var str = Encoding.UTF8.GetString(a);
        }

        //[Benchmark]
        //public async Task MicrosoftJsonSerializeAsync()
        //{
        //    using var input = new MemoryStream(4096);
        //    await System.Text.Json.JsonSerializer.SerializeAsync(input, TestObject);
        //    input.Position = 0;
        //    using var reader = new StreamReader(input);
        //    var a = await reader.ReadToEndAsync();
        //}

        [Benchmark, BenchmarkCategory("Serialize")]
        public void MicrosoftJsonSerializeWithContext()
        {
            var a = System.Text.Json.JsonSerializer.Serialize(TestObject, typeof(List<Friend>), FriendJson.Default);
        }

        [Benchmark, BenchmarkCategory("Serialize")]
        public void MicrosoftJsonUtf8SerializeWithContext()
        {
            var a = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(TestObject, typeof(List<Friend>), FriendJson.Default);
            var str = Encoding.UTF8.GetString(a);
        }

        //[Benchmark]
        //public async Task MicrosoftJsonSerializeAsyncWithContext()
        //{
        //    using var input = new MemoryStream(4096);
        //    await System.Text.Json.JsonSerializer.SerializeAsync(input, TestObject, typeof(List<Friend>), FriendJson.Default);
        //    input.Position = 0;
        //    using var reader = new StreamReader(input);
        //    var a = await reader.ReadToEndAsync();
        //}

        [Benchmark, BenchmarkCategory("SerializeAnon")]
        public void NewtonSoftJsonSerializeAnon()
        {
            var a = JsonConvert.SerializeObject(TestAnonimousObject);
        }

        [Benchmark, BenchmarkCategory("SerializeAnon")]
        public void JilSerializeAnon()
        {
            var a = JSON.Serialize(TestAnonimousObject);
        }

        [Benchmark, BenchmarkCategory("SerializeAnon")]
        public void MicrosoftJsonSerializeAnon()
        {
            var a = System.Text.Json.JsonSerializer.Serialize(TestAnonimousObject);
        }

        [Benchmark, BenchmarkCategory("SerializeAnon")]
        public void MicrosoftJsonUtf8SerializeAnon()
        {
            var a = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(TestAnonimousObject);
            var str = Encoding.UTF8.GetString(a);
        }
    }
}
