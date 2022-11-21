namespace SearchServiceLSM.Service
{
    public interface ISearchService
    {
        Task<string> Search(string text);
    }
}
