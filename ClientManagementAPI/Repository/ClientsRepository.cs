using ClientManagementAPI.Entities;

namespace ClientManagementAPI.Repository;

public class ClientsRepository
{
    public static Dictionary<string, List<ClientEntity>> Clients = new Dictionary<string, List<ClientEntity>>();
}