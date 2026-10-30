using System.Collections.ObjectModel;

// explicitní using pro diagnostiku CS0053
using System.ComponentModel;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace BackSaver
{
    public class SpravceHer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Hra> Hry { get; set; }

        private readonly string cesta = "hry.xml";

        private Hra? aktualHra;

        public Hra? AktualHra
        {
            get => aktualHra;
            set
            {
                if (aktualHra == value)
                    return;

                aktualHra = value;
                VyvolejZmenu(nameof(AktualHra));
            }
        }

        public SpravceHer()
        {
            Hry = [];
        }

        protected void VyvolejZmenu(string vlastnost)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(vlastnost));
        }
        public void Pridej(string nazevHry, string plnaCestaExe, string saveDirHry, string cestaZalohy)
        {
            /* sem dat validace vstupu
            if (jmeno.Length < 3)
                throw new ArgumentException("Jméno je příliž krátké");
            if (datumNarozeni == null)
                throw new ArgumentException("Nebylo zadané datum narození");
            if (datumNarozeni.Value.Date > DateTime.Today)
                throw new ArgumentException("Datum narození nesmí být v budoucnosti");
            */
            Hra hra = new(nazevHry, plnaCestaExe, saveDirHry, cestaZalohy);
            Hry.Add(hra);
            //NajdiNejblizsi();
        }

        public void Odeber(Hra hra)
        {
            if (AktualHra == hra)
                AktualHra = null;

            Hry.Remove(hra);
            //NajdiNejblizsi();
        }

        public void Uloz()
        {
            XmlSerializer serializer = new(typeof(UlozenaData));
            using StreamWriter sw = new(cesta);
            serializer.Serialize(sw, new UlozenaData
            {
                Hry = Hry,
                AktualHra = AktualHra,
                AktualHraIndex = AktualHra is null ? null : Hry.IndexOf(AktualHra)
            });
        }

        public void Nacti()
        {
            if (File.Exists(cesta))
            {
                using XmlReader reader = XmlReader.Create(cesta);
                reader.MoveToContent();

                if (reader.LocalName == "ArrayOfHra")
                {
                    XmlSerializer legacySerializer = new(typeof(ObservableCollection<Hra>));
                    Hry = (ObservableCollection<Hra>?)legacySerializer.Deserialize(reader) ?? [];
                    AktualHra = null;
                }
                else
                {
                    XmlSerializer serializer = new(typeof(UlozenaData));
                    UlozenaData? data = (UlozenaData?)serializer.Deserialize(reader);
                    Hry = data?.Hry ?? [];

                    if (data?.AktualHraIndex is int index && index >= 0 && index < Hry.Count)
                    {
                        AktualHra = Hry[index];
                    }
                    else if (data?.AktualHra is Hra ulozenaAktualHra)
                    {
                        AktualHra = Hry.FirstOrDefault(hra =>
                            hra.NazevHry == ulozenaAktualHra.NazevHry &&
                            hra.PlnaCestaExe == ulozenaAktualHra.PlnaCestaExe &&
                            hra.SaveDirHry == ulozenaAktualHra.SaveDirHry &&
                            hra.CestaZalohy == ulozenaAktualHra.CestaZalohy);
                    }
                    else
                    {
                        AktualHra = null;
                    }
                }
            }
            else
            {
                Hry = [];
                AktualHra = null;
            }

            //NajdiNejblizsi();
        }
    }

    public class UlozenaData
    {
        public ObservableCollection<Hra> Hry { get; set; } = [];

        public Hra? AktualHra { get; set; }

        public int? AktualHraIndex { get; set; }
    }

}
