using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Data
{
    public static class ChangeTrackerExtensions
    {
        public static void SetAuditProperties(this ChangeTracker changeTracker)
        {
            foreach (var auditableEntity in changeTracker.Entries<IAuditable>())
            {
                var currentDateTime = DateTimeProvider.Now();
                if (auditableEntity.State == EntityState.Added ||
                    auditableEntity.State == EntityState.Modified)
                {
                    auditableEntity.Entity.UpdateDate = currentDateTime;

                    if (auditableEntity.State == EntityState.Added)
                    {
                        auditableEntity.Entity.CreationDate = currentDateTime;
                    }
                }
            }
        }
    }
}
