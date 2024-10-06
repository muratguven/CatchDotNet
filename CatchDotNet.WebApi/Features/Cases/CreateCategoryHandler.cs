using CatchDotNet.Core;
using CatchDotNet.Core.Data;
using CatchDotNet.Core.Mediatr.Command;
using CatchDotNet.WebApi.Features.Cases.Commands;
using CatchDotNet.WebApi.Features.Cases.Domains;
using FluentValidation;

namespace CatchDotNet.WebApi.Features.Cases;

internal sealed class CreateCategoryHandler : ICommandHandler<CreateCategoryCommand>
{
    
    private readonly ICategoryRepository _categoryRepository;
    private readonly ILogger<CreateCategoryHandler> _logger;
    private readonly IValidator<CreateCategoryCommand> _validator;
    private readonly IUnitOfWork<CatchDbContext> _unitOfWork;
    

    public CreateCategoryHandler(ICategoryRepository categoryRepository,
        ILogger<CreateCategoryHandler> logger,
        IValidator<CreateCategoryCommand> validator, IUnitOfWork<CatchDbContext> unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
        _validator = validator;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<Result> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validation= await _validator.ValidateAsync(request, cancellationToken);
        if (!validation.IsValid)
        {
           
            _logger.LogError($"Error creating category: {string.Join("\n", validation.Errors)}");
            return Result.Failure(new Error("CaseService.CreateCategoryCommand",validation.ToString()));
        }

        var category = new Category(Guid.NewGuid(),request.ParentId, request.Name, request.IsActive);
        using (var uow = _unitOfWork)
        {
            await _categoryRepository.InsertAsync(category,cancellationToken);
            await uow.CommitAsync();
        }
        _logger.LogInformation($"Successfully created category: {category.Id}");
        return Result.Success();
        
    }
}