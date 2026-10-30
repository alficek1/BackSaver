using System.Collections.ObjectModel;

// explicitní using pro diagnostiku CS0053
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;

namespace BackSaver
{
    public class SpravceHer : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Hra> Hry { get; set; }

        private readonly string cesta = "hry.xml";

        public Hra AktualHra { get; set; }

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
            Hry.Remove(hra);
            //NajdiNejblizsi();
        }

        public void Uloz()
        {
            XmlSerializer serializer = new(Hry.GetType());
            using StreamWriter sw = new(cesta);
            serializer.Serialize(sw, Hry);
        }

        public void Nacti()
        {
            XmlSerializer serializer = new(Hry.GetType());
            if (File.Exists(cesta))
            {
                using StreamReader sr = new(cesta);
                Hry = (ObservableCollection<Hra>)serializer.Deserialize(sr);
            }
            else
                Hry = [];

            //NajdiNejblizsi();
        }
    }


}
