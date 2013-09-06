namespace QuestManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddItemToReward : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ItemId);
            
            AddColumn("dbo.Rewards", "Item_ItemId", c => c.Int());
            CreateIndex("dbo.Rewards", "Item_ItemId");
            AddForeignKey("dbo.Rewards", "Item_ItemId", "dbo.Items", "ItemId");
            DropColumn("dbo.Rewards", "ItemId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Rewards", "ItemId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Rewards", "Item_ItemId", "dbo.Items");
            DropIndex("dbo.Rewards", new[] { "Item_ItemId" });
            DropColumn("dbo.Rewards", "Item_ItemId");
            DropTable("dbo.Items");
        }
    }
}
