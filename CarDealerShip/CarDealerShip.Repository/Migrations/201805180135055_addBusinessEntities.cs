namespace CarDealerShip.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBusinessEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BodyStyles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Interiors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Makes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleId = c.Int(nullable: false),
                        Phone = c.String(),
                        Email = c.String(),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        SalePrice = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        SalesPersonId = c.Int(nullable: false),
                        PurchaseType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Specials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transmissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MakeId = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelYear = c.Int(nullable: false),
                        SalePrice = c.Double(nullable: false),
                        Featured = c.Boolean(nullable: false),
                        Sold = c.Boolean(nullable: false),
                        Vin = c.String(),
                        Make = c.Int(nullable: false),
                        Model = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        BodyStyle = c.Int(nullable: false),
                        Transmission = c.Int(nullable: false),
                        Color = c.Int(nullable: false),
                        Interior = c.Int(nullable: false),
                        Mileage = c.Double(nullable: false),
                        MSRP = c.Double(nullable: false),
                        Description = c.String(),
                        PictureUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.BodyStyle_Insert",
                p => new
                    {
                        Description = p.String(),
                    },
                body:
                    @"INSERT [dbo].[BodyStyles]([Description])
                      VALUES (@Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[BodyStyles]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[BodyStyles] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.BodyStyle_Update",
                p => new
                    {
                        Id = p.Int(),
                        Description = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[BodyStyles]
                      SET [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.BodyStyle_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[BodyStyles]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Color_Insert",
                p => new
                    {
                        Description = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Colors]([Description])
                      VALUES (@Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Colors]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Colors] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Color_Update",
                p => new
                    {
                        Id = p.Int(),
                        Description = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Colors]
                      SET [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Color_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Colors]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.ContactForm_Insert",
                p => new
                    {
                        Name = p.String(),
                        Email = p.String(),
                        Phone = p.String(),
                        Message = p.String(),
                    },
                body:
                    @"INSERT [dbo].[ContactForms]([Name], [Email], [Phone], [Message])
                      VALUES (@Name, @Email, @Phone, @Message)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[ContactForms]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[ContactForms] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.ContactForm_Update",
                p => new
                    {
                        Id = p.Int(),
                        Name = p.String(),
                        Email = p.String(),
                        Phone = p.String(),
                        Message = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[ContactForms]
                      SET [Name] = @Name, [Email] = @Email, [Phone] = @Phone, [Message] = @Message
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.ContactForm_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[ContactForms]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Interior_Insert",
                p => new
                    {
                        Description = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Interiors]([Description])
                      VALUES (@Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Interiors]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Interiors] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Interior_Update",
                p => new
                    {
                        Id = p.Int(),
                        Description = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Interiors]
                      SET [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Interior_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Interiors]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Make_Insert",
                p => new
                    {
                        Description = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Makes]([Description])
                      VALUES (@Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Makes]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Makes] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Make_Update",
                p => new
                    {
                        Id = p.Int(),
                        Description = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Makes]
                      SET [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Make_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Makes]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Purchase_Insert",
                p => new
                    {
                        VehicleId = p.Int(),
                        Phone = p.String(),
                        Email = p.String(),
                        Street1 = p.String(),
                        Street2 = p.String(),
                        City = p.String(),
                        State = p.String(),
                        ZipCode = p.String(),
                        SalePrice = p.Double(),
                        PurchaseDate = p.DateTime(),
                        SalesPersonId = p.Int(),
                        PurchaseType = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Purchases]([VehicleId], [Phone], [Email], [Street1], [Street2], [City], [State], [ZipCode], [SalePrice], [PurchaseDate], [SalesPersonId], [PurchaseType])
                      VALUES (@VehicleId, @Phone, @Email, @Street1, @Street2, @City, @State, @ZipCode, @SalePrice, @PurchaseDate, @SalesPersonId, @PurchaseType)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Purchases]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Purchases] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Purchase_Update",
                p => new
                    {
                        Id = p.Int(),
                        VehicleId = p.Int(),
                        Phone = p.String(),
                        Email = p.String(),
                        Street1 = p.String(),
                        Street2 = p.String(),
                        City = p.String(),
                        State = p.String(),
                        ZipCode = p.String(),
                        SalePrice = p.Double(),
                        PurchaseDate = p.DateTime(),
                        SalesPersonId = p.Int(),
                        PurchaseType = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Purchases]
                      SET [VehicleId] = @VehicleId, [Phone] = @Phone, [Email] = @Email, [Street1] = @Street1, [Street2] = @Street2, [City] = @City, [State] = @State, [ZipCode] = @ZipCode, [SalePrice] = @SalePrice, [PurchaseDate] = @PurchaseDate, [SalesPersonId] = @SalesPersonId, [PurchaseType] = @PurchaseType
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Purchase_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Purchases]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Special_Insert",
                p => new
                    {
                        Description = p.String(),
                        Title = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Specials]([Description], [Title])
                      VALUES (@Description, @Title)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Specials]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Specials] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Special_Update",
                p => new
                    {
                        Id = p.Int(),
                        Description = p.String(),
                        Title = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Specials]
                      SET [Description] = @Description, [Title] = @Title
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Special_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Specials]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Transmission_Insert",
                p => new
                    {
                        Description = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Transmissions]([Description])
                      VALUES (@Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Transmissions]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Transmissions] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Transmission_Update",
                p => new
                    {
                        Id = p.Int(),
                        Description = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Transmissions]
                      SET [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Transmission_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Transmissions]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.VehicleModel_Insert",
                p => new
                    {
                        MakeId = p.Int(),
                        Description = p.String(),
                    },
                body:
                    @"INSERT [dbo].[VehicleModels]([MakeId], [Description])
                      VALUES (@MakeId, @Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[VehicleModels]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[VehicleModels] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.VehicleModel_Update",
                p => new
                    {
                        Id = p.Int(),
                        MakeId = p.Int(),
                        Description = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[VehicleModels]
                      SET [MakeId] = @MakeId, [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.VehicleModel_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[VehicleModels]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Vehicle_Insert",
                p => new
                    {
                        ModelYear = p.Int(),
                        SalePrice = p.Double(),
                        Featured = p.Boolean(),
                        Sold = p.Boolean(),
                        Vin = p.String(),
                        Make = p.Int(),
                        Model = p.Int(),
                        Type = p.Int(),
                        BodyStyle = p.Int(),
                        Transmission = p.Int(),
                        Color = p.Int(),
                        Interior = p.Int(),
                        Mileage = p.Double(),
                        MSRP = p.Double(),
                        Description = p.String(),
                        PictureUrl = p.String(),
                    },
                body:
                    @"INSERT [dbo].[Vehicles]([ModelYear], [SalePrice], [Featured], [Sold], [Vin], [Make], [Model], [Type], [BodyStyle], [Transmission], [Color], [Interior], [Mileage], [MSRP], [Description], [PictureUrl])
                      VALUES (@ModelYear, @SalePrice, @Featured, @Sold, @Vin, @Make, @Model, @Type, @BodyStyle, @Transmission, @Color, @Interior, @Mileage, @MSRP, @Description, @PictureUrl)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Vehicles]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Vehicles] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Vehicle_Update",
                p => new
                    {
                        Id = p.Int(),
                        ModelYear = p.Int(),
                        SalePrice = p.Double(),
                        Featured = p.Boolean(),
                        Sold = p.Boolean(),
                        Vin = p.String(),
                        Make = p.Int(),
                        Model = p.Int(),
                        Type = p.Int(),
                        BodyStyle = p.Int(),
                        Transmission = p.Int(),
                        Color = p.Int(),
                        Interior = p.Int(),
                        Mileage = p.Double(),
                        MSRP = p.Double(),
                        Description = p.String(),
                        PictureUrl = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[Vehicles]
                      SET [ModelYear] = @ModelYear, [SalePrice] = @SalePrice, [Featured] = @Featured, [Sold] = @Sold, [Vin] = @Vin, [Make] = @Make, [Model] = @Model, [Type] = @Type, [BodyStyle] = @BodyStyle, [Transmission] = @Transmission, [Color] = @Color, [Interior] = @Interior, [Mileage] = @Mileage, [MSRP] = @MSRP, [Description] = @Description, [PictureUrl] = @PictureUrl
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Vehicle_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Vehicles]
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.VehicleType_Insert",
                p => new
                    {
                        Description = p.String(),
                    },
                body:
                    @"INSERT [dbo].[VehicleTypes]([Description])
                      VALUES (@Description)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[VehicleTypes]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[VehicleTypes] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.VehicleType_Update",
                p => new
                    {
                        Id = p.Int(),
                        Description = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[VehicleTypes]
                      SET [Description] = @Description
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.VehicleType_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[VehicleTypes]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.VehicleType_Delete");
            DropStoredProcedure("dbo.VehicleType_Update");
            DropStoredProcedure("dbo.VehicleType_Insert");
            DropStoredProcedure("dbo.Vehicle_Delete");
            DropStoredProcedure("dbo.Vehicle_Update");
            DropStoredProcedure("dbo.Vehicle_Insert");
            DropStoredProcedure("dbo.VehicleModel_Delete");
            DropStoredProcedure("dbo.VehicleModel_Update");
            DropStoredProcedure("dbo.VehicleModel_Insert");
            DropStoredProcedure("dbo.Transmission_Delete");
            DropStoredProcedure("dbo.Transmission_Update");
            DropStoredProcedure("dbo.Transmission_Insert");
            DropStoredProcedure("dbo.Special_Delete");
            DropStoredProcedure("dbo.Special_Update");
            DropStoredProcedure("dbo.Special_Insert");
            DropStoredProcedure("dbo.Purchase_Delete");
            DropStoredProcedure("dbo.Purchase_Update");
            DropStoredProcedure("dbo.Purchase_Insert");
            DropStoredProcedure("dbo.Make_Delete");
            DropStoredProcedure("dbo.Make_Update");
            DropStoredProcedure("dbo.Make_Insert");
            DropStoredProcedure("dbo.Interior_Delete");
            DropStoredProcedure("dbo.Interior_Update");
            DropStoredProcedure("dbo.Interior_Insert");
            DropStoredProcedure("dbo.ContactForm_Delete");
            DropStoredProcedure("dbo.ContactForm_Update");
            DropStoredProcedure("dbo.ContactForm_Insert");
            DropStoredProcedure("dbo.Color_Delete");
            DropStoredProcedure("dbo.Color_Update");
            DropStoredProcedure("dbo.Color_Insert");
            DropStoredProcedure("dbo.BodyStyle_Delete");
            DropStoredProcedure("dbo.BodyStyle_Update");
            DropStoredProcedure("dbo.BodyStyle_Insert");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleModels");
            DropTable("dbo.Transmissions");
            DropTable("dbo.Specials");
            DropTable("dbo.Purchases");
            DropTable("dbo.Makes");
            DropTable("dbo.Interiors");
            DropTable("dbo.ContactForms");
            DropTable("dbo.Colors");
            DropTable("dbo.BodyStyles");
        }
    }
}
