using FluentValidation;
using MyFootballGame.Other.Application.ViewModel.Season;

namespace MyFootballGame.Other.Application.ViewModel.Match
{
    public class PlayAllMatchesOfSeasonVm
    {
        public int Id { get; set; }
    }
    public class PlayAllMatchesValidation : AbstractValidator<PlayAllMatchesOfSeasonVm>
    {
        public PlayAllMatchesValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required");
        }
    }
}
