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
    public class RecruitmentStepConfiguration : IEntityTypeConfiguration<RecruitmentStep>
    {
        public void Configure(EntityTypeBuilder<RecruitmentStep> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.StepName).HasMaxLength(50);

        }
    }
}
