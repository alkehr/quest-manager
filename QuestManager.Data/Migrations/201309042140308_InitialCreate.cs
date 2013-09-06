namespace QuestManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Quests",
                c => new
                    {
                        QuestId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestId);
            
            CreateTable(
                "dbo.Objectives",
                c => new
                    {
                        ObjectiveId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Quest_QuestId = c.Int(),
                    })
                .PrimaryKey(t => t.ObjectiveId)
                .ForeignKey("dbo.Quests", t => t.Quest_QuestId)
                .Index(t => t.Quest_QuestId);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        RewardId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Quantity = c.Int(nullable: false),
                        QuestId = c.Int(nullable: false),
                        ItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RewardId)
                .ForeignKey("dbo.Quests", t => t.QuestId, cascadeDelete: true)
                .Index(t => t.QuestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rewards", "QuestId", "dbo.Quests");
            DropForeignKey("dbo.Objectives", "Quest_QuestId", "dbo.Quests");
            DropIndex("dbo.Rewards", new[] { "QuestId" });
            DropIndex("dbo.Objectives", new[] { "Quest_QuestId" });
            DropTable("dbo.Rewards");
            DropTable("dbo.Objectives");
            DropTable("dbo.Quests");
        }
    }
}
