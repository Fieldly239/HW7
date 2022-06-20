using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrudCustom.Client.Services.FeedBackService
{
    public class FeedBackService : IFeedBackService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public FeedBackService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }
        public List<FeedBack> Backes { get; set; } = new List<FeedBack>();
        public List<Vote> Votes { get; set; } = new List<Vote>();
        public List<Appilcation> Appilcations { get; set; } = new List<Appilcation>();

        public async Task GetVotes()
        {
            var result = await _http.GetFromJsonAsync<List<Vote>>("api/feedback/votes");
            if (result != null)
                Votes = result;
        }

        public async Task GetAppilcations()
        {
            var result = await _http.GetFromJsonAsync<List<Appilcation>>("api/appilcations");
            if (result != null)
                Appilcations = result;
        }

        public async Task<FeedBack> GetSingleBack(int id)
        {
            var result = await _http.GetFromJsonAsync<FeedBack>($"api/feedback/{id}");
            if (result != null)
                return result;
            throw new Exception("FeedBack not found!");
        }

        
        public async Task GetFeedBackes()
        {
            var result = await _http.GetFromJsonAsync<List<FeedBack>>("api/feedback");
            if (result != null)
                Backes = result;
        }

        public async Task CreateFeedBack(FeedBack back)
        {
            var result = await _http.PostAsJsonAsync("api/feedback", back);
            await SetBackes(result);
        }

        private async Task SetBackes(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<FeedBack>>();
            Backes = response;
            _navigationManager.NavigateTo("feedbackes");
        }

        public async Task UpdateFeedBack(FeedBack back)
        {
            var result = await _http.PutAsJsonAsync($"api/feedback/{back.Id}", back);
            await SetBackes(result);
        }

        public async Task DeleteFeedBack(int id)
        {
            var result = await _http.DeleteAsync($"api/feedback/{id}");
            await SetBackes(result);
        }

        public async Task<Appilcation> GetSingleApps(int id)
        {
            var result = await _http.GetFromJsonAsync<Appilcation>($"api/appilcations/{id}");
            if (result != null)
                return result;
            throw new Exception("FeedBack not found!");
        }

        public async Task CreateApps(Appilcation apps)
        {
            var result = await _http.PostAsJsonAsync("api/appilcations", apps);
            await SetApps(result);
        }

        public async Task UpdateApps(Appilcation apps)
        {
            var result = await _http.PutAsJsonAsync($"api/appilcations/{apps.Id}", apps);
            await SetApps(result);
        }

        public async Task DeleteApps(int id)
        {
            var result = await _http.DeleteAsync($"api/appilcations/{id}");
            await SetApps(result);
        }
        private async Task SetApps(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Appilcation>>();
            Appilcations = response;
            _navigationManager.NavigateTo("appilcations");
        }
    }
}
