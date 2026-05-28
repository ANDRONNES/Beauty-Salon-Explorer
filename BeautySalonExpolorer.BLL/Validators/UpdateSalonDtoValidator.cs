using System.Text.RegularExpressions;
using BeautySalonExpolorer.BLL.DTOs;
using FluentValidation;

namespace BeautySalonExpolorer.BLL.Validators;

public class UpdateSalonDtoValidator : AbstractValidator<UpdateSalonDTO>
{
    public UpdateSalonDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(200).WithMessage("Name couldn't be longer that 200 characters");


        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required.");

        RuleFor(x => x.District)
            .NotEmpty().WithMessage("District is required.");

        RuleFor(x => x.Phone)
            .Must(BeValidPhone).WithMessage("Invalid phone number format.")
            .When(x => !string.IsNullOrEmpty(x.Phone));

        RuleFor(x => x.Website)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("Invalid url.")
            .When(x => !string.IsNullOrEmpty(x.Website));

        RuleFor(x => x.LocationUrl)
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
            .WithMessage("Invalid location url.")
            .When(x => !string.IsNullOrEmpty(x.LocationUrl));

        RuleFor(x => x.Categories)
            .NotEmpty().WithMessage("Salon must have at least one category.");

        RuleFor(x => x.ImageUrl)
            .MaximumLength(500)
                .WithMessage("Image url couldn't be longer that 500 characters")
            .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out var parsedUri)
            && (parsedUri.Scheme == Uri.UriSchemeHttp || parsedUri.Scheme == Uri.UriSchemeHttps))
            .WithMessage("Ivalid format image url.")
            .When(x => !string.IsNullOrEmpty(x.ImageUrl));
    }

    private bool BeValidPhone(string? phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return true;

        var normalized = Regex.Replace(phone, @"[\s\-\(\)]", "");

        return Regex.IsMatch(
            normalized,
            @"^(\+48\d{9}|48\d{9}|\d{9})$"
        );
    }
}