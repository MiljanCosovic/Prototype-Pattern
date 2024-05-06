using System;
using System.Collections.Generic;

namespace PlayerProfileApp
{
    public interface IProfilePrototype
    {
        IProfilePrototype Clone();
    }

    public class PlayerProfile : IProfilePrototype
    {
        public string Username { get; set; }
        public List<string> PreferiraneIgre { get; set; }
        public int NivoVestine { get; set; }
        public List<string> PreferiraniRezim { get; set; }
        public string VremenskaZona { get; set; }

        public IProfilePrototype Clone()
        {
            // Kloniranje profila
            return new PlayerProfile
            {
                Username = this.Username,
                PreferiraneIgre = new List<string>(this.PreferiraneIgre),
                NivoVestine = this.NivoVestine,
                PreferiraniRezim = new List<string>(this.PreferiraniRezim),
                VremenskaZona = this.VremenskaZona
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Originalni profil
            var originalProfile = new PlayerProfile
            {
                Username = "Igrac1",
                PreferiraneIgre = new List<string> { "Fifa", "NBA" },
                NivoVestine = 5,
                PreferiraniRezim = new List<string> { "Sport", "Trke" },
                VremenskaZona = " GMT +2"
            };

            // Kloniranje profila
            var clonedProfile = originalProfile.Clone() as PlayerProfile;

            var clonedProfile2 = originalProfile.Clone() as PlayerProfile;

            // Promena kloniranog profila
            clonedProfile.Username = "Igrac2";

            clonedProfile2.Username = "Igrac3";

            

            List<string> newPreferredGames = new List<string> { "Virtual Tenis", "UFC" };
            clonedProfile2.PreferiraneIgre = newPreferredGames;


           
            Console.WriteLine("Original Profil:");
            PrintProfile(originalProfile);

            Console.WriteLine("\nKlonirani Profil:");
            PrintProfile(clonedProfile);

            Console.WriteLine("\nKlonirani Profil2:");
            PrintProfile(clonedProfile2);


        }

        static void PrintProfile(PlayerProfile profile)
        {
            Console.WriteLine($"Username: {profile.Username}");
            Console.WriteLine("Preferirane Igre: " + string.Join(", ", profile.PreferiraneIgre));
            Console.WriteLine($"Nivo Vestine: {profile.NivoVestine}");
            Console.WriteLine("Preferirani Rezim Igre: " + string.Join(", ", profile.PreferiraniRezim));
            Console.WriteLine($"Vremenska Zona: {profile.VremenskaZona}");

        }
    }
}
