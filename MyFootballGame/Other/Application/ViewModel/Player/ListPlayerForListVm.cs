namespace MyFootballGame.Other.Application.ViewModel.Player
{
    public class ListPlayerForListVm
    {
        public List<PlayerForListVm> Players { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
