using ScoreSaberAPI.CommonTypes;
using ScoreSaberAPI.Models;
using ScoreSaberAPI.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ScoreSaberAPI
{
    public class ScoreSaber
    {
        private IHttpClientFactory _httpFactory;
        private HttpClient _httpClient;

        private HttpClient _http
        {
            get
            {
                if (_httpClient != null)
                    return _httpClient;
                else return _httpFactory.CreateClient();
            }
        }

        private string _scoreSaberDomain;

        public ScoreSaber(IHttpClientFactory httpFactory, string scoreSaberDomain = "scoresaber.com")
        {
            _httpFactory = httpFactory;
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
            string url = $"https://{_scoreSaberDomain}/api/leaderboards";

            if (search != null)
                url += $"?search={search}";

            if (verified != null)
                url += $"&verified={verified}";

            if (ranked != null)
                url += $"&ranked={ranked}";

            if (qualified != null)
                url += $"&qualified={qualified}";

            if (loved != null)
                url += $"&loved={loved}";

            if (minStar != null)
                url += $"&minStar={minStar}";

            if (maxStar != null)
                url += $"&maxStar={maxStar}";

            if (sort != null)
                url += $"&sort={(int)sort}";

            if (category != null)
                url += $"&category={(int)category}";

            if (unique != null)
                url += $"&unique={unique}";

            if (page != null)
                url += $"&page={page}";

            if (withMetadata != null)
                url += $"&withMetadata={withMetadata}";

            return await _http.GetFromJsonAsync<GetLeaderboardsResponse>(url);
        }

        public async Task<LeaderboardInfo> GetLeaderboard(int id)
        {
            return await _http.GetFromJsonAsync<LeaderboardInfo>($"https://{_scoreSaberDomain}/api/leaderboard/by-id/{id}/info");
        }

        public async Task<LeaderboardInfo> GetLeaderboard(string hash, Difficulty difficulty, string gameMode = null)
        {
            string url = $"https://{_scoreSaberDomain}/api/leaderboard/by-hash/{hash}/info?difficulty={(int)difficulty}";
            if (gameMode != null)
                url += $"&gameMode={gameMode}";

            return await _http.GetFromJsonAsync<LeaderboardInfo>(url);
        }

        public async Task<GetLeaderboardsScoresResponse> GetScores(int leaderboardId, string countries = null, string search = null, int? page = null, bool? withMetadata = null)
        {
            string url = $"https://{_scoreSaberDomain}/api/leaderboard/by-id/{leaderboardId}/scores";
            if (countries != null)
                url += $"?countries={countries}";

            if (search != null)
                url += $"&search={search}";

            if (page != null)
                url += $"&page={page}";

            if (withMetadata != null)
                url += $"&withMetadata={withMetadata}";

            return await _http.GetFromJsonAsync<GetLeaderboardsScoresResponse>(url);
        }

        public async Task<GetLeaderboardsScoresResponse> GetScores(string hash, Difficulty difficulty, string countries = null, string search = null, int? page = null, bool? withMetadata = null)
        {
            string url = $"https://{_scoreSaberDomain}/api/leaderboard/by-hash/{hash}/scores?difficulty={(int)difficulty}";
            if (countries != null)
                url += $"?countries={countries}";

            if (search != null)
                url += $"&search={search}";

            if (page != null)
                url += $"&page={page}";

            if (withMetadata != null)
                url += $"&withMetadata={withMetadata}";

            return await _http.GetFromJsonAsync<GetLeaderboardsScoresResponse>(url);
        }

        public async Task<List<LeaderboardDifficulty>> GetDifficulties(string hash)
        {
            return await _http.GetFromJsonAsync<List<LeaderboardDifficulty>>($"https://{_scoreSaberDomain}/api/leaderboard/get-difficulties/{hash}");
        }

        public async Task<GetPlayersResponse> GetPlayers(string search = null, int? page = null, string countries = null, bool? withMetadata = null)
        {
            string url = $"https://{_scoreSaberDomain}/api/players";
            if (search != null)
                url += $"?search={search}";

            if (page != null)
                url += $"&page={page}";

            if (countries != null)
                url += $"&countries={countries}";

            if (withMetadata != null)
                url += $"&withMetadata={withMetadata}";

            return await _http.GetFromJsonAsync<GetPlayersResponse>(url);
        }

        public async Task<int> GetPlayersCount(string search = null, string countries = null)
        {
            string url = $"https://{_scoreSaberDomain}/api/players/count";
            if (search != null)
                url += $"?search={search}";

            if (countries != null)
                url += $"&countries={countries}";

            return Convert.ToInt32(await _http.GetStringAsync(url));
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
            string url = $"https://{_scoreSaberDomain}/api/player/{playerId}/scores";
            if (limit != null)
                url += $"?limit={limit}";

            if (sort != null)
                url += $"&sort={sort.ToString().ToLower()}";

            if (page != null)
                url += $"&page={page}";

            if (withMetadata != null)
                url += $"&withMetadata={withMetadata}";

            return await _http.GetFromJsonAsync<GetPlayerScoresResponse>(url);
        }
    }
}
