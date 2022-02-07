namespace ClientManagementAPI.Entities;

public class ClientEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }

    public List<CommentEntity> Comments { get; set; } = new List<CommentEntity>();
}