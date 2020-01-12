namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingMyDateTimeNullableIBelieve : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "ExtraPickUpDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "SuspendedStart", c => c.DateTime());
            AlterColumn("dbo.Customers", "SuspendedEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "SuspendedEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "SuspendedStart", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "ExtraPickUpDate", c => c.DateTime(nullable: false));
        }
    }
}
