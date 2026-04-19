using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyFinances.Application.Commands.Categories.CreateCategory;
using MyFinances.Common.Result;

namespace MyFinances.Presentation.Endpoints;

internal static class CategoryEndpoint
{
	public static void AddEndpointsCategory(this IEndpointRouteBuilder app)
	{
		var endpoints = app.MapGroup("api/cliente/{clientId}/category");

		endpoints.MapPost("/create", CreateCategory)
							.WithTags("Category")
							.WithDisplayName("Create Category")
							.WithSummary("Category");
	}

	public static async Task<Results<Ok<CreateCategoryViewModel>, BadRequest<List<Error>>>> CreateCategory(
		[FromServices] ISender mediatr,
		[FromServices] ILogger<Program> logger,
		RequestCreateCategory request
	)
	{
		logger.LogInformation("Start the request {@request}", request);
		
		var resultCreateCategory = await mediatr.Send(new CreateCategories(request))
											.ConfigureAwait(ConfigureAwaitOptions.None);

		return resultCreateCategory.IsFailure
			? TypedResults.BadRequest(resultCreateCategory.Errors)
			: TypedResults.Ok(resultCreateCategory.Data);
	}
}
