﻿using Microsoft.EntityFrameworkCore;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure;

public interface IThriftAppDbContext
{
    DbSet<Member> Members { get; set; }
    DbSet<Group> Groups { get; set; }
    DbSet<ContributionSession> ContributionSessions { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}
