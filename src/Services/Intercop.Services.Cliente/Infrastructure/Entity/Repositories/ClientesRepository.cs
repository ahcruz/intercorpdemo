using Intercop.Services.Cliente.Domain.Repositories;

namespace Intercop.Services.Cliente.Infrastructure.Entity.Repositories
{
    public class ClientesRepository : BaseRepository<Domain.Cliente>, IClientesRepository
    {
        public ClientesRepository(Context _db) : base(_db)
        {
        }
    }
}
