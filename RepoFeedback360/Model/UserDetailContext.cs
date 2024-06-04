using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoFeedback360.Model
{
    public class UserDetailContext: DbContext
    {
        //public UserDetailContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        //{
            
        //}
        public DbSet<UserDetail> _dbUserDetails { get; set; }
        public DbSet<UserRoleDetails> _dbRoleDetails { get; set; }
        public DbSet<UserDesignationDetails> _dbDesignationDetails { get; set; }
        public DbSet<DL_OTPModel> _otpData { get; set; }
        public DbSet<FeedBackCatagoryML> _FeedBackCatagoryML { get; set; }

        public DbSet<FeedBackSchedulerML> _dtfeedBackScheduler { get; set; }

        public DbSet<FeedBackQuestions> _dbFeedbackQuestions { get; set; }
        public DbSet<FEEDBACKRATINGS> _dbFEEDBACKRATINGS { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
               optionsBuilder.UseSqlServer("Server=localhost;Database=Feedback360;User Id=sa;password=sql@tfs2008;TrustServerCertificate=True");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
