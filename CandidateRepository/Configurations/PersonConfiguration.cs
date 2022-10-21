using CandidateCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateRepository.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Position)
                   .WithMany(x => x.Persons)
                   .HasForeignKey(x => x.PositionId);

            builder.HasOne(x => x.RecruitmentStep)
                   .WithMany(x => x.Persons)
                   .HasForeignKey(x => x.RecruitmentStepId);

            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.SurName).HasMaxLength(50);
            builder.Property(x => x.Mail).HasMaxLength(50);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);


        }
    }
}
