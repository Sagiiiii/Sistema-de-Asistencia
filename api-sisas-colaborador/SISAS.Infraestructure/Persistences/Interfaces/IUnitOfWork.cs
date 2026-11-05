using System;
using System.Collections.Generic;
using System.Text;

namespace SISAS.Infraestructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAreaRepository  Area { get; }
        IHorarioRepository Horario { get; }
        void SaveChanges();
        Task SaveChangeAsync();
    }
}
