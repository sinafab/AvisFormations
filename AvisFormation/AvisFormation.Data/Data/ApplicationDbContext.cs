using System;
using Microsoft.EntityFrameworkCore;

namespace AvisFormation.Data.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
	}
}

