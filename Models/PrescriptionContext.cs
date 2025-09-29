using Microsoft.EntityFrameworkCore;

namespace PrescriptionApp.Models
{
    public class PrescriptionContext : DbContext
    {
        public PrescriptionContext(DbContextOptions<PrescriptionContext> options)
            : base(options) { }

        public DbSet<PrescriptionModel> Prescriptions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrescriptionModel>().HasData(

                new PrescriptionModel {
                    PrescriptionId = 1,
                    MedicationName = "Amoxicillin",
                    FillStatus = "New",
                    Cost = 12.99,
                    RequestTime = new DateTime(2025, 9, 27, 10, 30, 0)
                },
                new PrescriptionModel {
                    PrescriptionId = 2,
                    MedicationName = "Ibuprofen",
                    FillStatus = "Filled",
                    Cost = 8.49,
                    RequestTime = new DateTime(2025, 9, 24, 10, 30, 0)
                },
                new PrescriptionModel {
                    PrescriptionId = 3,
                    MedicationName = "Lisinopril",
                    FillStatus = "Pending",
                    Cost = 15.75,
                    RequestTime = new DateTime(2025, 9, 28, 10, 30, 0)
                }
            );
        }
    }
}
