using ScoreSaberAPI.CommonTypes;
using ScoreSaberAPI.Models;
using ScoreSaberAPI.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ScoreSaberAPI
{
    public class ScoreSaber
    {
        private readonly IHttpClientFactory _httpFactory;
        private readonly HttpClient _httpClient;
        private readonly string _httpClientName;

        private HttpClient _http
        {
            get
            {
                if (_httpClient != null)
                    return _httpClient;
                else return string.IsNullOrWhiteSpace(_httpClientName) ? _httpFactory.CreateClient() : _httpFactory.CreateClient(_httpClientName);
            }
        }

        private string _scoreSaberDomain;

        public ScoreSaber(IHttpClientFactory httpFactory, string httpClientName = null, string scoreSaberDomain = "scoresaber.com")
        {
            _httpFactory = httpFactory;
            _httpClientName = httpClientName;
            _scoreSaberDomain = scoreSaberDomain;
        }

        public ScoreSaber(HttpClient httpClient, string scoreSaberDomain = "scoresaber.com")
        {
            _httpClient = httpClient;
            _scoreSaberDomain = scoreSaberDomain;
        }

        public async Task<GetLeaderboardsResponse> GetLeaderboards(
            string search = null, bool? verified = null, bool? ranked = null,
            bool? qualified = null, bool? loved = null, int? minStar = null,
            int? maxStar = null, Category? category = null, Sort? sort = null,
            bool? unique = null, int? page = null, bool? withMetadata = true)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();

            if (search != null)
                query.Add("search", search);

            if (verified != null)
                query.Add("verified", verified.ToString());

            if (ranked != null)
                query.Add("ranked", ranked.ToString());

            if (qualified != null)
                query.Add("qualified", qualified.ToString());

            if (loved != null)
                query.Add("loved", loved.ToString());

            if (minStar != null)
                query.Add("minStar", minStar.ToString());

            if (maxStar != null)
                query.Add("maxStar", maxStar.ToString());

            if (sort != null)
                query.Add("sort", sort.ToString());

            if (category != null)
                query.Add("category", category.ToString());

            if (unique != null)
                query.Add("unique", unique.ToString());

            if (page != null)
                query.Add("page", page.ToString());

            if (withMetadata != null)
                query.Add("withMetadata", withMetadata.ToString());

            return await _http.GetFromJsonAsync<GetLeaderboardsResponse>(BuildUrl($"https://{_scoreSaberDomain}/api/leaderboards", query));
        }

        public async Task<LeaderboardInfo> GetLeaderboard(int id)
        {
            return await _http.GetFromJsonAsync<LeaderboardInfo>($"https://{_scoreSaberDomain}/api/leaderboard/by-id/{id}/info");
        }

        public async Task<LeaderboardInfo> GetLeaderboard(string hash, Difficulty difficulty, string gameMode = null)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            if (gameMode != null)
                query.Add("gameMode", gameMode);

            return await _http.GetFromJsonAsync<LeaderboardInfo>(BuildUrl($"https://{_scoreSaberDomain}/api/leaderboard/by-hash/{hash}/info?difficulty={(int)difficulty}", query));
        }

        public async Task<GetLeaderboardsScoresResponse> GetScores(int leaderboardId, string countries = null, string search = null, int? page = null, bool? withMetadata = null)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            if (countries != null)
                query.Add("countries", countries);

            if (search != null)
                query.Add("search", search);

            if (page != null)
                query.Add("page", page.ToString());

            if (withMetadata != null)
                query.Add("withMetadata", withMetadata.ToString());

            return await _http.GetFromJsonAsync<GetLeaderboardsScoresResponse>(BuildUrl($"https://{_scoreSaberDomain}/api/leaderboard/by-id/{leaderboardId}/scores", query));
        }

        public async Task<GetLeaderboardsScoresResponse> GetScores(string hash, Difficulty difficulty, string countries = null, string search = null, int? page = null, bool? withMetadata = null)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            if (countries != null)
                query.Add("countries", countries);

            if (search != null)
                query.Add("search", search);

            if (page != null)
                query.Add("page", page.ToString());

            if (withMetadata != null)
                query.Add("withMetadata", withMetadata.ToString());

            return await _http.GetFromJsonAsync<GetLeaderboardsScoresResponse>(BuildUrl($"https://{_scoreSaberDomain}/api/leaderboard/by-hash/{hash}/scores?difficulty={(int)difficulty}", query));
        }

        public async Task<List<LeaderboardDifficulty>> GetDifficulties(string hash)
        {
            return await _http.GetFromJsonAsync<List<LeaderboardDifficulty>>($"https://{_scoreSaberDomain}/api/leaderboard/get-difficulties/{hash}");
        }

        public async Task<GetPlayersResponse> GetPlayers(string search = null, int? page = null, string countries = null, bool? withMetadata = null)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            if (search != null)
                query.Add("search", search);

            if (page != null)
                query.Add("page", page.ToString());

            if (countries != null)
                query.Add("countries", countries);

            if (withMetadata != null)
                query.Add("withMetadata", withMetadata.ToString());

            return await _http.GetFromJsonAsync<GetPlayersResponse>(BuildUrl($"https://{_scoreSaberDomain}/api/players", query));
        }

        public async Task<int> GetPlayersCount(string search = null, string countries = null)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            if (search != null)
                query.Add("search", search);

            if (countries != null)
                query.Add("countries", countries);

            return Convert.ToInt32(await _http.GetStringAsync(BuildUrl($"https://{_scoreSaberDomain}/api/players/count", query)));
        }

        public async Task<Player> GetPlayerBasic(long? playerId)
        {
            return await _http.GetFromJsonAsync<Player>($"https://{_scoreSaberDomain}/api/player/{playerId}/basic");
        }

        public async Task<Player> GetPlayerFull(long? playerId)
        {
            return await _http.GetFromJsonAsync<Player>($"https://{_scoreSaberDomain}/api/player/{playerId}/full");
        }

        public async Task<GetPlayerScoresResponse> GetPlayerScores(long? playerId, int? limit = null, ScoresSort? sort = null, int? page = null, bool? withMetadata = null)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();

            if (limit != null)
                query.Add("limit", limit.ToString());

            if (sort != null)
                query.Add("sort", sort.ToString().ToLower());

            if (page != null)
                query.Add("page", page.ToString());

            if (withMetadata != null)
                query.Add("withMetadata", withMetadata.ToString());

            return await _http.GetFromJsonAsync<GetPlayerScoresResponse>(BuildUrl($"https://{_scoreSaberDomain}/api/player/{playerId}/scores", query));
        }

        public string BuildUrl(string url, Dictionary<string, string> query)
        {
            if (query.Count > 0)
                return $"{url}?{string.Concat(query.Select(x => $"&{x.Key}={x.Value}")).Remove(0, 1)}";
            return url;
        }

        public async Task<string> Test()
        {
            return await (await _http.GetAsync("http://ip-api.com/json")).Content.ReadAsStringAsync();
        }
    }
}
