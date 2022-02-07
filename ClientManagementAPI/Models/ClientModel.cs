using System.ComponentModel.DataAnnotations;

namespace ClientManagementAPI.Models;

public class ClientCreationModel
{
    [MinLength(2)]
    public string FirstName { get; set; }
    [MinLength(2)]
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
}