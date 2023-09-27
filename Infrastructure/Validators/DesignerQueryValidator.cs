using CadDesigner.Aplication.DtoModels;
using CadDesigner.Domain.Entitys;
using CadDesigner.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadDesigner.Infrastructure.Validators
{

    public class DesignerQueryValidator : AbstractValidator<DesignerQuery>
    {
        private readonly int[] allowedPageSizes = new[] { 5, 10, 15 };

        private readonly string[] allowedSortByColumnNames =
            {nameof(Designer.Name), nameof(Designer.Category), nameof(Designer.Description),};
        public DesignerQueryValidator()
        {
            RuleFor(r => r.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(r => r.PageSize).Custom((value, context) =>
            {
                if (!allowedPageSizes.Contains(value))
                {
                    context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSizes)}]");
                }
            });

            RuleFor(r => r.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");
        }
    }
}
