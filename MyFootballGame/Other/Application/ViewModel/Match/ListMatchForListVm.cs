using MyFootballGame.Other.Application.ViewModel.Player;

namespace MyFootballGame.Other.Application.ViewModel.Match
{
    public class ListMatchForListVm
    {
        public List<MatchForListVm> Matches { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
