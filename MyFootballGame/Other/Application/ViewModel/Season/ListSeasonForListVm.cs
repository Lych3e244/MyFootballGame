﻿using MyFootballGame.Other.Application.ViewModel.League;

namespace MyFootballGame.Other.Application.ViewModel.Season
{
    public class ListSeasonForListVm
    {
        public List<SeasonForListVm> Seasons { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
    }
}
