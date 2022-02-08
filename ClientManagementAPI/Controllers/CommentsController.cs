using ClientManagementAPI.Entities;
using ClientManagementAPI.Models;
using ClientManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagementAPI.Controllers;

[ApiController]
[Route("{studentId}/Clients/{id:guid}/[controller]")]
public class CommentsController: ControllerBase
{
    [HttpGet]
    public ActionResult<List<CommentEntity>> Get(Guid id, string studentId)
    {
        if (!ClientsRepository.Clients.ContainsKey(studentId)) return NotFound();
        
        ClientEntity c = ClientsRepository.Clients[studentId].Find(i => i.Id == id);
        if (c == null) return NotFound();
        return c.Comments;
    }

    [HttpPost]
    public ActionResult<CommentEntity> Add(Guid id, CommentModel model, string studentId)
    {
        if (!ClientsRepository.Clients.ContainsKey(studentId)) return NotFound();
        
        ClientEntity c = ClientsRepository.Clients[studentId].Find(i => i.Id == id);
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