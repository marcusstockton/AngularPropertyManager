using AngularPropertyManager.Data;
using AngularPropertyManager.Interfaces;

namespace AngularPropertyManager.Services
{
    public class NoteService: INoteService
    {
        private readonly ApplicationDbContext _context;

        public NoteService(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
