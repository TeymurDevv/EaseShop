using EaseShop.API.Common;
using EaseShop.API.Extensions;
using EaseShop.Application.Features.Categories.Queries.GetAllSubCategoriesWithCategories;
using EaseShop.Application.Features.SubCategories.Queries.GetAllSubCategories;
using EaseShop.Application.Features.SubCategories.Queries.GetSubCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EaseShop.API.App.Client;

public class SubCategoryController : BaseController
{
    private readonly ISender  _sender;

    public SubCategoryController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IResult> Get(int id)
    {
        GetSubCategoryByIdQuery  query = new GetSubCategoryByIdQuery(id);
        var result = await _sender.Send(query);
        return result.ToApiResult();
    }
    
    [HttpGet]
    [Route("")]
    public async Task<IResult> GetAll(int pageNumber = 1, int pageSize = 10)
    {
        GetAllSubCategoriesQuery query = new GetAllSubCategoriesQuery(pageNumber, pageSize);
        var result = await _sender.Send(query);
        return result.ToApiResult();
    }

    [HttpGet]
    [Route("GetAllSubCategoriesWithCategories")]
    public async Task<IResult> GetAllSubCategoriesWithCategories(int pageNumber = 1, int pageSize = 10)
    {
        GetAllSubCategoriesWithCategoriesQuery query = new GetAllSubCategoriesWithCategoriesQuery(pageNumber, pageSize);
        var result = await _sender.Send(query);
        return result.ToApiResult();
    }
}