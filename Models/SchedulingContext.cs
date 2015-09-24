using System;
using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Dnx.Runtime;
using Microsoft.Dnx.Runtime.Infrastructure;
using Microsoft.Framework.DependencyInjection;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace playgroud_asp_schedule.Models
{

    public class SchedulingContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Event> Event { get; set; }

        public DbSet<Location> Location { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var appEnv = CallContextServiceLocator.Locator.ServiceProvider
                            .GetRequiredService<IApplicationEnvironment>();
            optionsBuilder.UseSqlite($"Data Source={ appEnv.ApplicationBasePath }/scheduling.db");
        }
    }

    public class User
    {
        [Display(Name = "User ID")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }

        [Required]
        [Display(Name = "Name")]
        [StringLength(50)]
        public string name { get; set; }

    }

    public class Location
    {
        
        [Display(Name = "Location ID")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int location_id { get; set; }

        [Required]
        [Display(Name = "Location")]
        [StringLength(50)]
        public string name { get; set; }
        
    }

    public class Event
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int event_id { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime stop { get; set; }

        [Required]
        [Display(Name = "User")]
        [ForeignKey("User")]
        public int user_id { get; set; }
        public virtual User User { get; set; }
        
        [Required]
        [Display(Name = "Location")]
        [ForeignKey("Location")]
        public int location_id { get; set; }
        public virtual Location Location { get; set; }


    }

}