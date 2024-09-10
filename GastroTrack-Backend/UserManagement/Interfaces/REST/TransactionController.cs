using System.Net.Mime;
using chefstock_platform.UserManagement.Domain.Model.Commands;
using chefstock_platform.UserManagement.Domain.Services;
using chefstock_platform.UserManagement.Interfaces.REST.Resources;
using chefstock_platform.UserManagement.Interfaces.REST.Transform;
using chefstock_platform.UserManagement.Domain.Model.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace chefstock_platform.UserManagement.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TransactionController(
    ITransactionCommandService transactionCommandService,
    ITransactionQueryService transactionQueryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTransaction(CreateTransactionResource resource)
    {
        var createTransactionCommand = CreateTransactionCommandFromResourceAssembler.ToCommandFromResource(resource);
        var transaction = await transactionCommandService.Handle(createTransactionCommand);
        if (transaction is null) return BadRequest();
        var transactionResource = TransactionResourceFromEntityAssembler.ToResourceFromEntity(transaction);
        return CreatedAtAction(nameof(GetTransactionById), new {transactionId = transactionResource.TransactionId}, transactionResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTransactions()
    {
        var getAllTransactionsQuery = new GetAllTransactionsQuery();
        var transactions = await transactionQueryService.Handle(getAllTransactionsQuery);
        var transactionResources = transactions.Select(TransactionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(transactionResources);
    }

    [HttpGet("{transactionId:int}")]
    public async Task<IActionResult> GetTransactionById(int transactionId)
    {
        var getTransactionByIdQuery = new GetTransactionByIdQuery(transactionId);
        var transaction = await transactionQueryService.Handle(getTransactionByIdQuery);
        if (transaction == null) return NotFound();
        var transactionResource = TransactionResourceFromEntityAssembler.ToResourceFromEntity(transaction);
        return Ok(transactionResource);
    }

    [HttpPut("{transactionId:int}")]
    public async Task<IActionResult> UpdateTransaction(int transactionId, UpdateTransactionResource resource)
    {
        var updateTransactionCommand = UpdateTransactionCommandFromResourceAssembler.ToCommandFromResource(resource);
        await transactionCommandService.Handle(updateTransactionCommand);
        return NoContent();
    }

    [HttpDelete("{transactionId:int}")]
    public async Task<IActionResult> DeleteTransaction(int transactionId)
    {
        var deleteTransactionCommand = new DeleteTransactionCommand(transactionId);
        await transactionCommandService.Handle(deleteTransactionCommand);
        return NoContent();
    }
}