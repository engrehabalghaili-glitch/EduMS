using EduMS.Domain.Entities.M2_StudentAffairs;
using EduMS.Domain.Interfaces.M2_StudentAffairs;
using EduMS.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduMS.Infrastructure.M2_StudentAffairs.Repositories;

public class RegistrationRepository(EduMSDbContext context) : IRegistrationRepository
{
    public async Task<long> AddAsync(Registration registration, CancellationToken cancellationToken = default)
    {
        await context.Registrations.AddAsync(registration, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return registration.Id;
    }

    public async Task DeleteAsync(Registration registration, CancellationToken cancellationToken = default)
    {
        context.Registrations.Remove(registration);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<Registration>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Registrations.ToListAsync(cancellationToken);
    }

    public async Task<Registration?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
    {
        return await context.Registrations.FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
    }

    public async Task UpdateAsync(Registration registration, CancellationToken cancellationToken = default)
    {
        context.Registrations.Update(registration);
        await context.SaveChangesAsync(cancellationToken);
    }
}
