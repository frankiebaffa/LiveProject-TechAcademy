public partial class AddCampaignId : DbMigration
{
    public override void Up()
    {
        DropForeignKey("dbo.Reviews", "Campaign_CampaignID", "dbo.Campaigns");
        DropIndex("dbo.Reviews", new[] { "Campaign_CampaignID" });
        RenameColumn(table: "dbo.Reviews", name: "Campaign_CampaignID", newName: "CampaignId");
        AlterColumn("dbo.Reviews", "CampaignId", c => c.Int(nullable: true));
        CreateIndex("dbo.Reviews", "CampaignId");
        AddForeignKey("dbo.Reviews", "CampaignId", "dbo.Campaigns", "CampaignID", cascadeDelete: true);
    }

    public override void Down()
    {
        DropForeignKey("dbo.Reviews", "CampaignId", "dbo.Campaigns");
        DropIndex("dbo.Reviews", new[] { "CampaignId" });
        AlterColumn("dbo.Reviews", "CampaignId", c => c.Int());
        RenameColumn(table: "dbo.Reviews", name: "CampaignId", newName: "Campaign_CampaignID");
        CreateIndex("dbo.Reviews", "Campaign_CampaignID");
        AddForeignKey("dbo.Reviews", "Campaign_CampaignID", "dbo.Campaigns", "CampaignID");
    }
}
