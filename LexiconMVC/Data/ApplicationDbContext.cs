using LexiconMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LexiconMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> 
    {


        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Country>().HasData(new Country { Id = -1, CountryName = "Sweden", Continent = "Europe" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = -2, CountryName = "Norway", Continent = "Europe" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = -3, CountryName = "USA", Continent = "North America" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = -4, CountryName = "Mexico", Continent = "South America" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = -5, CountryName = "Japan", Continent = "Asia" });
            modelbuilder.Entity<Country>().HasData(new Country { Id = -6, CountryName = "Australia", Continent = "Australia" });

            modelbuilder.Entity<City>().HasData(new City { Id = -1, CityName = "Gothenburg", CountryId = -1 });
            modelbuilder.Entity<City>().HasData(new City { Id = -2, CityName = "Borås", CountryId = -1 });
            modelbuilder.Entity<City>().HasData(new City { Id = -3, CityName = "Oslo", CountryId = -2 });
            modelbuilder.Entity<City>().HasData(new City { Id = -4, CityName = "Austin", CountryId = -3 });
            modelbuilder.Entity<City>().HasData(new City { Id = -5, CityName = "Tijuana", CountryId = -4 });
            modelbuilder.Entity<City>().HasData(new City { Id = -6, CityName = "Tokyo", CountryId = -5 });
            modelbuilder.Entity<City>().HasData(new City { Id = -7, CityName = "Melbourne", CountryId = -6 });
            modelbuilder.Entity<City>().HasData(new City { Id = -8, CityName = "Chicago", CountryId = -3 });
            modelbuilder.Entity<City>().HasData(new City { Id = -9, CityName = "Kyoto", CountryId = -5 });
            modelbuilder.Entity<City>().HasData(new City { Id = -10, CityName = "Bergen", CountryId = -2 });

            modelbuilder.Entity<Person>().HasData(new Person { Id = -1, Phonenumber = 0738450197, Name = "Simon Eliasson", CityId = -1 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -2, Phonenumber = 0709952132, Name = "Janne Karlsson", CityId = -10 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -3, Phonenumber = 0782161234, Name = "Annie Svensson", CityId = -2 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -4, Phonenumber = 0741237894, Name = "Kalle Carlsson", CityId = -3 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -5, Phonenumber = 0738660102, Name = "Andy Hjert", CityId = -4 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -6, Phonenumber = 0759982251, Name = "Björn Bergman", CityId = -5 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -7, Phonenumber = 0761496378, Name = "Sara Strand", CityId = -6 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -8, Phonenumber = 0778852211, Name = "Frida Svensson", CityId = -7 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -9, Phonenumber = 0778852211, Name = "Andy Karlsson", CityId = -8 });
            modelbuilder.Entity<Person>().HasData(new Person { Id = -10, Phonenumber = 0778852211, Name = "Charlie Svensson", CityId = -9 });

            modelbuilder.Entity<Language>().HasData(new Language { Id = -1, LanguageName = "Swedish" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = -2, LanguageName = "Japanese" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = -3, LanguageName = "Norwegian" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = -4, LanguageName = "Spanish" });
            modelbuilder.Entity<Language>().HasData(new Language { Id = -5, LanguageName = "English" });
 

            modelbuilder.Entity<Person>()
                .HasMany(l => l.LanguagesList)
                .WithMany(p => p.PeopleList)
                .UsingEntity(j => j.HasData(new { PeopleListId = -1, LanguagesListId = -1 }));

            modelbuilder.Entity<Person>()
                .HasMany(l => l.LanguagesList)
                .WithMany(p => p.PeopleList)
                .UsingEntity(j => j.HasData(new { PeopleListId = -1, LanguagesListId = -2 }));

            modelbuilder.Entity<Person>()
                .HasMany(l => l.LanguagesList)
                .WithMany(p => p.PeopleList)
                .UsingEntity(j => j.HasData(new { PeopleListId = -2, LanguagesListId = -3 }));

            modelbuilder.Entity<Person>()
                .HasMany(l => l.LanguagesList)
                .WithMany(p => p.PeopleList)
                .UsingEntity(j => j.HasData(new { PeopleListId = -3, LanguagesListId = -4 }));

            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();

            modelbuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = adminRoleId,
                Name = "Admin",
                NormalizedName = "ADMIN"

            });

            modelbuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "USER"
            });

            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            modelbuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id=userId,
                Email="admin@admin.com",
                NormalizedEmail="ADMIN@ADMIN.COM",
                UserName="admin@admin.com",
                NormalizedUserName="ADMIN@ADMIN.COM",
                FirstName ="Admin",
                LastName ="Adminsson",
                BirthDate ="1800-01-01",
                PasswordHash = hasher.HashPassword(null,"password")
                // Värt & notera att man kan bypassa lösenords kraven när man seedar in lösenord!
            });

            modelbuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = userId
            });

        }

    }
}
