using Microsoft.EntityFrameworkCore;
using StudentBeheer.Models;

namespace StudentBeheer.Data
{
    public class DataBaseSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StudentBeheerContext(serviceProvider.GetRequiredService
                                                              <DbContextOptions<StudentBeheerContext>>()))
            {
                

                if (!context.Student.Any())
                {
                    context.Student.AddRange(
                    new Student { Voornaam = "Cedric", Achternaam = "Vereecke", Geboortedatum = new DateTime(1999, 4, 12), Gender = (Gender)'M' },
                    new Student { Voornaam = "Rogier", Achternaam = "Clarisse", Geboortedatum = new DateTime(1998, 2, 2), Gender = (Gender)'O' },
                    new Student { Voornaam = "Leen", Achternaam = "Haegemans", Geboortedatum = new DateTime(1999, 10, 15), Gender = (Gender)'M' },
                    new Student { Voornaam = "Jos", Achternaam = "Vermeire", Geboortedatum = new DateTime(1996, 5, 6), Gender = (Gender)'O' }
                    );
                    context.SaveChanges();
                }


                if (!context.Module.Any())
                {
                    context.Module.AddRange(
                    new Module { Begin = new DateTime(2021, 4, 12), Desc = "Wiskundige structuren worden met strikte logische redeneringen opgebouwd. Wiskundige beweringen waarvan de juistheid is aangetoond heten stellingen; zij doen uitspraken over gedefinieerde objecten en formuleren verbanden daartussen. De formele redenering die aantoont dat een stelling waar is, noemt men een wiskundig bewijs. Bij het opstellen van een bewijs wordt uitgegaan van een (klein) aantal uitgangspunten (axioma's) en van definities.", Eind = new DateTime(2021, 4, 12), Title = "Wiskunde" },
                    new Module { Begin = new DateTime(2022, 8, 01), Desc = "Het Nederlands is een West-Germaanse taal en de officiële taal van Nederland, Suriname en een van de drie officiële talen van België. Binnen het Koninkrijk der Nederlanden is het Nederlands ook een officiële taal van Aruba, Curaçao en Sint-Maarten. Het Nederlands is de op twee na meest gesproken Germaanse taal.", Eind = new DateTime(2022, 8, 01), Title = "Nederlands" }
                    ) ;
                    context.SaveChanges();
                }

                if (!context.Inschrijvingen.Any())
                {
                    context.Inschrijvingen.AddRange(
                        new Inschrijvingen { ModuleId = 1, StudentId = 1 },
                        new Inschrijvingen { ModuleId = 2, StudentId = 2 });
                    context.SaveChanges();
                }
            }
        }
    }
}
