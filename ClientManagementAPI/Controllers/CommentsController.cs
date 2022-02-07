using ClientManagementAPI.Entities;
using ClientManagementAPI.Models;
using ClientManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagementAPI.Controllers;

[ApiController]
[Route("Clients/{id:guid}/[controller]")]
public class CommentsController: ControllerBase
{
    [HttpGet]
    public ActionResult<List<CommentEntity>> Get(Guid id)
    {
        ClientEntity c = ClientsRepository.Clients.Find(i => i.Id == id);
        if (c == null) return NotFound();
        return c.Comments;
    }

    [HttpPost]
    public ActionResult<CommentEntity> Add(Guid id, CommentModel model)
    {
        ClientEntity c = ClientsRepository.Clients.Find(i => i.Id == id);
        if (c == null) return NotFound();
        CommentEntity e = new CommentEntity
        {
            Body = model.Body,
            Id = Guid.NewGuid(),
            CreatedAt = DateTime.Now,
            ModifiedAt = DateTime.Now
        };
        c.Comments.Add(e);
        return Ok(e);
    }
}