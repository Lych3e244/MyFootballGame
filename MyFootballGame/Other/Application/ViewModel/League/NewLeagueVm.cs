using FluentValidation;

namespace MyFootballGame.Other.Application.ViewModel.League
{
    public class NewLeagueVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class NewLeagueValidation : AbstractValidator<NewLeagueVm>
    {
        public NewLeagueValidation()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is required");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").MaximumLength(255);
        }
    }
}
