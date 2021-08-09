using BeeTex.Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BeeTex.Web.Data
{
	public class AppDbContext : IdentityDbContext<UserEntity>
	{
		public AppDbContext()
		{

		}
		public AppDbContext(DbContextOptions<AppDbContext> options)
			: base(options)
		{
		}

		private readonly IHttpContextAccessor _httpContextAccessor;
		public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor)
			: base(options)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public DbSet<AddressEntity> Addresses { get; set; }
		public DbSet<CompanyEntity> Companies { get; set; }
		public DbSet<FashionFeed> FashionFeeds { get; set; }
		public DbSet<TaskEntity> Tasks { get; set; }
		public DbSet<CollectionEntity> Collections { get; set; }
		public DbSet<InvoiceEntity> ClientInvoices { get; set; }

		public DbSet<SupplierInvoiceEntity> SupplierInvoices { get; set; }
		public DbSet<DeliveryEntity> Deliveries { get; set; }

		public DbSet<OrderEntity> Orders { get; set; }

		public DbSet<ProductEntity> Products { get; set; }
		public DbSet<SupplierEntity> Suppliers { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<FashionFeed>()
				 .HasKey(x => x.Id);

			modelBuilder.Entity<AddressEntity>()
				 .HasKey(x => x.Id);

			modelBuilder.Entity<CollectionEntity>()
				 .HasKey(x => x.Id);

			modelBuilder.Entity<CompanyEntity>()
				 .HasKey(x => x.Id);

			modelBuilder.Entity<DeliveryEntity>()
				 .HasKey(x => x.Id);

			modelBuilder.Entity<SupplierEntity>()
			 .HasKey(x => x.Id);

			modelBuilder.Entity<SupplierEntity>()
				.HasKey(x => x.Id);

			modelBuilder.Entity<DeliveryEntity>()
				.HasMany(x => x.Products);

			//orderEntity
			modelBuilder.Entity<OrderEntity>()
				 .HasKey(x => x.Id);
			modelBuilder.Entity<OrderEntity>()
				 .HasMany(x => x.Products);
			modelBuilder.Entity<OrderEntity>()
				.HasOne<UserEntity>(x => x.CreatedBy)
				.WithMany()
				.HasForeignKey(x => x.CreatedByUserId);

			modelBuilder.Entity<OrderEntity>()
				.HasOne<UserEntity>(x => x.ModifiedBy)
				.WithMany()
				.HasForeignKey(x => x.ModifiedByUserId);

			//productEntity

			modelBuilder.Entity<ProductEntity>()
				 .HasKey(x => x.Id);

			modelBuilder.Entity<ProductEntity>()
				.HasOne<UserEntity>(x => x.CreatedBy)
				.WithMany()
				.HasForeignKey(x => x.CreatedByUserId);

			modelBuilder.Entity<ProductEntity>()
				.HasOne<UserEntity>(x => x.ModifiedBy)
				.WithMany()
				.HasForeignKey(x => x.ModifiedByUserId);

			//invoice entity
			modelBuilder.Entity<InvoiceEntity>()
				.HasKey(x => x.Id);

			modelBuilder.Entity<InvoiceEntity>()
				.HasOne<UserEntity>(x => x.CreatedBy)
				.WithMany()
				.HasForeignKey(x => x.CreatedByUserId);

			modelBuilder.Entity<InvoiceEntity>()
				.HasOne<UserEntity>(x => x.ModifiedBy)
				.WithMany()
				.HasForeignKey(x => x.ModifiedByUserId);

			//taskEntity
			modelBuilder.Entity<TaskEntity>()
				.HasKey(x => x.Id);

			modelBuilder.Entity<TaskEntity>()
				.HasOne<UserEntity>(x => x.User)
				.WithMany()
				.HasForeignKey(x => x.UserEntityId);

			modelBuilder.Entity<TaskEntity>()
				.HasOne<UserEntity>(x => x.CreatedBy)
				.WithMany()
				.HasForeignKey(x => x.CreatedByUserId);

			modelBuilder.Entity<TaskEntity>()
				.HasOne<UserEntity>(x => x.ModifiedBy)
				.WithMany()
				.HasForeignKey(x => x.ModifiedByUserId);

			


			modelBuilder.Entity<UserEntity>()
				.HasMany<TaskEntity>()
				.WithOne();



		}

		public override int SaveChanges()
		{

			var entities = ChangeTracker
				.Entries()
				.Where(e => e.Entity is TrackableEntityBase && (
						e.State == EntityState.Added
						|| e.State == EntityState.Modified));

			foreach (var entity in entities)
			{

				if (entity.Entity is TrackableEntityBase trackableEntity)
				{
					
					switch (entity.State)
					{						
						case EntityState.Added:
							var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
							if (userId !=null)
							{
								trackableEntity.CreatedByUserId = userId;
							}								
							trackableEntity.CreatedAt = DateTime.UtcNow;
							break;
						case EntityState.Modified:
							var userIdModified = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
							if (userIdModified != null)
							{
								trackableEntity.ModifiedByUserId = userIdModified;
							}						
							trackableEntity.ModifiedAt = DateTime.UtcNow;
							break;
					}
				}
			}
			return base.SaveChanges();
		}
	}
}
