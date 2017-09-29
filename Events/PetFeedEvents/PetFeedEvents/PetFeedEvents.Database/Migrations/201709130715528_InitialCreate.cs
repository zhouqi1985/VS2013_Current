namespace PetFeedEvents.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DynamicPacketQueue",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        PacketId = c.Int(nullable: false),
                        AvatarId = c.Long(nullable: false),
                        Sex = c.Int(nullable: false),
                        Site = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        ItemCode = c.String(nullable: false),
                        PacketItemTime = c.Int(nullable: false),
                        PacketItemCount = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false,defaultValueSql:"GETDATE()"),
                        Source = c.String(nullable: false),
                        GUID = c.Guid(nullable: false),
                        Gold = c.Int(nullable: false),
                        BindCash = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.GUID, unique: true, name: "IX_GUIDUnique");
            
            CreateTable(
                "dbo.DynamicPacketQueueLog",
                c => new
                    {
                        LogId = c.Long(nullable: false, identity: true),
                        PacketId = c.Int(nullable: false),
                        AvatarId = c.Long(nullable: false),
                        Sex = c.Int(nullable: false),
                        Site = c.Int(nullable: false),
                        UserId = c.Long(nullable: false),
                        ItemCode = c.String(nullable: false),
                        PacketItemTime = c.Int(nullable: false),
                        PacketItemCount = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false,defaultValueSql:"GETDATE()"),
                        Source = c.String(nullable: false),
                        GUID = c.Guid(nullable: false),
                        Gold = c.Int(nullable: false),
                        BindCash = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogId)
                .Index(t => t.GUID, unique: true, name: "IX_GUIDUnique");
            
            CreateTable(
                "dbo.GameDailyLog",
                c => new
                    {
                        RecordId = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        AreaId = c.Int(nullable: false),
                        AvatarId = c.Long(nullable: false),
                        AvatarName = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                        RecordDate = c.DateTime(nullable: false),
                        TaskConfigId = c.Int(nullable: false),
                        ActualNum = c.Int(nullable: false),
                        FinalGetNum = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false,defaultValueSql:"GETDATE()"),
                        GUID = c.Guid(nullable: false),
                        Source = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.TaskConfig", t => t.TaskConfigId)
                .Index(t => t.TaskConfigId);
            
            CreateTable(
                "dbo.TaskConfig",
                c => new
                    {
                        TaskConfigId = c.Int(nullable: false),
                        TaskName = c.String(nullable: false),
                        TaskDesc = c.String(),
                        PacketId = c.Int(nullable: false),
                        ItemCode = c.String(nullable: false),
                        ItemTimePerTask = c.Int(nullable: false),
                        ItemCountPerTask = c.Int(nullable: false),
                        GoldPerTask = c.Int(nullable: false),
                        BindCashPerTask = c.Int(nullable: false),
                        Source = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TaskConfigId)
                .Index(t => t.PacketId, unique: true, name: "IX_PacketUnique");
            
            CreateTable(
                "dbo.GameDailyLogHistory",
                c => new
                    {
                        HistoryId = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        AreaId = c.Int(nullable: false),
                        AvatarId = c.Long(nullable: false),
                        AvatarName = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                        RecordDate = c.DateTime(nullable: false),
                        TaskConfigId = c.Int(nullable: false),
                        ActualNum = c.Int(nullable: false),
                        FinalGetNum = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false,defaultValueSql:"GETDATE()"),
                        GUID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.HistoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameDailyLog", "TaskConfigId", "dbo.TaskConfig");
            DropIndex("dbo.TaskConfig", "IX_PacketUnique");
            DropIndex("dbo.GameDailyLog", new[] { "TaskConfigId" });
            DropIndex("dbo.DynamicPacketQueueLog", "IX_GUIDUnique");
            DropIndex("dbo.DynamicPacketQueue", "IX_GUIDUnique");
            DropTable("dbo.GameDailyLogHistory");
            DropTable("dbo.TaskConfig");
            DropTable("dbo.GameDailyLog");
            DropTable("dbo.DynamicPacketQueueLog");
            DropTable("dbo.DynamicPacketQueue");
        }
    }
}
