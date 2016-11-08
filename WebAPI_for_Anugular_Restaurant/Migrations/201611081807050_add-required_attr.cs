namespace WebAPI_for_Anugular_Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrequired_attr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_Meals_Category", "meal_name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Meals_Category", "meal_name", c => c.String());
        }
    }
}
