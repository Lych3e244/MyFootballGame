using FluentValidation;

namespace MyFootballGame.Other.Application.ViewModel.Season
{
    public class NewSeasonVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LeagueId { get; set; }

    }
    public class NewSeasonValidation : AbstractValidator<NewSeasonVm>
    {
        public NewSeasonValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(255);
            RuleFor(x => x.LeagueId).NotNull().WithMessage("LeagueId is required");
        }
    }
}
