using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransformationWorkoutLife.Models;
using TransformationWorkoutLogger.Models;

namespace TransformationWorkoutLife.Models
{
    public class DBContext : DbContext
    {


        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }


        public DbSet<TransformationWorkoutLife.Models.Admin> Admin { get; set; }


        public DbSet<TransformationWorkoutLife.Models.Bio> Bio { get; set; }


        public DbSet<TransformationWorkoutLife.Models.BioBlurb> BioBlurb { get; set; }


        public DbSet<TransformationWorkoutLife.Models.Blog> Blog { get; set; }


        public DbSet<TransformationWorkoutLife.Models.BlogBlurb> BlogBlurb { get; set; }


        public DbSet<TransformationWorkoutLife.Models.Blurb> Blurb { get; set; }


        public DbSet<TransformationWorkoutLife.Models.Item> Item { get; set; }


        public DbSet<TransformationWorkoutLife.Models.Merchant> Merchant { get; set; }


        public DbSet<TransformationWorkoutLife.Models.Product> Product { get; set; }


        public DbSet<TransformationWorkoutLife.Models.Trainer> Trainer { get; set; }


        public DbSet<TransformationWorkoutLife.Models.Training> Training { get; set; }


        public DbSet<TransformationWorkoutLife.Models.TrainingVideo> TrainingVideo { get; set; }


        public DbSet<TransformationWorkoutLogger.Models.Guest> Guest { get; set; }


        public DbSet<TransformationWorkoutLogger.Models.GuestItemOrdered> GuestItemOrdered { get; set; }


        public DbSet<TransformationWorkoutLogger.Models.GuestOrder> GuestOrder { get; set; }


        public DbSet<TransformationWorkoutLogger.Models.GuestSchedule> GuestSchedule { get; set; }


        public DbSet<TransformationWorkoutLogger.Models.GuestTrainingOrdered> GuestTrainingOrdered { get; set; }


        public DbSet<TransformationWorkoutLogger.Models.Schedule> Schedule { get; set; }



    }
}
