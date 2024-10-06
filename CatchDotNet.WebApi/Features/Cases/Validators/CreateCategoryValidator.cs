using CatchDotNet.WebApi.Features.Cases.Commands;
using CatchDotNet.WebApi.Features.Cases.Domains;
using FluentValidation;

namespace CatchDotNet.WebApi.Features.Cases.Validators;

public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
{
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryValidator(ICategoryRepository categoryRepository)
        {
                _categoryRepository = categoryRepository;
                
                // Rules 
                RuleFor(r => r.Name).NotEmpty()
                        .MustAsync(async (c, name, ct) =>
                        {
                                var result = await _categoryRepository.ExistsAsync(name);
                                return result;
                        });


        }
}