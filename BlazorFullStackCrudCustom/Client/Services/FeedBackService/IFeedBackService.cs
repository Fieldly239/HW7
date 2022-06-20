namespace BlazorFullStackCrudCustom.Client.Services.FeedBackService
{
    public interface IFeedBackService
    {
        List<FeedBack> Backes { get; set; }
        List<Vote> Votes { get; set; }
        List<Appilcation> Appilcations { get; set; }
        Task GetAppilcations();
        Task GetVotes();
        Task GetFeedBackes();
        Task<FeedBack> GetSingleBack(int id);
        Task CreateFeedBack (FeedBack back);
        Task UpdateFeedBack (FeedBack back);
        Task DeleteFeedBack(int id);
        Task<Appilcation> GetSingleApps(int id);
        Task CreateApps(Appilcation apps);
        Task UpdateApps(Appilcation apps);
        Task DeleteApps(int id);
    }
}
