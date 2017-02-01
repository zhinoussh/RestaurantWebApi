namespace WebAPI_for_Anugular_Restaurant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_tbl_SubCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_Sub_Category",
                c => new
                    {
                        SubCategoryID = c.Int(nullable: false, identity: true),
                        CategoryID = c.Int(),
                        SubCategoryName = c.String(),
                        price = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SubCategoryID)
                .ForeignKey("dbo.tbl_Meals_Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Sub_Category", "CategoryID", "dbo.tbl_Meals_Category");
            DropIndex("dbo.tbl_Sub_Category", new[] { "CategoryID" });
            DropTable("dbo.tbl_Sub_Category");
        }
    }
}
