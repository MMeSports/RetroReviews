namespace RetroReview.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PicProp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Password");
        }
    }
}
