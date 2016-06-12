namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<App> Apps { get; set; }
        public virtual DbSet<AppPackage> AppPackages { get; set; }
        public virtual DbSet<AppVisible> AppVisibles { get; set; }
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<AssignmentType> AssignmentTypes { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupRelation> GroupRelations { get; set; }
        public virtual DbSet<GroupSubscription> GroupSubscriptions { get; set; }
        public virtual DbSet<GroupType> GroupTypes { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAssignment> UserAssignments { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserRelation> UserRelations { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }
        public virtual DbSet<VerbTenseType> VerbTenseTypes { get; set; }
        public virtual DbSet<Vocabulary> Vocabularies { get; set; }
        public virtual DbSet<VocabularyAssignment> VocabularyAssignments { get; set; }
        public virtual DbSet<WordArray> WordArrays { get; set; }
        public virtual DbSet<UserAssignmentView> UserAssignmentViews { get; set; }
        public virtual DbSet<GroupView> GroupViews { get; set; }
        public virtual DbSet<UserRoleGroupView> UserRoleGroupViews { get; set; }
        public virtual DbSet<UserRoleView> UserRoleViews { get; set; }
        public virtual DbSet<UserGroupView> UserGroupViews { get; set; }
        public virtual DbSet<UserRoleLookupView> UserRoleLookupViews { get; set; }
        public virtual DbSet<UserView> UserViews { get; set; }
        public virtual DbSet<VocabularyWordArray> VocabularyWordArrays { get; set; }
        public virtual DbSet<TeacherStudentView> TeacherStudentViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<App>()
                .HasMany(e => e.AppPackages)
                .WithRequired(e => e.App)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<App>()
                .HasMany(e => e.AppVisibles)
                .WithRequired(e => e.App)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Assignment>()
                .HasMany(e => e.Assignment1)
                .WithOptional(e => e.Assignment2)
                .HasForeignKey(e => e.AssignmentParentId);

            modelBuilder.Entity<Assignment>()
                .HasMany(e => e.UserAssignments)
                .WithRequired(e => e.Assignment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserAssignment>()
                .HasMany(e => e.VocabularyAssignments)
                .WithRequired(e => e.UserAssignment)
                .HasForeignKey(e => e.UserAssignmentId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vocabulary>()
                .HasMany(e => e.VocabularyAssignments)
                .WithRequired(e => e.Vocabulary)
                .HasForeignKey(e => e.VocabularyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vocabulary>()
                .HasMany(e => e.VocabularyWordArrays)
                .WithRequired(e => e.Vocabulary)
                .HasForeignKey(e => e.VocabularyId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WordArray>()
                .HasMany(e => e.VocabularyWordArrays)
                .WithRequired(e => e.WordArray)
                .HasForeignKey(e => e.WordArrayId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AssignmentType>()
                .HasMany(e => e.Assignments)
                .WithRequired(e => e.AssignmentType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.AppVisibles)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupRelations)
                .WithRequired(e => e.Group)
                .HasForeignKey(e => e.ChildGroupId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupRelations1)
                .WithRequired(e => e.Group1)
                .HasForeignKey(e => e.ParentGroupId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.GroupSubscriptions)
                .WithRequired(e => e.Group)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupSubscription>()
                .Property(e => e.LastPayment)
                .HasPrecision(8, 2);

            modelBuilder.Entity<GroupType>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.GroupType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscription>()
                .HasMany(e => e.AppPackages)
                .WithRequired(e => e.Subscription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscription>()
                .HasMany(e => e.GroupSubscriptions)
                .WithRequired(e => e.Subscription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Subscription>()
                .HasMany(e => e.UserSubscriptions)
                .WithRequired(e => e.Subscription)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAssignments)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.AssignedUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Groups)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.OwnerUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserAssignments1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.AssigningUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserGroups)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRelations)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.ChildUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRelations1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.ParentUserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserSubscriptions)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Vocabularies)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserSubscription>()
                .Property(e => e.LastPayment)
                .HasPrecision(8, 2);
        }
    }
}
