using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using playgroud_asp_schedule.Models;

namespace playgroudaspschedule.Migrations
{
    [DbContext(typeof(SchedulingContext))]
    partial class SchedulingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Annotation("ProductVersion", "7.0.0-beta7-15540");

            modelBuilder.Entity("playgroud_asp_schedule.Models.Event", b =>
                {
                    b.Property<int>("event_id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("location_id");

                    b.Property<DateTime>("start");

                    b.Property<DateTime>("stop");

                    b.Property<int>("user_id");

                    b.Key("event_id");
                });

            modelBuilder.Entity("playgroud_asp_schedule.Models.Location", b =>
                {
                    b.Property<int>("location_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name")
                        .Required()
                        .Annotation("MaxLength", 50);

                    b.Key("location_id");
                });

            modelBuilder.Entity("playgroud_asp_schedule.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("name")
                        .Required()
                        .Annotation("MaxLength", 50);

                    b.Key("user_id");
                });

            modelBuilder.Entity("playgroud_asp_schedule.Models.Event", b =>
                {
                    b.Reference("playgroud_asp_schedule.Models.Location")
                        .InverseCollection()
                        .ForeignKey("location_id");

                    b.Reference("playgroud_asp_schedule.Models.User")
                        .InverseCollection()
                        .ForeignKey("user_id");
                });
        }
    }
}
