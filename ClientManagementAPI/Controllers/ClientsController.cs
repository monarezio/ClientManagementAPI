using ClientManagementAPI.Entities;
using ClientManagementAPI.Models;
using ClientManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagementAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientsController : ControllerBase
{
    [HttpGet]
    public ActionResult<List<ClientEntity>> Get()
    {
        return Ok(ClientsRepository.Clients.Take(100).Select(c => new ClientEntity
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            Id = c.Id,
            Comments = new List<CommentEntity>()
        }));
    }

    [HttpPost]
    public IActionResult Add(ClientCreationModel creationModel)
    {
        ClientEntity c = new ClientEntity
        {
            Id = Guid.NewGuid(),
            Email = creationModel.Email,
            FirstName = creationModel.FirstName,
            LastName = creationModel.LastName
        };
        ClientsRepository.Clients.Add(c);
        return Ok(c);
    }

    [HttpDelete]
    [Route("{id:guid}")]
    public IActionResult Destroy(Guid id)
    {
        ClientEntity c = ClientsRepository.Clients.Find(c => c.Id == id);
        if (c == null) return NotFound();
        ClientsRepository.Clients.Remove(c);
        return NoContent();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public ActionResult<ClientEntity> GetDetail(Guid id)
    {
        ClientEntity c = ClientsRepository.Clients.Find(c => c.Id == id);
        if (c == null) return NotFound();
        return Ok(new ClientEntity
        {
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email,
            Id = c.Id,
            Comments = new List<CommentEntity>()
        });
    }

    [HttpPut]
    [Route("{id:guid}")]
    public IActionResult Update(Guid id, ClientCreationModel creationModel)
    {
        ClientEntity c = ClientsRepository.Clients.Find(c => c.Id == id);
        if (c == null) return NotFound();

        c.Email = creationModel.Email;
        c.FirstName = creationModel.FirstName;
        c.LastName = creationModel.LastName;
        return Ok(c);
    }
}