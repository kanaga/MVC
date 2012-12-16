namespace ProductMVC.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("Products", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("Products", "Email");
        }
    }
}
