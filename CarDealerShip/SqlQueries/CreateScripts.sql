﻿CREATE TABLE [dbo].[BodyStyles] (
    [Id] [int] NOT NULL IDENTITY,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.BodyStyles] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Colors] (
    [Id] [int] NOT NULL IDENTITY,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.Colors] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[ContactForms] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    [Email] [nvarchar](max),
    [Phone] [nvarchar](max),
    [Message] [nvarchar](max),
    CONSTRAINT [PK_dbo.ContactForms] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Interiors] (
    [Id] [int] NOT NULL IDENTITY,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.Interiors] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Makes] (
    [Id] [int] NOT NULL IDENTITY,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.Makes] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Purchases] (
    [Id] [int] NOT NULL IDENTITY,
    [VehicleId] [int] NOT NULL,
    [Phone] [nvarchar](max),
    [Email] [nvarchar](max),
    [Street1] [nvarchar](max),
    [Street2] [nvarchar](max),
    [City] [nvarchar](max),
    [State] [nvarchar](max),
    [ZipCode] [nvarchar](max),
    [SalePrice] [float] NOT NULL,
    [PurchaseDate] [datetime] NOT NULL,
    [SalesPersonId] [int] NOT NULL,
    [PurchaseType] [int] NOT NULL,
    CONSTRAINT [PK_dbo.Purchases] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Specials] (
    [Id] [int] NOT NULL IDENTITY,
    [Description] [nvarchar](max),
    [Title] [nvarchar](max),
    CONSTRAINT [PK_dbo.Specials] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Transmissions] (
    [Id] [int] NOT NULL IDENTITY,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.Transmissions] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[VehicleModels] (
    [Id] [int] NOT NULL IDENTITY,
    [MakeId] [int] NOT NULL,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.VehicleModels] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Vehicles] (
    [Id] [int] NOT NULL IDENTITY,
    [ModelYear] [int] NOT NULL,
    [SalePrice] [float] NOT NULL,
    [Featured] [bit] NOT NULL,
    [Sold] [bit] NOT NULL,
    [Vin] [nvarchar](max),
    [Make] [int] NOT NULL,
    [Model] [int] NOT NULL,
    [Type] [int] NOT NULL,
    [BodyStyle] [int] NOT NULL,
    [Transmission] [int] NOT NULL,
    [Color] [int] NOT NULL,
    [Interior] [int] NOT NULL,
    [Mileage] [float] NOT NULL,
    [MSRP] [float] NOT NULL,
    [Description] [nvarchar](max),
    [PictureUrl] [nvarchar](max),
    CONSTRAINT [PK_dbo.Vehicles] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[VehicleTypes] (
    [Id] [int] NOT NULL IDENTITY,
    [Description] [nvarchar](max),
    CONSTRAINT [PK_dbo.VehicleTypes] PRIMARY KEY ([Id])
)
GO

CREATE PROCEDURE [dbo].[BodyStyle_Insert]
    @Description [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[BodyStyles]([Description])
    VALUES (@Description)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[BodyStyles]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[BodyStyles] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[BodyStyle_Update]
    @Id [int],
    @Description [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[BodyStyles]
    SET [Description] = @Description
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[BodyStyle_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[BodyStyles]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Color_Insert]
    @Description [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[Colors]([Description])
    VALUES (@Description)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[Colors]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[Colors] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[Color_Update]
    @Id [int],
    @Description [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[Colors]
    SET [Description] = @Description
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Color_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[Colors]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[ContactForm_Insert]
    @Name [nvarchar](max),
    @Email [nvarchar](max),
    @Phone [nvarchar](max),
    @Message [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[ContactForms]([Name], [Email], [Phone], [Message])
    VALUES (@Name, @Email, @Phone, @Message)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[ContactForms]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[ContactForms] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[ContactForm_Update]
    @Id [int],
    @Name [nvarchar](max),
    @Email [nvarchar](max),
    @Phone [nvarchar](max),
    @Message [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[ContactForms]
    SET [Name] = @Name, [Email] = @Email, [Phone] = @Phone, [Message] = @Message
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[ContactForm_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[ContactForms]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Interior_Insert]
    @Description [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[Interiors]([Description])
    VALUES (@Description)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[Interiors]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[Interiors] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[Interior_Update]
    @Id [int],
    @Description [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[Interiors]
    SET [Description] = @Description
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Interior_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[Interiors]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Make_Insert]
    @Description [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[Makes]([Description])
    VALUES (@Description)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[Makes]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[Makes] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[Make_Update]
    @Id [int],
    @Description [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[Makes]
    SET [Description] = @Description
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Make_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[Makes]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Purchase_Insert]
    @VehicleId [int],
    @Phone [nvarchar](max),
    @Email [nvarchar](max),
    @Street1 [nvarchar](max),
    @Street2 [nvarchar](max),
    @City [nvarchar](max),
    @State [nvarchar](max),
    @ZipCode [nvarchar](max),
    @SalePrice [float],
    @PurchaseDate [datetime],
    @SalesPersonId [int],
    @PurchaseType [int]
AS
BEGIN
    INSERT [dbo].[Purchases]([VehicleId], [Phone], [Email], [Street1], [Street2], [City], [State], [ZipCode], [SalePrice], [PurchaseDate], [SalesPersonId], [PurchaseType])
    VALUES (@VehicleId, @Phone, @Email, @Street1, @Street2, @City, @State, @ZipCode, @SalePrice, @PurchaseDate, @SalesPersonId, @PurchaseType)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[Purchases]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[Purchases] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[Purchase_Update]
    @Id [int],
    @VehicleId [int],
    @Phone [nvarchar](max),
    @Email [nvarchar](max),
    @Street1 [nvarchar](max),
    @Street2 [nvarchar](max),
    @City [nvarchar](max),
    @State [nvarchar](max),
    @ZipCode [nvarchar](max),
    @SalePrice [float],
    @PurchaseDate [datetime],
    @SalesPersonId [int],
    @PurchaseType [int]
AS
BEGIN
    UPDATE [dbo].[Purchases]
    SET [VehicleId] = @VehicleId, [Phone] = @Phone, [Email] = @Email, [Street1] = @Street1, [Street2] = @Street2, [City] = @City, [State] = @State, [ZipCode] = @ZipCode, [SalePrice] = @SalePrice, [PurchaseDate] = @PurchaseDate, [SalesPersonId] = @SalesPersonId, [PurchaseType] = @PurchaseType
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Purchase_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[Purchases]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Special_Insert]
    @Description [nvarchar](max),
    @Title [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[Specials]([Description], [Title])
    VALUES (@Description, @Title)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[Specials]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[Specials] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[Special_Update]
    @Id [int],
    @Description [nvarchar](max),
    @Title [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[Specials]
    SET [Description] = @Description, [Title] = @Title
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Special_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[Specials]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Transmission_Insert]
    @Description [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[Transmissions]([Description])
    VALUES (@Description)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[Transmissions]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[Transmissions] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[Transmission_Update]
    @Id [int],
    @Description [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[Transmissions]
    SET [Description] = @Description
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Transmission_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[Transmissions]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[VehicleModel_Insert]
    @MakeId [int],
    @Description [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[VehicleModels]([MakeId], [Description])
    VALUES (@MakeId, @Description)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[VehicleModels]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[VehicleModels] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[VehicleModel_Update]
    @Id [int],
    @MakeId [int],
    @Description [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[VehicleModels]
    SET [MakeId] = @MakeId, [Description] = @Description
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[VehicleModel_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[VehicleModels]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Vehicle_Insert]
    @ModelYear [int],
    @SalePrice [float],
    @Featured [bit],
    @Sold [bit],
    @Vin [nvarchar](max),
    @Make [int],
    @Model [int],
    @Type [int],
    @BodyStyle [int],
    @Transmission [int],
    @Color [int],
    @Interior [int],
    @Mileage [float],
    @MSRP [float],
    @Description [nvarchar](max),
    @PictureUrl [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[Vehicles]([ModelYear], [SalePrice], [Featured], [Sold], [Vin], [Make], [Model], [Type], [BodyStyle], [Transmission], [Color], [Interior], [Mileage], [MSRP], [Description], [PictureUrl])
    VALUES (@ModelYear, @SalePrice, @Featured, @Sold, @Vin, @Make, @Model, @Type, @BodyStyle, @Transmission, @Color, @Interior, @Mileage, @MSRP, @Description, @PictureUrl)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[Vehicles]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[Vehicles] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[Vehicle_Update]
    @Id [int],
    @ModelYear [int],
    @SalePrice [float],
    @Featured [bit],
    @Sold [bit],
    @Vin [nvarchar](max),
    @Make [int],
    @Model [int],
    @Type [int],
    @BodyStyle [int],
    @Transmission [int],
    @Color [int],
    @Interior [int],
    @Mileage [float],
    @MSRP [float],
    @Description [nvarchar](max),
    @PictureUrl [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[Vehicles]
    SET [ModelYear] = @ModelYear, [SalePrice] = @SalePrice, [Featured] = @Featured, [Sold] = @Sold, [Vin] = @Vin, [Make] = @Make, [Model] = @Model, [Type] = @Type, [BodyStyle] = @BodyStyle, [Transmission] = @Transmission, [Color] = @Color, [Interior] = @Interior, [Mileage] = @Mileage, [MSRP] = @MSRP, [Description] = @Description, [PictureUrl] = @PictureUrl
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[Vehicle_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[Vehicles]
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[VehicleType_Insert]
    @Description [nvarchar](max)
AS
BEGIN
    INSERT [dbo].[VehicleTypes]([Description])
    VALUES (@Description)
    
    DECLARE @Id int
    SELECT @Id = [Id]
    FROM [dbo].[VehicleTypes]
    WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
    
    SELECT t0.[Id]
    FROM [dbo].[VehicleTypes] AS t0
    WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id
END
GO

CREATE PROCEDURE [dbo].[VehicleType_Update]
    @Id [int],
    @Description [nvarchar](max)
AS
BEGIN
    UPDATE [dbo].[VehicleTypes]
    SET [Description] = @Description
    WHERE ([Id] = @Id)
END
GO

CREATE PROCEDURE [dbo].[VehicleType_Delete]
    @Id [int]
AS
BEGIN
    DELETE [dbo].[VehicleTypes]
    WHERE ([Id] = @Id)
END
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201805180135055_addBusinessEntities', N'CarDealerShip.Repository.Migrations.Configuration',  0x1F8B0800000000000400ED3D6D6FDC3C72DF0BF43F08FBA93DE4BCB1D3E7C1D3607D073F767C675CEC185E3BE8F54B404BF45A8856DA93B4898DA2BFAC1FFA93FA174A8A94C457899228ADD62B0408BCA4381CCE0C67384372F87FFFF3BF8B3FBFAC03E7078C133F0A4F67C747EF670E0CDDC8F3C3D5E96C9B3EFDF1B7D99FFFF4CFFFB4F8E4AD5F9CAFF9771FF077A865989CCE9ED374F3713E4FDC67B806C9D1DA77E328899ED223375ACF8117CD4FDEBFFFF7F9F1F11C22103304CB711677DB30F5D730FB817E9E47A10B37E91604D79107838496A39A6506D5B9016B986C800B4F67E720BE802080F1F2D9DF1CDDC14D94F86914BF1E5D7910014D5F67CE59E00384D812064F33078461948214A1FDF12181CB348EC2D572830A4070FFBA81E8BB271024900EE763F9B9E9C8DE9FE091CDCB863928779BA4D1BA21C0E30F945473B1792B82CF0A5222627ECAE883479D11F474F67BE4BD2ED3D7008D5EECEDE37910E32F4582670C3A4AC1630093A3A2FD3B47F1D5BB425E9058E17FE8AB6D906E63781AC26D1A03F4C5EDF631F0DDBFC1D7FBE83B0C4FC36D10B02823A4511D57808A6EE36803E3F4F50E3ED1815C793367CEB79B8B0D8B664C1B32C2AB30FD7032736E50E7785C854430D4582211837F81218C410ABD5B90A6300E318C5CE6E6957D5DC0C48DFD0D6123E91449229A6333E71ABC7C86E12A7D3E9DA13F67CEA5FF02BDBC8422F210FA684AA24669BC857C5F8B79C9D54A5E9F474114B7E473D676E2F11EF0384C819B5E46F1BA35A70B0813BFABF98DFFB7CC68B9934F6BE007BDF772FB1C85FD8FE51A260958D9EEC77872208980B1DF5A07E6CDA769317A35780DBEB75DD1E0A6138747CFE1DB6DEC3E83A42D97F3E613A7AB39FD153EFB6E00EBBB1C837919C65422C010A6C703F573D27B3FE79918F43E18247EBDF7F29FFEE61C7DDCFF6890BEB88D7DB7E8E92242EA00369F16540B5D30C4C17FDFFBEBE6C03052C92D525C51D879BA52BC308C829830783A622B921AB0C6AAFC2E6A1D7EC04D2715BE0B2FE506FCF057197E42770F0922FCCCB98341569B209650E1C1CCFA46AB2FE3688D7F13EE93D26FCB088917C63592AAEE41BC82694B01C3203A0859DE7CD78286F190854DF92946B78D5CE65D74511E79DFE630CC1D382AF275CCBC2E02A267C9E606A64564F88880BC8C11B89F51FCFD8885F8CE316E5772FDC494EB1F8E1F9F3EFCF6CBAFC0FBF0EBBFC10FBF0CAF6A1493FFF8E437A3C9DF50046A54CEC92FBF5AE9B5850E62F92DEB22B956D2498A4F3AE9A61C9E898E6A2ED6A5EA1ABB680FAEDC869B0DBC42ECAB5F63895B6EA0EB83A0A531A4AD776D0BC7BEE8EA2F4222F775EFA7C1CE62AAF7310893B59F24D9485B89140B6292ABD147DEB01AEDB0929E385CCDE14B3F4ED24176963E83813A1A262E97F5721E854F7EBC8605C37E8F90F50561F310084812B41CF2FE0A92E7FEE349D0DDC648369629586F86D9EBBBD9AE1FF13C1EAE2F6BACB9FF195D0217CDB24F216ED519DEE7C8FD1E6DD34FA187636F0FA92B87E20C015841E7CC7561925C226186DE79B40DD36EEE38D6B9038780CE03E0AFD5FE17C6E65B5E5F3A5E4CB1E471B1752A57AB0A93CFD1CA0F2B30C9EB054C48B11A135AD714130CA102115A2DE09195AAD120559DC362195D3B58F3ACFD64D2EBA760D7A85A46682E1EDFDB7E10EEE92B08B63BF32930BDB269D64130B3F6BB16CC06410D54F2C3F7608CE0EE266CCB2130748824E3568EC1CE8E07314133FB61B8F187E0F625BA5CE74E98869727776272272677C2BE3BD1FBF64E857FC16A5C859FA1A8D6EEF0F4E47770E065FF43515D8DA1757F84832EF925726D357A16FC14165EADBFD2CE385337E66D5BE8A11D9DE1560487E41CB1625BEB24B59B0DD4771AFB6C109C866E4E5603FFAD7ECE99BA333D4D879DBA72C3E800E3E9420F30679E7FCB70020B62D71185B15B007C7BA26B2462047B9C94E5DD046692951A59C1F4F83B04713771B17518FB1202CC86CE0ED7320A3AC3F8EAF77F6C84DC91EA4279AA54BB80904E98D3B96372C05C86C6DC66EF841477A6A553D49E5CB9EE02A2BCB4D88955C8FD676E5EB69C22D7CBBBDB8E20863C1875EBBB78463FC4B60F1F34B52344CABBD812FCDD644FC6B76ED8AE196E0BB763AE92CB00ACCAF422CDF88F6127FC851BAB0280C68B5C84E015D18765104FE16B8843ADB97605E1F74B3F042136B5990F7C3A7B2F31856B729E85BBE9B7C7D5DF9281891D9CC89C2034AFE0036F436CB08185B8632EDCC09FA6D447AE98A7A3BE9A90674912B97E4616264E480FCAF33D7D0A3D477F83A734E8E450FB352286BF41C347B308E3226A9B2FE1050C600A9D339724CA4192E3024F56F1086DCF00913CE0C820529EB0E791F983D407527930C63A07E00DA00471CF0F53593FFAA1EB6F40A0A582D0C250A7E23116B0C59A0BB881215687DA119B74AA3E408F3B2EE00B44AFA3C862CE484EB540296E60E8F859751DA3E42B7F29681041ABB804A240AC67C1D353690001D45362F482C86E11E918ADDC27E255CA4022A7DA8D1230A17B23BD0899821003489762D026BD6A8FDD0C2656745FAF9299E2E6DEEEC44AD8421430A19B0CFD89154F88A1C48A1FF47E8815D98DADE4A5B025BB3BA1E2377E875B87C954184AA2B8118F5EA0542725EAD63B35E6903F4037E84AACC63C2A8E10F4BA16DB8DB9AC20C67E89638DF9AC3C23331E71D49B55C51E7EFFE238B899AD20C67E8963B5D9AD3A11351E61D49AE381BDD49D98673D2546268824CC9CA560F5C3228E97A38FCBE14BAA08612214691433A1F16B512870FB254CC58DB264E694A16D2A11CC2EDABC1A4CB6BDA50241F7BD6A9B17A966D540985CB635A0F25D32159C7207AD0608DE115501203BA5358DF348BD0A4099ACB006083D6E29012013B3A6713E835500CAD96D82C1B18A8A5C98AD8E1D825251B245523C354069EA0915AC22A7450D087667570587DFF935A0B78ED6468DF3F3C94A0874996A00263F44AC044397172643A9E2BAD198A455761DDBCDC628AD96EAC09A8D993DD6A582C89F1C33035601C71404DDB5D281215BC90228C69AF033394F71C47C20276313CD5AE5CE4E8175A1AC24B358B921C3B4679483B8AAE107643058555E2779D0757B0FA6BB0F2211A49D4DD3DD020690426576A60A770B422687D6F5AF8D810B5CAC9602956F2E00C871B433E25C496846ACF22E6BC3B3CD472CB87F02801C473B23A602A319B0C27FA90B1C361F2EEF60F43CCD6B04BB36B6651CDD12E96036D36B245E6527ED92463F036AE32CC691960EA4D14F0D95ADB74B1AED54A973F94D9DFE0E74D1CEA12EC6213FBC54789545DD624E1E57A2058BB9E615A6C535D86CFC70C5BCCA444B9C257D92E98FCBE68F13AD098CB9CB115AF4818B9ED228062B28D46227D28359CEA40B9082C7CCC93AF7D6D267A20FAD598BE5BD496EB2CCC17C7D9637C17FE7A79E6A1EA8625C6C390041E15DA2D1AE7108233B15C7C842455B073F970502102B4EE121977CBB0EF5E1147D6BEE5C1D0B86AB90E12DE6C250A4F88944C401A91C79FE93EF66F3E5721B6661363512D9E757219A7969FEA193FF91C731041124D3AAECFF1B69AE629811D16F01BE6A95929BB7425DF122DBF936C631273567B3B05DB20DD2DFFDD02B05DC5830E63C01549F3C6C3C90C2D62422CD9B9008232B50061719136408BA2FE63C59549F90506F6BC291E63609F725F691E595C329F990788455F3DE7872D5E980BCBE54CD468A9B0626EDAA1312D46CAEB035ED26656D46DD011475D6F7A4A4ABC93329E816449B94B34A3933DB3EB69548B965D4465157B4EE475DE3FFF9F6A4C41C02CD86C482A045E630E8F34C2C0C5A640EA378DB8F8552148ED2E054CACA2066A7C0A085F1218222A80A52D84DC352F11120D3D26EA0A95409A0696937D085A809C08BF27DB7C1A5AC8CC4124F02D88700F6B8202925685A96C8CB92F208895D3B531C3F69BE20D1379D9C47631A0F60C8F3EE2717B2964223B15DFBE24516749B34B6ACB1C9793DBB9A243BEBD75C53AB9B4D5ADA88B6036868DCF5A49D2BA93369E6E6349BB4B2AC95CB83D076B5477188BAB976D637ED474333AFA6B34098E2616373366284C5B3E72C94A2B0299C13159C932670C8B3E52C1052D20493ECD96D1E8FACC81C46F1E2380BA5286C804B99C48EC3A72C6E2031DCABE29CE07035CDB0639E16173164AA9A63490E34ABB0541D75CEE0ED7A1D53A5890658CBE4DDB758CF301A4830424CCD68236C3DC6050B4526002FCA6D803FD1803FE90A9E683E013629EC8A77A62924ACB3D26EA00B2529002FCA3B625E6A4E11FBB2A6A3A473DA541478AEB2FB58181DAB180F536B674C44F76AC6442AF7DBE52994E848DC9E49334F9A79D2CC9366AE1D9335CDDC5B64A450AD5374448E8EE82E9674F147B2DBD3CDA322EA66FD4444F0FF66E79CBA7A772DF952DEACB1CB9BE2767B73FEE89BEAA89C67AA60E9ACCB5EA18792676564A1E83235EE8C5FF4DEADE56D6436C7418BEDFACAE6073AB1E4AB6BFDF0ACC344AB07314DB832FB865DF6E5993B9A734DDB725CBBAE3A78F77E1A083397168D30E259C1A501029EB4F751ECDF56F152E88096EE779C24A7FD48C224FBC3D0DEDCAB9C239377251B293EBF935D1DC8E5866A6EAEAA9B8FCB66EDDCDED4D17A00A3C3A2300ACB334AF3C051E96DDA88DE143947BB499BAB63327DC4635AC66286D2DA99ACC87E3D536C0EEB3350812A4B873D439435388FC2273F5E434F018CA96B70920424C9CF28F6FE9A3D36C59D24E16A1A9C7781EE36C6AC4FC17A239C77E1AB1A9EE3BAD9E2E79914A7B9F28A56F03414557FD1C043FD195D02174D844F217EB14D802ED73690CAC8FD1E6DD34FA18737611E5257104FB9BA056C05CE629D39D433D78549728944147AE7D116DB0A16B0A2DA1C36D62DF21C2D4B47130262F295D957CA2417683BCDAC69DB8F7AB613F3639EACE7CE3096C50D61D147E92560B47C5442A4CD3BD7558848E6D77642A469DBAF18DCB24FB573CABBEAA97A3D3CE1E5795EF97155A31288DE76725A2EF7AA9BF7A357A605D6B4C09A165807BDC0522486ED4F2DB65D7019C098165E235C782952EBF6275C6D17620630FA58FA0CB53C6B26C23B1214FE6104BB32C23DAAD05C3CAA9BF7A376F0454F11425E76005B31751C1B602B8645A1C5564CCE2C312F0F2D1ED566C358F77938168C649F679FF8DADB2612C7986913496BCD7A3264ED6DD860E60B4BC6DF211096444CF16E6E295F42906E63D1812C4B1B601505E2A5E4ACA4C17D7D5F30CA5FE5F7A32A699C3D10272E101A7349C1A146E104C9A969EACF302FFFB160B40F025662C33DA5C66155F1C85A1544FAA820E768A9DE19AC8251BE05C8CD28CD0B81951CF30328E73BCD0B1BC059DEDD0A40B292DD9D4CBDF55D3C071F624120D9F2F12E5477BB466DB33C2D35B1B892296B467FE5AE54DC420F6545C731643A5D443F2BEC78F3D69757785959F7D5A9726DDA1930B10B2A59E97CEC5575B7B0E16DEF3AC32240676A3AE2CE5915710C5C65C72BBDC4E688777A496937D0A51D12D7E4454547D9C9ED93283D797947F099E512616785A3F2C64C2C9F78C396A97A13AEFC68BCF8C9FC198D61327F93F9ABC27D327F06B23399BFAA6EAC9ABFBE239E53B0531FEC246F88F7E25E67EAB075D053DDBA9FC0E7BEEFB8E9283D5C300363305D7D3221D248D6D27BB6699591EE70D5B8F430B3F849A1896849F1BB7898993E8ACCBDD69C910D93392357421F6856730211921E6441CEC46B92C2F511FEE068F98FE03CF033C1C83FB806A1FF0493F43EFA0E11914FDE1F9FCC9CB3C00709793F9BBEFFFCD1DD2669B4066118A5F4756D8307A18F3FE007A1A1B79E8BCD9B3F2B8DA12489C71D566034B2B424E719F637F82AF23817BF3BF8E4E874CD622E365C28A416F77F3AF331593303F91788B88E2698770B5224CB6179FE69E6DC6C83009FA23C9D3D812091B61444F0DCF426FD843F004EC415FFCB1ABCFC2B0B308DC58369AC1C57924DF14AE744B23A9269DE99DB5BC2E1FF5B504C0644CFB75B8044B3585A80543CD7D59F44A85F2BDA5B7118681EC9AF874C14ABA6983A4FF9DE528D4984CBF4D210883D45614F7915A96CADC13AB1028BE4A9B58254966BD502A42207AD0DACCAE03F81F61444A0854471F9640924EC35A53EB6920D810929633BC8399711D6148EB16A91D3E4EDAD5A69B99A3126953AABA019B9747703149FAA1306D65337EF82A1B0E8837DBC0A3DF8723AFBAFACC947E7EA3FBE9156EF9C2F31720D3F3AEF9DFF6E4CF71CE1661D93560D3A365F9569B3770E21DAB9E4CD9C6BF0F21986ABF4F974767CF29B1571AEA72C1E34FE2B2B7EE75C250FA1FF8F2DAAB847828F69CC6075F2CBAFB669BE5773C49CAA9A89D291C3FCC469848D6AF634C2C698B3CA8C917B6B23BA2DD865783493607F46479F40ED4079D0C85CBF118A3119A32CC86C99346A54CE9398D680807CF45B2C99B96406361C0C3E9581AD30579ECAC02E3C2B24947316B487A54852A077AE8C0458484ED01E35453682F69E5A9987A05FA5A6B8ABBFB79A6D674E0B9326C0468085C913D02FF31577E9ADAFAE6FF577E247EC8672585BF6C584BC033DEE2868F315ED95EFAA5C1554F99ED302615A201CEC02A15E43E62D7718D579BBAB8E5D8781F671295293DEC74C326AB2F9345B993458F4D4CB5FA5BDEFCCF03E572ABB146D63E9D1A7A2D95B9592272B696F1D060A8B296F57EF2FD9CBAB65ED296F69FFB8BC21D67EBD412E82B56F9F5DF8B271782ABBE0D59EA4F41A577B00CDB6BBE5F6CC7DAC0E4870D7ADDAC3A197AADA0328EF4D7560497E37AA8B8C934B505D20D8DE81612F34F5AE3533A97C1B9AB31F7373962491EB672B0C6693F39BE2011044632FDBADA66750280EF8043A7907D7B9DE06A9BF097C17F583961FD235A82F21B900E09CB9E47CFA39485CE0C92347B87ABABE8B0D6BB6FFB290C7E10F1268C46288EF5DF8004726923406BE7CCF08D996D0F5372060C72B7C64283678340538B1E6026E6088E5411C9B495FBA772AF1350B0A56A06ADDD81773461AAA85843DB251232CDCE90E96697CC520C2239D7A50E1D3B330D53C756B5DA80C9E691D9970614CBFA9B2300B6A40520103AA20125D1111A0A5BDC88D26A17E2F4A4897A1BAC12EC56082A2CAA83C224121C11611015ABAF782A2CB363D464151BC813D2239197A4D33A494189B9D9D0A096B28EBCC0FB7EDA75B44EC6051239B25456DAFCB9AA1E4CAE44185310B588DD91AAB80C9E64C51FBE6046C4FCC1C2760D5E66EACF2B56BAF6C17D23546F358E49510A2B3795612E76CB58AE10AA465F8EAF7AD1FA45761F1FBC60F80E7BB39A4A2FC2A398FD69B28E1625F455A09CCFA255C0384B39B9CCECE8220FA79B526EC4643F841724DCC1C9246E174E63D46829017A08C036738F88D63B662C84C91A9424F189A89648F0823042CD554D81D41697E92B74650232A641B10D35C5311659A67168979D873AC480FB28733ADE2E0BAB18055DD0531065275AFDF184875EE0F4B4C3E1CCD31094763E138644D989F56D84335D8AB8D2CE872389A63187A1EF264C327B5A689A6A0C934C9ECD1F29027589E80670F27993AD1D6B0AB2D2BEBBEEAC45A0DC1E8726A1983A948A7D500157D262D6320D549B4CC71D19C7F361794CACC598DF050E7CC6A8C89747CD88602381C8B32298E49714C8AC39AE238E4E513CD1FB587ABA7B6CB6A05A8AA345116687B3886697F7872C8739EBD37754013BF396DA6896B9FA6873CF1D88BD57B38F11497A8C721601C5D0F67D2EE073FA609BF8FB149F5CDFDE15C4FE56D7DF3EEC57BFAE6A115ED0DFD46D3B2E58496AEE59B2F97CD1C63454BF5557CF38E7597F0CDC32ED2F57BE3A6CA8BF7E6E4565EB9376F2E5FB6DF85A3547BC3DE82FE3A209B3AE9BD49EF4D7A6FD27BECDBC76F4DEF35A10106B687EBD721FC9B8C3487631A0723E941CD3AE16DDAC23608EFC84A57FBE873B7B2312B33FFD03B754C1D3B22E79E50A7A84E2409107BA1164BEA8196ABA067552690CBC73B55F0995A752FC507F57D95C653EAA8AC52F592D7D677419642127852AC028D6BEAC1160F0DCAA0CB2A15F8BCB6BE0B72E952024F8A55A0C9C5D33AB0E57D4E097459A5029FD71AB0954B3024B396AB567575966C6E60DAACB38A71C99FE83B351F65FEDE8FDC5F51A3EA8656D6C3E797B552277CB5AA27F60B33B9D0C8845E1ECCC0D2F4074AD8B44ED7014D0761D20BBD03AFEC85D6E97AA139019A885A8D98D58958B3CE7404547C53DDAD213915A9052AFBAE206FD9B72191B994B772B77CB5AA47F60BE3EEF43D5576620C9F38C7BA3E486D453FF803B92FE60A396F3668663887F980B11EAABC718E9C66B018495E20DD7E5725D2615A958502DE731E71834129D2DE290657971CCF51253F90D0E62B2A06ADB33C1C148B4460F3E32846AF4D9F23714AE2522D6F39055434A3A5760696AB07CDC054695B2C0C8CD36E45335A6A67607435A11997225B8885610D31176BC4B136AB93762E69E791F16C94C555516B97107AF1ADCD3ED4232164F156D4DA258456DCEB92E4F448069BDA394FE85BC4098ABAC59C58705A807EA6510C56742592952EE677DB109FD925BF2E60E2AF4A100B0433847C5CA2F8E62A7C8AF2CC340246F927620A6A98020FA4E02C4EFD27E493A36AFC468B1FAE664EF6EE053E3AFE08BDABF0CB36DD6C533464B87E0CB8072370869BAAFE177309E7C5972C3095D8180242D3C741BD2F218E377905DE97248E34370081E337341B34E6658AB342AF5E0B4837D9017C1340947C45C69F7BB8DE040858F2255C821FB00D6E48FC3EC315705FCB17347440EA19C1937D71E183550CD6098551B6473F910C7BEB973FFD3F7EE3E54C0C6D0100 , N'6.1.0-30225')

