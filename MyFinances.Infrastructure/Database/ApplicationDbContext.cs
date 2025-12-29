using Microsoft.EntityFrameworkCore;

namespace MyFinances.Infrastructure.Database;

public class ApplicationDbContext : DbContext
{
	public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
		: base(options) { }
}