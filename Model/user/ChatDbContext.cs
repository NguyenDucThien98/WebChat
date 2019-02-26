namespace Model.user {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ChatDbContext : DbContext {
        public ChatDbContext()
            : base("name=WebChatDbContext") {
        }

        public virtual DbSet<app_role> app_role {
            get; set;
        }
        public virtual DbSet<app_user> app_user {
            get; set;
        }
        public virtual DbSet<customer> customers {
            get; set;
        }
        public virtual DbSet<message> messages {
            get; set;
        }
        public virtual DbSet<notify> notifies {
            get; set;
        }
        public virtual DbSet<relationship> relationships {
            get; set;
        }
        public virtual DbSet<sysdiagram> sysdiagrams {
            get; set;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<app_role>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<app_user>()
                .Property(e => e.app_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<app_user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<app_user>()
                .Property(e => e.encrypted_password)
                .IsUnicode(false);

            modelBuilder.Entity<app_user>()
                .HasOptional(e => e.customer)
                .WithRequired(e => e.app_user);

            modelBuilder.Entity<app_user>()
                .HasMany(e => e.app_role)
                .WithMany(e => e.app_user)
                .Map(m => m.ToTable("user_role").MapLeftKey("app_user_id").MapRightKey("role_id"));

            modelBuilder.Entity<customer>()
                .Property(e => e.app_user_id)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.messages)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.cus_receive_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.messages1)
                .WithRequired(e => e.customer1)
                .HasForeignKey(e => e.cus_send_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.notifies)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.cus_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.relationships)
                .WithRequired(e => e.customer)
                .HasForeignKey(e => e.cus1_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.relationships1)
                .WithRequired(e => e.customer1)
                .HasForeignKey(e => e.cus2_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<message>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.cus_send_id)
                .IsUnicode(false);

            modelBuilder.Entity<message>()
                .Property(e => e.cus_receive_id)
                .IsUnicode(false);

            modelBuilder.Entity<notify>()
                .Property(e => e.notify_id)
                .IsUnicode(false);

            modelBuilder.Entity<notify>()
                .Property(e => e.cus_id)
                .IsUnicode(false);

            modelBuilder.Entity<relationship>()
                .Property(e => e.relationship_id)
                .IsUnicode(false);

            modelBuilder.Entity<relationship>()
                .Property(e => e.cus1_id)
                .IsUnicode(false);

            modelBuilder.Entity<relationship>()
                .Property(e => e.cus2_id)
                .IsUnicode(false);
        }
    }
}
