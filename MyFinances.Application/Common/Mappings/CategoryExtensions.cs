using MyFinances.Application.Common.Database.DbModels;
using MyFinances.Common.Result;
using MyFinances.Domain.Entities.Finances;

namespace MyFinances.Application.Common.Mappings;

public static class CategoryExtensions
{
	public static Result<CategoryDbModel> ToDbModel(this Category category)
		=> new CategoryDbModel
		{
			UserId = 1,
			Name = category.Name,
			Description = category.Description
		};
	
}
