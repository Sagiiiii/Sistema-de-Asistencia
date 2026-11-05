using SISAS.Infraestructure.Persistences.Contexts;
using SISAS.Infraestructure.Persistences.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Infraestructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmpleadoDbContext _context;

        public UnitOfWork(EmpleadoDbContext context)
        {
            _context = context;
            Area = new AreaRepository(_context);
            Horario = new HorarioRepository(_context);
        }
        public IAreaRepository Area { get; private set; }

        public IHorarioRepository Horario { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
