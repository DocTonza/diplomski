namespace TonzaDiplomski {
    public interface IStupacZaGraf {
        string BojaStupca { get; set; }
        string NaslovStupca { get; set; }
        double PodatakStupca { get; set; }
        int PosX { get; set; }
        int PosY { get; set; }
        int Sirina { get; set; }
        int Visina { get; set; }

        string ToString();
    }
}