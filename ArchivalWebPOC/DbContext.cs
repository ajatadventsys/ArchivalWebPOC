using System.Data.Entity;

public class LIMSDevContext : DbContext
{
    //New Table
    public DbSet<ArchivalSchedule> ArchivalSchedules { get; set; }

    //Secondary Tables
    public DbSet<AuditHistoryArchival> AuditHistoryArchivals { get; set; }
    public DbSet<BarCodeResultArchival> BarCodeResultArchivals { get; set; }
    public DbSet<RegBarCodeArchival> RegBarCodeArchivals { get; set; }
    public DbSet<RegistrationInfoArchival> RegistrationInfoArchivals { get; set; }
    public DbSet<AutoApprovalLogArchival> AutoApprovalLogArchivals { get; set; }

    public LIMSDevContext() : base("name=LIMSDevContext")
    {
        //if it is set then EF will not create DB if does not exist 
        Database.SetInitializer<LIMSDevContext>(null);
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //New Table
        modelBuilder.Entity<ArchivalSchedule>().ToTable("Archival_Schedule");

        //Secondary Tables
        modelBuilder.Entity<AuditHistoryArchival>().ToTable("AuditHistory_Archival");
        modelBuilder.Entity<BarCodeResultArchival>().ToTable("REG_BarCodeResult_Archival");
        modelBuilder.Entity<RegBarCodeArchival>().ToTable("TRF_Reg_BarCode_Archival");
        modelBuilder.Entity<RegistrationInfoArchival>().ToTable("TRF_RegistrationInfo_Archival");
        modelBuilder.Entity<AutoApprovalLogArchival>().ToTable("TrnAutoApprovalLog_Archival");
    }
}
