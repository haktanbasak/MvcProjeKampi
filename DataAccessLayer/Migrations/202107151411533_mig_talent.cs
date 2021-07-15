namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_talent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Talents",
                c => new
                    {
                        TalentID = c.Int(nullable: false, identity: true),
                        AdminID = c.Int(nullable: false),
                        TalentName = c.String(maxLength: 100),
                        TalentPercent = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TalentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Talents");
        }
    }
}
