using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public partial class AnimalShelterEntities : DbContext
    {
        private static AnimalShelterEntities _context;
        public static AnimalShelterEntities GetContext()
        {
            if (_context == null)
                _context = new AnimalShelterEntities();

            return _context;
        }
    }
}