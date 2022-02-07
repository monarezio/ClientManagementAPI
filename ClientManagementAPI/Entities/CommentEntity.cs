using System.ComponentModel.DataAnnotations;

namespace ClientManagementAPI.Entities;

public class CommentEntity
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
    [Required]
    public string Body { get; set; }
}