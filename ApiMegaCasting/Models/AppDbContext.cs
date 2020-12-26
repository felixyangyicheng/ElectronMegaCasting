using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelMegaCasting;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace ApiMegaCasting.Models
{
    public class AppDbContext : DbContext
    {
    //    public AppDbContext(DbContextOptions<AppDbContext> options)
    //     : base(options)
    //    {
    //    }

    //    public DbSet<Artist> Artists { get; set; }
    //    public DbSet<Contract> Contracts { get; set; }
    //    public DbSet<Offer> Offers { get; set; }
    //    public DbSet<ProfessionSector> ProfessionSectors { get; set; }
    //    public DbSet<Profession> Professions { get; set; }

    //    public DbSet<Studio> Studios { get; set; }
    //    public DbSet<DiffsionPartner> DiffsionPartners { get; set; }
        
    //    protected  override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        var professionSectorJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Models/ProfessionSectorData.json");
    //        IList<ProfessionSector> professionSectors = JsonConvert.DeserializeObject<IList<ProfessionSector>>(professionSectorJsonData);
    //        modelBuilder.Entity<ProfessionSector>().HasData(professionSectors);

    //        //var professionJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Models/ProfessionData.json");
    //        //IList<Profession> professions = JsonConvert.DeserializeObject<IList<Profession>>(professionJsonData);
    //        //modelBuilder.Entity<Profession>().HasData(professions);

    //        var artistJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Models/ArtistData.json");
    //        IList<Artist> artists = JsonConvert.DeserializeObject<IList<Artist>>(artistJsonData);
    //        modelBuilder.Entity<Artist>().HasData(artists);

    //        var contractJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Models/ContractData.json");
    //        IList<Contract> contracts = JsonConvert.DeserializeObject<IList<Contract>>(contractJsonData);
    //        modelBuilder.Entity<Contract>().HasData(contracts);

    //        var diffsionPartnerJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Models/DiffusionPartnerData.json");
    //        IList<DiffsionPartner> diffsionPartners = JsonConvert.DeserializeObject<IList<DiffsionPartner>>(diffsionPartnerJsonData);
    //        modelBuilder.Entity<DiffsionPartner>().HasData(diffsionPartners);

    //        var offerJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Models/OfferData.json");
    //        IList<Offer> offers = JsonConvert.DeserializeObject<IList<Offer>>(offerJsonData);
    //        modelBuilder.Entity<Offer>().HasData(offers);

    //        var studioJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"/Models/StudioData.json");
    //        IList<Studio> studios = JsonConvert.DeserializeObject<IList<Studio>>(studioJsonData);
    //        modelBuilder.Entity<Studio>().HasData(studios);
    //        modelBuilder.Entity<Profession>().HasData(new Profession
    //        {
    //            ProfessionId = 1,
    //            ProfessionName = "maquilleur",
    //            ProfessionSectorId=1,
    //        });
    //    }
   }
}
