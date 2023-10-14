using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace СертификацияСемян.Данные;

public class КонтекстБдПриложения : IdentityDbContext
{
    public КонтекстБдПриложения(DbContextOptions<КонтекстБдПриложения> options)
        : base(options)
    {
    }
}
