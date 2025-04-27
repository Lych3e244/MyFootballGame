namespace MyFootballGame.Other.Application.ViewModel.League
{
    public class ListLeagueForListVm
    {
        public List<LeagueForListVm> Leagues { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
