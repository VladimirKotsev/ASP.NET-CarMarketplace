namespace CarMarketplace.Data.Configurations
{
    using CarMarketplace.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            //builder.HasData(this.GenerateCities());
        }

        private City[] GenerateCities()
        {
            ICollection<City> cities = new HashSet<City>();

            int id = 1;

            HashSet<string> cityNames = new(){
                "Bansko", "Blagoevgrad", "Gotse Delchev", "Petrich", "Razlog", "Sandanski",
                "Belitsa", "Kresna", "Simitli", "Strumyani", "Yakoruda", "Velingrad", "Garmen",
                "Dobrinishte", "Rila", "Kocherinovo", "Satovcha", "Razlog", "Sandanski", "Hadzhidimovo", "Satovcha"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 1 });
            }

            cityNames.Clear();
            cityNames = new(){
                "Aytos", "Burgas", "Balgarovo", "Bratovo", "Bryastovets", "Bŭlgari", "Dimchevo",
                "Drachevo", "Dyulevo", "Gabar", "Golyamo Bukovo", "Gorno Ezerovo", "Izgrev", "Kableshkovo",
                "Kameno", "Karnobat", "Kiten", "Konstantinovo", "Kosharitsa", "Krŭstina", "Livada",
                "Malko Tarnovo", "Marinka", "Mirolyubovo", "Nesebar", "Obzor", "Pomorie", "Primorsko",
                "Ravda", "Rosen", "Rudnik", "Rusokastro", "Sadievo", "Slanchevo", "Sozopol", "Sredets",
                "Stratsin", "Sŭdievo", "Sungurlare", "Svetlina", "Svoboda", "Tsarevo", "Tvarditsa",
                "Varovnik", "Vedrovo", "Veselie", "Vizitsa", "Vŭrgotch", "Yasna Polyana"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 2 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Dobrich", "Balchik", "General Toshevo", "Kavarna", "Shabla", "Tervel", "Krushari"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 3 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Gabrovo", "Sevlievo", "Dryanovo", "Tryavna"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 4 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Haskovo", "Dimitrovgrad", "Svilengrad", "Harmanli", "Topolovgrad", "Ivaylovgrad", "Lyubimets", "Madzharovo", "Mineralni Bani"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 5 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Kardzhali", "Momchilgrad", "Ardino", "Krumovgrad", "Dzhebel", "Kirkovo"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 6 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Kyustendil", "Boboshevo", "Brezovo", "Dupnitsa", "Sapareva Banya", "Zemen"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 7 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Lovech", "Apriltsi", "Letnitsa", "Lukovit", "Teteven", "Yablanitsa", "Ugarchin", "Troyan"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 8 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Montana", "Berkovitsa", "Boychinovtsi", "Brusartsi", "Chiprovtsi", "Georgi Damyanovo", "Lom", "Valchedram", "Yakimovo"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 9 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Pazardzhik", "Belovo", "Panagyurishte", "Plovdivtsi", "Strelcha", "Septemvri", "Rakitovo", "Velingrad"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 10 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Pernik", "Radomir", "Batanovtsi", "Breznik"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 11 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Pleven", "Dolni Dabnik", "Dolni Dabnik", "Gulyantsi", "Levski", "Nikopol", "Cherven Bryag"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 12 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Plovdiv", "Asenovgrad", "Rakovski", "Karlovo", "Parvomay", "Sadovo", "Hisarya", "Perushtitsa", "Saedinenie", "Kuklen", "Sopot", "Krichim", "Rozino", "Laki", "Stamboliyski"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 13 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Razgrad", "Isperih", "Loznitsa", "Samuil", "Tsar Kaloyan", "Zavet"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 14 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Ruse", "Borovo", "Dve Mogili", "Ivanovo", "Slivo Pole", "Tsenovo"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 15 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Shumen", "Kaspichan", "Novi Pazar", "Veliki Preslav", "Varbitsa"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 16 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Silistra", "Alfatar", "Dulovo", "Glavinitsa", "Kaynardzha", "Sitovo", "Tutrakan"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 17 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Sliven", "Kotel", "Nova Zagora", "Tvarditsa"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 18 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Smolyan", "Chepelare", "Devin", "Dospat", "Madan", "Rudozem", "Zlatograd"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 19 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Sofia"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 20 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Bankya", "Botevgrad", "Elin Pelin", "Etropole", "Gorna Malina", "Ihtiman", "Kostenets", "Kostinbrod", "Mirkovo", "Pirdop", "Pravets", "Samokov", "Slivnitsa"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 21 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Stara Zagora", "Chirpan", "Galabovo", "Gurkovo", "Kazanlak", "Maglizh", "Nikolaevo", "Opan", "Radnevo", "Shipka"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 22 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Targovishte", "Omurtag", "Antonovo", "Opaka", "Popovo"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 23 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Varna", "Aksakovo", "Avren", "Beloslav", "Byala", "Devnya", "Dolni Chiflik", "Dalgopol", "Provadia", "Suvorovo"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 24 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Veliko Tarnovo", "Elena", "Gorna Oryahovitsa", "Lyaskovets", "Pavlikeni", "Svishtov", "Strazhitsa", "Suhindol"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 25 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Vidin", "Belogradchik", "Bregovo", "Boynitsa", "Gramada", "Dimovo", "Kula"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 26 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Vratsa", "Borovan", "Boychinovtsi", "Byala Slatina", "Kozloduy", "Mezdra", "Mizia", "Roman", "Hayredin", "Hristo Danovo"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 27 });
            }

            cityNames.Clear();
            cityNames = new()
            {
                "Yambol", "Bolyarovo", "Elhovo", "Straldzha", "Tundzha"
            };

            foreach (string cityName in cityNames)
            {
                cities.Add(new City { Id = id++, CityName = cityName, ProvinceId = 28 });
            }

            return cities.ToArray();
        }
    }
}
