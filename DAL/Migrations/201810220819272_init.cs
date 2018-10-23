namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Email = c.String(),
                        GoogleSub = c.String(),
                        Password = c.String(),
                        GoogleProfile_DisplayName = c.String(),
                        GoogleProfile_GooglePlus = c.String(),
                        GoogleProfile_Picture = c.String(),
                        Profile_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profile", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.BodyDimmenssions",
                c => new
                    {
                        DateTime = c.DateTime(nullable: false),
                        Id = c.Guid(nullable: false),
                        Height = c.Single(nullable: false),
                        Weight = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DateTime)
                .ForeignKey("dbo.Account", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Meal",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Account_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Account", t => t.Account_Id)
                .Index(t => t.Account_Id);
            
            CreateTable(
                "dbo.FoodInMeal",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        FoodName = c.String(),
                        Quantity = c.Int(nullable: false),
                        Meal_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Meal", t => t.Meal_Id)
                .Index(t => t.Meal_Id);
            
            CreateTable(
                "dbo.Profile",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FiestName = c.String(nullable: false),
                        LastName = c.String(),
                        Birthday = c.DateTime(),
                        Sex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CurrentAccount",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AccountID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FoodNutritionsItem",
                c => new
                    {
                        FoodName = c.String(nullable: false, maxLength: 250),
                        ID = c.Guid(nullable: false),
                        BrandName = c.String(maxLength: 250),
                        ServingQty = c.Long(nullable: false),
                        ServingUnit = c.String(),
                        ServingWeightGrams = c.Long(),
                        NfCalories = c.Double(),
                        NfTotalFat = c.Double(),
                        NfSaturatedFat = c.Double(),
                        NfCholesterol = c.Double(),
                        NfSodium = c.Double(),
                        NfTotalCarbohydrate = c.Long(),
                        NfDietaryFiber = c.Long(),
                        NfSugars = c.Long(),
                        NfProtein = c.Double(),
                        NfPotassium = c.Double(),
                        NfP = c.Double(),
                        ConsumedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        Metadata_IsRawFood = c.Boolean(nullable: false),
                        Source = c.Long(),
                        NdbNo = c.Long(),
                        Tags_Item = c.String(),
                        Tags_Quantity = c.String(),
                        Tags_FoodGroup = c.Long(),
                        Tags_TagId = c.Long(),
                        MealType = c.Long(),
                    })
                .PrimaryKey(t => t.FoodName)
                .ForeignKey("dbo.Photo", t => t.ID, cascadeDelete: true)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.Photo",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        Thumb = c.String(),
                        Highres = c.String(),
                        IsUserUploaded = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FoodUnit",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Id = c.Guid(nullable: false),
                        ImageUrl = c.String(),
                        FoodNutritionsItemID = c.Guid(nullable: false),
                        SearchFood_FoodName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.SearchFood", t => t.SearchFood_FoodName)
                .Index(t => t.SearchFood_FoodName);
            
            CreateTable(
                "dbo.SearchFood",
                c => new
                    {
                        FoodName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FoodName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodUnit", "SearchFood_FoodName", "dbo.SearchFood");
            DropForeignKey("dbo.FoodNutritionsItem", "ID", "dbo.Photo");
            DropForeignKey("dbo.Account", "Profile_Id", "dbo.Profile");
            DropForeignKey("dbo.Meal", "Account_Id", "dbo.Account");
            DropForeignKey("dbo.FoodInMeal", "Meal_Id", "dbo.Meal");
            DropForeignKey("dbo.BodyDimmenssions", "Id", "dbo.Account");
            DropIndex("dbo.FoodUnit", new[] { "SearchFood_FoodName" });
            DropIndex("dbo.FoodNutritionsItem", new[] { "ID" });
            DropIndex("dbo.FoodInMeal", new[] { "Meal_Id" });
            DropIndex("dbo.Meal", new[] { "Account_Id" });
            DropIndex("dbo.BodyDimmenssions", new[] { "Id" });
            DropIndex("dbo.Account", new[] { "Profile_Id" });
            DropTable("dbo.SearchFood");
            DropTable("dbo.FoodUnit");
            DropTable("dbo.Photo");
            DropTable("dbo.FoodNutritionsItem");
            DropTable("dbo.CurrentAccount");
            DropTable("dbo.Profile");
            DropTable("dbo.FoodInMeal");
            DropTable("dbo.Meal");
            DropTable("dbo.BodyDimmenssions");
            DropTable("dbo.Account");
        }
    }
}
