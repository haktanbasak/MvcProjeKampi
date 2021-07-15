namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_salthash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "PasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "PasswordHash", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "PasswordHash");
            DropColumn("dbo.Admins", "PasswordSalt");
        }
    }
}
