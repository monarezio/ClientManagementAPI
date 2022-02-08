using ClientManagementAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagementAPI.Controllers;

[ApiController]
[Route("{studentId}/[controller]")]
public class ResetController : ControllerBase
{
    [HttpDelete]
    public IActionResult Destroy(string studentId)
    {
        if (!ClientsRepository.Clients.ContainsKey(studentId)) return NotFound();
        
        ClientsRepository.Clients[studentId].Clear();
        return NoContent();
    }
}