using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BlogAppV1.DataAccess.EFConfig
{
    public partial class BlogAppDBContext : DbContext
    {
        public BlogAppDBContext()
        {
        }

        public BlogAppDBContext(DbContextOptions<BlogAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<BlogsSections> BlogsSections { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<FriendRequests> FriendRequests { get; set; }
        public virtual DbSet<Friends> Friends { get; set; }
        public virtual DbSet<Media> Media { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<ReactTypes> ReactTypes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesPermissions> RolesPermissions { get; set; }
        public virtual DbSet<Salts> Salts { get; set; }
        public virtual DbSet<Sections> Sections { get; set; }
        public virtual DbSet<UserCommentReacts> UserCommentReacts { get; set; }
        public virtual DbSet<UserPostReacts> UserPostReacts { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersRoles> UsersRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=BTODERICA;Initial Catalog=BlogAppDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BlogsConfiguration());
            modelBuilder.ApplyConfiguration(new SectionsConfiguration());
            modelBuilder.ApplyConfiguration(new PostsConfiguration());
            modelBuilder.ApplyConfiguration(new CommentsConfiguration());

            modelBuilder.ApplyConfiguration(new MediaConfiguration());

            modelBuilder.ApplyConfiguration(new ReactTypesConfiguration());
            modelBuilder.ApplyConfiguration(new UserPostsReactsConfig());
            modelBuilder.ApplyConfiguration(new UserCommentReactsConfig());

            modelBuilder.ApplyConfiguration(new FriendsConfiguration());
            modelBuilder.ApplyConfiguration(new FriendRequestsConfiguration());

            modelBuilder.ApplyConfiguration(new PermissionsConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());

            modelBuilder.ApplyConfiguration(new BlogsSectionsConfiguration());

            modelBuilder.ApplyConfiguration(new RolesPermissionsConfiguration());
            modelBuilder.ApplyConfiguration(new UsersRolesConfiguration());

            modelBuilder.ApplyConfiguration(new SaltsConfiguration());

            OnModelCreatingPartial(modelBuilder);

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
