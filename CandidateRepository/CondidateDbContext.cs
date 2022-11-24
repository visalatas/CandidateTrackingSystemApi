﻿using CandidateCore.Models;
using CandidateRepository.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CandidateRepository
{
    public class CondidateDbContext : DbContext
    {
        public CondidateDbContext(DbContextOptions<CondidateDbContext> options) : base(options)
        {
            //bu bir constructure method'dur.
            //bir clastan nesne oluşturulduğu zaman, ilk burası çalışır.
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<RecruitmentStep> RecruitmentSteps { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReferance)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReferance.CreateDate = DateTime.Now;
                                break;
                            }
                            case EntityState.Modified:
                            {
                                Entry(entityReferance).Property(x => x.CreateDate).IsModified = false;

                                entityReferance.UpdateDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());
            modelBuilder.ApplyConfiguration(new PositionConfiguration());
            modelBuilder.ApplyConfiguration(new RecruitmentStepConfiguration());




        }
    }

}