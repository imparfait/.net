using carShop.Entities;
using FluentValidation;

namespace BusinessLogic.Validators
{
    public class CarValidators : AbstractValidator<Car>
    {
        public CarValidators()
        {
            RuleFor(x => x.Model)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3);

            RuleFor(x => x.Price).GreaterThanOrEqualTo(0)
                .WithMessage("Value {PropertyName} is incorrect.{PropertyName}" +
                " must be bigger than 0");

            RuleFor(x => x.ImagePath).Must(LinkMustBeAUri)
                .WithMessage("{PropertyName} has incorrect URL format");
        }

        private static bool LinkMustBeAUri(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }
    }
}
