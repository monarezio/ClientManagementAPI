using System.ComponentModel.DataAnnotations;

namespace ClientManagementAPI.Models;

public class CommentModel
{
    [Required]
    [MaxLength(255)]
    public string Body { get; set; }
}