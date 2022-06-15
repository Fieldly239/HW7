namespace BlazorFullStackCrudCustom.Client.Services.FeedBackService
{
    public interface IFeedBackService
    {
        List<FeedBack> Backes { get; set; }
        List<Vote> Votes { get; set; }
        Task GetVotes();
        Task GetFeedBackes();
        Task<FeedBack> GetSingleBack(int id);
        Task CreateFeedBack (FeedBack back);
        Task UpdateFeedBack (FeedBack back);
        Task DeleteFeedBack(int id);
    }
}
