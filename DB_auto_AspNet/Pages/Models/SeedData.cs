
using Bogus;

namespace DB_auto_AspNet.Pages.Models
{
    public static class SeedData
    {
        public static void Initialize(ApplicationContext context)
        {
            var vehicles = new Faker<Vehicle>("ru")
                .RuleFor(v => v.Type, f => f.PickRandom("Авто", "Мото", "Вело"))
                .RuleFor(v => v.Brand, (f, v) =>
                    v.Type switch
                    {
                        "Авто" => f.PickRandom("Toyota", "BMW", "Lada", "Ford", "Kia", "Hyundai"),
                        "Мото" => f.PickRandom("Yamaha", "Honda", "Harley-Davidson", "Suzuki", "Ducati"),
                        "Вело" => f.PickRandom("Stels", "Giant", "Merida", "Trek", "Cube"),
                        _ => "Неизвестно"
                    })
                 //.RuleFor(v => v.Model, f => f.Commerce.ProductName())
                 .RuleFor(v => v.Model, (f, v) =>
        v.Type switch
        {
            "Авто" when v.Brand == "Toyota" => f.PickRandom("Camry", "Corolla", "RAV4", "Land Cruiser", "Hilux"),
            "Авто" when v.Brand == "BMW" => f.PickRandom("X5", "3 Series", "5 Series", "X3", "i8"),
            "Авто" when v.Brand == "Lada" => f.PickRandom("Vesta", "Granta", "Niva", "XRAY", "Samara"),
            "Авто" when v.Brand == "Ford" => f.PickRandom("Focus", "Fiesta", "Mustang", "Explorer", "Ranger"),
            "Авто" when v.Brand == "Kia" => f.PickRandom("Rio", "Sportage", "Sorento", "Ceed", "Telluride"),
            "Авто" when v.Brand == "Hyundai" => f.PickRandom("Solaris", "Tucson", "Santa Fe", "Elantra", "Creta"),

            "Мото" when v.Brand == "Yamaha" => f.PickRandom("YZF-R1", "MT-07", "Ténéré 700", "XMAX", "Bolt"),
            "Мото" when v.Brand == "Honda" => f.PickRandom("CBR600RR", "Africa Twin", "Gold Wing", "CB650R", "PCX"),
            "Мото" when v.Brand == "Harley-Davidson" => f.PickRandom("Street 750", "Fat Boy", "Road King", "Sportster S", "Electra Glide"),
            "Мото" when v.Brand == "Suzuki" => f.PickRandom("GSX-R750", "V-Strom 650", "Hayabusa", "Jimny Moto", "Burgman"),
            "Мото" when v.Brand == "Ducati" => f.PickRandom("Panigale V4", "Monster", "Multistrada", "Diavel", "Scrambler"),

            "Вело" when v.Brand == "Stels" => f.PickRandom("Navigator 500", "Agressor MD28", "Energy 2", "Voyager 20", "Hardtail 26"),
            "Вело" when v.Brand == "Giant" => f.PickRandom("Defy Advanced", "Trance X", "Escape", "Roam", "Talon"),
            "Вело" when v.Brand == "Merida" => f.PickRandom("Big Nine", "eBIG.NINE", "Scultura", "Reacto", "Speeder"),
            "Вело" when v.Brand == "Trek" => f.PickRandom("Marlin 5", "Domane SL", "Fuel EX", "Madone", "FX Sport"),
            "Вело" when v.Brand == "Cube" => f.PickRandom("Reaction", "Stereo", "Litening", "Access", "Analog"),

            _ => "Неизвестная модель"
        })




                .RuleFor(v => v.Year, f => f.Random.Number(1995, 2026))
                .RuleFor(v => v.Price, (f, v) =>
                    v.Type switch
                    {
                        "Вело" => f.Random.Decimal(15000, 200000),
                        "Мото" => f.Random.Decimal(150000, 2000000),
                        _ => f.Random.Decimal(300000, 8000000)
                    });

            context.Vehicles.AddRange(vehicles.Generate(25));
            context.SaveChanges();
        }
    }
}
