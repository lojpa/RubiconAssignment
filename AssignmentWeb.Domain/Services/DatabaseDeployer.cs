using AssignmentWeb.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace AssignmentWeb.Domain.Services
{
    public class DatabaseDeployer
    {
        private RubiconContext _context;

        public DatabaseDeployer(RubiconContext context)
        {
            _context = context;
        }

        public void Migrate()
        {
            _context.Database.Migrate();
        }
    }
}
