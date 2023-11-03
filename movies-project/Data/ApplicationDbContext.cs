using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using movies_project.Models;

namespace movies_project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieImage> MovieImages { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>().HasData(
                    new Genre() { Id = 1, Name = "Drama"},
                    new Genre() { Id = 2, Name = "Comedy" },
                    new Genre() { Id = 3, Name = "Action"},
                    new Genre() { Id = 4, Name = "Horror"}
                );

            modelBuilder.Entity<Movie>().HasData(
                    new Movie() 
                    { 
                        Id = 1,
                        Name = "The Godfather",
                        Director = "Francis Ford Coppola",
                        Poster = "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
                        Rate = 9.2,
                        DateShow = "1972",
                        Actor1 = "Marlon Brando",
                        Actor2 = "Al Pacino",
                        Actor3 = "James Caan",
                        Actor4 = "Diane Keaton",
                        Story = "Don Vito Corleone, head of a mafia family, decides to hand over his empire to his youngest son Michael. However, his decision unintentionally puts the lives of his loved ones in grave danger.",
                        GenreId = 1,
                        Trailer = "https://www.youtube.com/watch?v=UaVTIH8mujA",
                        Runtime = "2h 44m"
                    },
                    new Movie()
                    {
                        Id = 2,
                        Name = "The Dark Knight",
                        Director = "Christopher Nolan",
                        Poster = "https://m.media-amazon.com/images/I/818hyvdVfvL.jpg",
                        Rate = 9.0,
                        DateShow = "2008",
                        Actor1 = "Christian Bale",
                        Actor2 = "Heath Ledger",
                        Actor3 = "Aaron Eckhart",
                        Actor4 = "Michael Caine",
                        Story = "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
                        GenreId = 3,
                        Trailer = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
                        Runtime = "2h 32m"
                    },
                    new Movie()
                    {
                        Id = 3,
                        Name = "Interstellar",
                        Director = "Christopher Nolan",
                        Poster = "https://m.media-amazon.com/images/I/91obuWzA3XL._AC_UF894,1000_QL80_.jpg",
                        Rate = 8.7,
                        DateShow = "2014",
                        Actor1 = "Matthew McConaughey",
                        Actor2 = "Anne Hathaway",
                        Actor3 = "Jessica Chastain",
                        Actor4 = "Mackenzie Foy",
                        Story = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.",
                        GenreId = 1,
                        Trailer = "https://www.youtube.com/watch?v=zSWdZVtXT7E",
                        Runtime = "2h 49m"
                    }
                );

            modelBuilder.Entity<MovieImage>().HasData(
                    new MovieImage() { Id = 1, Photo = "https://media.gq-magazine.co.uk/photos/6389fc64ae86bf6162acc67c/16:9/w_2560%2Cc_limit/The-Godfather-Part-II-HEADER-1.jpg", MovieId = 1 },
                    new MovieImage() { Id = 2, Photo = "https://hips.hearstapps.com/hmg-prod/images/abe-vigoda-and-robert-duvall-watch-marlon-brando-and-al-news-photo-1653506800.jpg", MovieId = 1 },
                    new MovieImage() { Id = 3, Photo = "https://idsb.tmgrup.com.tr/ly/uploads/images/2022/07/07/217434.jpg", MovieId = 1 },
                    new MovieImage() { Id = 4, Photo = "https://m.media-amazon.com/images/M/MV5BMTM1Njc5NTE0M15BMl5BanBnXkFtZTcwMDgzMTk2Mw@@._V1_.jpg", MovieId = 2 },
                    new MovieImage() { Id = 5, Photo = "https://www.motionpictures.org/wp-content/uploads/2022/02/rev-1-TBM-11721r_High_Res_JPEG.jpeg", MovieId = 2 },
                    new MovieImage() { Id = 6, Photo = "https://www.ocregister.com/wp-content/uploads/migration/kpj/kpjr68-16movbatman3large.jpg", MovieId = 2 },
                    new MovieImage() { Id = 7, Photo = "https://ew.com/thmb/xGFU5QJGZ13NBR-sNhSn0PeDQBg=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/interstellar-11-4cd43e5ca7c74190b7e92ed912cdb31b.jpg", MovieId = 3 },
                    new MovieImage() { Id = 8, Photo = "https://img-cdn.sfanytime.com/MEDIAM/4879ca25-d6e3-48c1-a012-a3e700a022a2_MEDIAM_dd32bae7-3983-475e-89b4-86ea15292723.jpg", MovieId = 3 },
                    new MovieImage() { Id = 9, Photo = "https://www.looper.com/img/gallery/the-ending-of-interstellar-explained/intro-1562880872.jpg", MovieId = 3 }
                 );

            modelBuilder.Entity<Team>().HasData(
                    new Team() { Id = 1, Name = "Talaat Ramadan", Photo = "https://pbs.twimg.com/profile_images/1604581116081541121/Zk1IMEyZ_400x400.jpg", Description = "Backend Developer", Twitter = "https://twitter.com/ixtalaat", Linkedin = "https://www.linkedin.com/in/ixtalaat/", Facebook = "https://www.facebook.com/ixtalat" }                    
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}