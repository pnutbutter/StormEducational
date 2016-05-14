namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppPackage",
                c => new
                    {
                        AppPackageId = c.Int(nullable: false, identity: true),
                        AppId = c.Int(nullable: false),
                        SubscriptionId = c.Int(nullable: false),
                        PackageName = c.String(nullable: false, maxLength: 50),
                        PackageDescription = c.String(nullable: false),
                        PackagePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PackageTypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AppPackageId)
                .ForeignKey("dbo.App", t => t.AppId)
                .ForeignKey("dbo.Subscription", t => t.SubscriptionId)
                .Index(t => t.AppId)
                .Index(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.App",
                c => new
                    {
                        AppId = c.Int(nullable: false, identity: true),
                        AppGUID = c.Guid(nullable: false),
                        AppKey = c.Guid(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AppId);
            
            CreateTable(
                "dbo.AppVisible",
                c => new
                    {
                        AppVisibleId = c.Int(nullable: false, identity: true),
                        AppId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        VisibilityTypeId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AppVisibleId)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .ForeignKey("dbo.App", t => t.AppId)
                .Index(t => t.AppId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        GroupId = c.Int(nullable: false, identity: true),
                        GroupTypeId = c.Int(nullable: false),
                        OwnerUserId = c.Int(nullable: false),
                        GroupName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GroupId)
                .ForeignKey("dbo.User", t => t.OwnerUserId)
                .ForeignKey("dbo.GroupType", t => t.GroupTypeId)
                .Index(t => t.GroupTypeId)
                .Index(t => t.OwnerUserId);
            
            CreateTable(
                "dbo.GroupRelation",
                c => new
                    {
                        GroupRelationId = c.Int(nullable: false, identity: true),
                        ChildGroupId = c.Int(nullable: false),
                        ParentGroupId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GroupRelationId)
                .ForeignKey("dbo.Group", t => t.ChildGroupId)
                .ForeignKey("dbo.Group", t => t.ParentGroupId)
                .Index(t => t.ChildGroupId)
                .Index(t => t.ParentGroupId);
            
            CreateTable(
                "dbo.GroupSubscription",
                c => new
                    {
                        GroupSubscriptionId = c.Int(nullable: false, identity: true),
                        SubscriptionId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        LastPayment = c.Decimal(precision: 8, scale: 2),
                        LastPaymentDate = c.DateTime(storeType: "date"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GroupSubscriptionId)
                .ForeignKey("dbo.Subscription", t => t.SubscriptionId)
                .ForeignKey("dbo.Group", t => t.GroupId)
                .Index(t => t.SubscriptionId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Subscription",
                c => new
                    {
                        SubscriptionId = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.SubscriptionId);
            
            CreateTable(
                "dbo.UserSubscription",
                c => new
                    {
                        UserSubscriptionId = c.Int(nullable: false, identity: true),
                        SubscriptionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        LastPayment = c.Decimal(precision: 8, scale: 2),
                        LastPaymentDate = c.DateTime(storeType: "date"),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserSubscriptionId)
                .ForeignKey("dbo.User", t => t.UserId)
                .ForeignKey("dbo.Subscription", t => t.SubscriptionId)
                .Index(t => t.SubscriptionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        AspNetUserId = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserAssignment",
                c => new
                    {
                        UserAssignmentId = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        AssignedUserId = c.Int(nullable: false),
                        AssigningUserId = c.Int(nullable: false),
                        DueDate = c.DateTime(storeType: "date"),
                        Grade = c.Int(nullable: false),
                        GradeDescription = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserAssignmentId)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .ForeignKey("dbo.User", t => t.AssignedUserId)
                .ForeignKey("dbo.User", t => t.AssigningUserId)
                .Index(t => t.AssignmentId)
                .Index(t => t.AssignedUserId)
                .Index(t => t.AssigningUserId);
            
            CreateTable(
                "dbo.Assignment",
                c => new
                    {
                        AssignmentId = c.Int(nullable: false, identity: true),
                        AssignmentTypeId = c.Int(nullable: false),
                        AssignmentParentId = c.Int(),
                        DueDate = c.DateTime(storeType: "date"),
                        AssignmentTitle = c.String(nullable: false, maxLength: 250),
                        AssignmentDescription = c.String(nullable: false),
                        AssignmentSpanishTitle = c.String(maxLength: 250),
                        AssignmentSpanishDescription = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AssignmentId)
                .ForeignKey("dbo.Assignment", t => t.AssignmentParentId)
                .ForeignKey("dbo.AssignmentType", t => t.AssignmentTypeId)
                .Index(t => t.AssignmentTypeId)
                .Index(t => t.AssignmentParentId);
            
            CreateTable(
                "dbo.AssignmentType",
                c => new
                    {
                        AssignmentTypeId = c.Int(nullable: false, identity: true),
                        AssignmentTypeTitle = c.String(nullable: false, maxLength: 250),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.AssignmentTypeId);
            
            CreateTable(
                "dbo.VocabularyAssignment",
                c => new
                    {
                        VocabularyAssignmentId = c.Int(nullable: false, identity: true),
                        AssignmentId = c.Int(nullable: false),
                        VocabularyId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VocabularyAssignmentId)
                .ForeignKey("dbo.Vocabulary", t => t.VocabularyId)
                .ForeignKey("dbo.Assignment", t => t.AssignmentId)
                .Index(t => t.AssignmentId)
                .Index(t => t.VocabularyId);
            
            CreateTable(
                "dbo.Vocabulary",
                c => new
                    {
                        VocabularyId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Word = c.String(nullable: false, maxLength: 250),
                        PartOfSpeech = c.String(maxLength: 250),
                        Etymology = c.String(maxLength: 250),
                        Connotation = c.String(maxLength: 250),
                        FriendlyDefinition = c.String(),
                        Adjective = c.String(maxLength: 250),
                        NounSingular = c.String(maxLength: 250),
                        NounPlural = c.String(maxLength: 250),
                        VerbTenseTypeId = c.Int(),
                        VerbTenseI = c.String(maxLength: 250),
                        VerbTenseWe = c.String(maxLength: 250),
                        VerbTenseYou = c.String(maxLength: 250),
                        VerbTenseYou2 = c.String(maxLength: 250),
                        VerbTenseHeSheIt = c.String(maxLength: 250),
                        VerbTenseThey = c.String(maxLength: 250),
                        Synonym = c.String(maxLength: 250),
                        Antonym = c.String(maxLength: 250),
                        Sentance = c.String(),
                        Analogy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                        Sketch = c.String(),
                    })
                .PrimaryKey(t => t.VocabularyId)
                .ForeignKey("dbo.VerbTenseType", t => t.VerbTenseTypeId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.VerbTenseTypeId);
            
            CreateTable(
                "dbo.VerbTenseType",
                c => new
                    {
                        VerbTenseTypeId = c.Int(nullable: false, identity: true),
                        VerbTenseTypeName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VerbTenseTypeId);
            
            CreateTable(
                "dbo.VocabularyWordArray",
                c => new
                    {
                        VocabularyWordArrayId = c.Int(nullable: false, identity: true),
                        WordArrayId = c.Int(nullable: false),
                        VocabularyId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VocabularyWordArrayId)
                .ForeignKey("dbo.WordArray", t => t.WordArrayId)
                .ForeignKey("dbo.Vocabulary", t => t.VocabularyId)
                .Index(t => t.WordArrayId)
                .Index(t => t.VocabularyId);
            
            CreateTable(
                "dbo.WordArray",
                c => new
                    {
                        WordArrayId = c.Int(nullable: false, identity: true),
                        WordArrayName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.WordArrayId);
            
            CreateTable(
                "dbo.UserGroup",
                c => new
                    {
                        UserGroupId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserGroupId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRelation",
                c => new
                    {
                        UserRelationId = c.Int(nullable: false, identity: true),
                        ChildUserId = c.Int(nullable: false),
                        ParentUserId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserRelationId)
                .ForeignKey("dbo.User", t => t.ChildUserId)
                .ForeignKey("dbo.User", t => t.ParentUserId)
                .Index(t => t.ChildUserId)
                .Index(t => t.ParentUserId);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserRoleId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UserRoleId)
                .ForeignKey("dbo.Role", t => t.RoleId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.GroupType",
                c => new
                    {
                        GroupTypeId = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GroupTypeId);
            
            CreateTable(
                "dbo.GroupView",
                c => new
                    {
                        GroupId = c.Int(nullable: false),
                        GroupTypeId = c.Int(nullable: false),
                        GroupName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        OwnerUserId = c.Int(),
                        GroupTypeName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.GroupId, t.GroupTypeId, t.GroupName, t.GroupTypeName });
            
            CreateTable(
                "dbo.UserAssignmentView",
                c => new
                    {
                        UserAssignmentId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        AssignmentId = c.Int(nullable: false),
                        AssignmentTypeId = c.Int(nullable: false),
                        AssignmentTitle = c.String(nullable: false, maxLength: 250),
                        AssignmentDescription = c.String(nullable: false, maxLength: 128),
                        AssignmentParentId = c.Int(),
                        DueDate = c.DateTime(storeType: "date"),
                        AssignmentSpanishTitle = c.String(maxLength: 250),
                        AssignmentSpanishDescription = c.String(),
                    })
                .PrimaryKey(t => new { t.UserAssignmentId, t.UserId, t.FirstName, t.LastName, t.AssignmentId, t.AssignmentTypeId, t.AssignmentTitle, t.AssignmentDescription });
            
            CreateTable(
                "dbo.UserGroupView",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserGroupId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        GroupTypeId = c.Int(nullable: false),
                        GroupName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.UserId, t.FirstName, t.LastName, t.UserGroupId, t.GroupId, t.GroupTypeId, t.GroupName });
            
            CreateTable(
                "dbo.UserRoleGroupView",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserRoleId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        GroupId = c.Int(nullable: false),
                        GroupTypeId = c.Int(nullable: false),
                        GroupName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.UserId, t.FirstName, t.LastName, t.UserRoleId, t.RoleId, t.RoleName, t.GroupId, t.GroupTypeId, t.GroupName });
            
            CreateTable(
                "dbo.UserRoleLookupView",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        AspNetUserId = c.String(maxLength: 128),
                        Email = c.String(maxLength: 256),
                        UserRoleId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        RoleName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoleView",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        UserRoleId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        RoleName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.UserId, t.FirstName, t.LastName, t.UserRoleId, t.RoleId, t.RoleName });
            
            CreateTable(
                "dbo.UserView",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        AspNetUserId = c.String(nullable: false, maxLength: 128),
                        IsActive = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false, storeType: "date"),
                        CreateBy = c.String(nullable: false, maxLength: 50),
                        ChangeDate = c.DateTime(nullable: false, storeType: "date"),
                        ChangeBy = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppVisible", "AppId", "dbo.App");
            DropForeignKey("dbo.Group", "GroupTypeId", "dbo.GroupType");
            DropForeignKey("dbo.GroupSubscription", "GroupId", "dbo.Group");
            DropForeignKey("dbo.UserSubscription", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.Vocabulary", "UserId", "dbo.User");
            DropForeignKey("dbo.UserSubscription", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserRelation", "ParentUserId", "dbo.User");
            DropForeignKey("dbo.UserRelation", "ChildUserId", "dbo.User");
            DropForeignKey("dbo.UserGroup", "UserId", "dbo.User");
            DropForeignKey("dbo.UserAssignment", "AssigningUserId", "dbo.User");
            DropForeignKey("dbo.UserAssignment", "AssignedUserId", "dbo.User");
            DropForeignKey("dbo.VocabularyAssignment", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.VocabularyWordArray", "VocabularyId", "dbo.Vocabulary");
            DropForeignKey("dbo.VocabularyWordArray", "WordArrayId", "dbo.WordArray");
            DropForeignKey("dbo.VocabularyAssignment", "VocabularyId", "dbo.Vocabulary");
            DropForeignKey("dbo.Vocabulary", "VerbTenseTypeId", "dbo.VerbTenseType");
            DropForeignKey("dbo.UserAssignment", "AssignmentId", "dbo.Assignment");
            DropForeignKey("dbo.Assignment", "AssignmentTypeId", "dbo.AssignmentType");
            DropForeignKey("dbo.Assignment", "AssignmentParentId", "dbo.Assignment");
            DropForeignKey("dbo.Group", "OwnerUserId", "dbo.User");
            DropForeignKey("dbo.GroupSubscription", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.AppPackage", "SubscriptionId", "dbo.Subscription");
            DropForeignKey("dbo.GroupRelation", "ParentGroupId", "dbo.Group");
            DropForeignKey("dbo.GroupRelation", "ChildGroupId", "dbo.Group");
            DropForeignKey("dbo.AppVisible", "GroupId", "dbo.Group");
            DropForeignKey("dbo.AppPackage", "AppId", "dbo.App");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.UserRelation", new[] { "ParentUserId" });
            DropIndex("dbo.UserRelation", new[] { "ChildUserId" });
            DropIndex("dbo.UserGroup", new[] { "UserId" });
            DropIndex("dbo.VocabularyWordArray", new[] { "VocabularyId" });
            DropIndex("dbo.VocabularyWordArray", new[] { "WordArrayId" });
            DropIndex("dbo.Vocabulary", new[] { "VerbTenseTypeId" });
            DropIndex("dbo.Vocabulary", new[] { "UserId" });
            DropIndex("dbo.VocabularyAssignment", new[] { "VocabularyId" });
            DropIndex("dbo.VocabularyAssignment", new[] { "AssignmentId" });
            DropIndex("dbo.Assignment", new[] { "AssignmentParentId" });
            DropIndex("dbo.Assignment", new[] { "AssignmentTypeId" });
            DropIndex("dbo.UserAssignment", new[] { "AssigningUserId" });
            DropIndex("dbo.UserAssignment", new[] { "AssignedUserId" });
            DropIndex("dbo.UserAssignment", new[] { "AssignmentId" });
            DropIndex("dbo.UserSubscription", new[] { "UserId" });
            DropIndex("dbo.UserSubscription", new[] { "SubscriptionId" });
            DropIndex("dbo.GroupSubscription", new[] { "GroupId" });
            DropIndex("dbo.GroupSubscription", new[] { "SubscriptionId" });
            DropIndex("dbo.GroupRelation", new[] { "ParentGroupId" });
            DropIndex("dbo.GroupRelation", new[] { "ChildGroupId" });
            DropIndex("dbo.Group", new[] { "OwnerUserId" });
            DropIndex("dbo.Group", new[] { "GroupTypeId" });
            DropIndex("dbo.AppVisible", new[] { "GroupId" });
            DropIndex("dbo.AppVisible", new[] { "AppId" });
            DropIndex("dbo.AppPackage", new[] { "SubscriptionId" });
            DropIndex("dbo.AppPackage", new[] { "AppId" });
            DropTable("dbo.UserView");
            DropTable("dbo.UserRoleView");
            DropTable("dbo.UserRoleLookupView");
            DropTable("dbo.UserRoleGroupView");
            DropTable("dbo.UserGroupView");
            DropTable("dbo.UserAssignmentView");
            DropTable("dbo.GroupView");
            DropTable("dbo.GroupType");
            DropTable("dbo.Role");
            DropTable("dbo.UserRole");
            DropTable("dbo.UserRelation");
            DropTable("dbo.UserGroup");
            DropTable("dbo.WordArray");
            DropTable("dbo.VocabularyWordArray");
            DropTable("dbo.VerbTenseType");
            DropTable("dbo.Vocabulary");
            DropTable("dbo.VocabularyAssignment");
            DropTable("dbo.AssignmentType");
            DropTable("dbo.Assignment");
            DropTable("dbo.UserAssignment");
            DropTable("dbo.User");
            DropTable("dbo.UserSubscription");
            DropTable("dbo.Subscription");
            DropTable("dbo.GroupSubscription");
            DropTable("dbo.GroupRelation");
            DropTable("dbo.Group");
            DropTable("dbo.AppVisible");
            DropTable("dbo.App");
            DropTable("dbo.AppPackage");
        }
    }
}
