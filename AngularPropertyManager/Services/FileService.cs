using AngularPropertyManager.Data;
using AngularPropertyManager.Interfaces;

namespace AngularPropertyManager.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationDbContext _context;

        public FileService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
