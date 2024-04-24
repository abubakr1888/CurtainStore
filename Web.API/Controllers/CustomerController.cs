using Application.Services;
using AutoMapper;
using Contracts.Requests;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(
    IBaseService<Customer> customerService,
    IMapper mapper) : ControllerBase
{
    [HttpPost]
    public OkResult Create([FromBody] CreateCustomerRequest request)
    {
        var customer = mapper.Map<Customer>(request);

        customerService.CreateAsync(customer);

        return Ok();
    }
}