﻿namespace MyFootballGame.Other.Application.ViewModel.Team
{
    public class ListTeamForListVm
    {
        public List<TeamForListVm> Teams { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
