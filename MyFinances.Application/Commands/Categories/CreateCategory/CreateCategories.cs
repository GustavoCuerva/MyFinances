using MediatR;
using MyFinances.Common.Result;
using MyFinances.Domain.Entities.Finances;
using MyFinances.Application.Common.Mappings;
using MyFinances.Application.Common.Database;

namespace MyFinances.Application.Commands.Categories.CreateCategory;

public record CreateCategories(RequestCreateCategory Data) : IRequest<Result<CreateCategoryViewModel>>;

public sealed class CreateCategoriesHandler(IApplicationDbContext dbContext) : IRequestHandler<CreateCategories, Result<CreateCategoryViewModel>>
{
	public async Task<Result<CreateCategoryViewModel>> Handle(CreateCategories request, CancellationToken cancellationToken)
	{
		var resultCategory = Category.Create(request.Data.Name, request.Data.Description, 0, [], []);

		if (resultCategory.IsFailure)
			return resultCategory.Errors;

		var category = resultCategory.Data;

		var resultCategoryDbModel = category.ToDbModel();

		if (resultCategoryDbModel.IsFailure)
			return resultCategoryDbModel.Errors;

		var categoryDbModel = resultCategoryDbModel.Data;

		dbContext.Categories.Add(categoryDbModel);
		//await dbContext.SaveChangesAsync(cancellationToken);

		return new CreateCategoryViewModel(categoryDbModel.ReferenceCode, DateTimeOffset.Now);
	}
}