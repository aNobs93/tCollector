namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingStringForDateToDateTimeNow : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ExtraPickUpDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "SuspendedStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "SuspendedEnd", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "SuspendedEnd", c => c.String());
            AlterColumn("dbo.Customers", "SuspendedStart", c => c.String());
            AlterColumn("dbo.Customers", "ExtraPickUpDate", c => c.String());
        }
    }
}
