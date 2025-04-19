using EaseShop.API.Common;
using EaseShop.API.Extensions;
using EaseShop.Application.Dtos.Category;
using EaseShop.Application.Features.Categories.Queries.GetAllCategories;
using EaseShop.Application.Features.Categories.Queries.GetCategoryById;
using EaseShop.Domain.Common.ResultPattern;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EaseShop.API.App.Client;

public class CategoryController : BaseController
{
    private readonly ISender _sender;

    public CategoryController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IResult> Get(Guid id)
    {
        GetCategoryByIdQuery  query = new GetCategoryByIdQuery(id);
        var result = await _sender.Send(query);
        return result.ToApiResult();
    }

    [HttpGet]
    [Route("")]
    public async Task<IResult> GetAll(int pageNumber, int pageSize = 20)
    {
        GetAllCategoriesQuery query = new GetAllCategoriesQuery(pageNumber, pageSize);
        var result = await _sender.Send(query);
        return result.ToApiResult();
    }
    
}