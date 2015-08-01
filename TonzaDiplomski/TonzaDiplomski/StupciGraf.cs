using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TonzaDiplomski {
    public class StupciGraf {

        // inicijalizacije
        int verzija=2;
        string[] boje = new string[20]
                     { "#48FB8E", "#FB8E48", "#8EFB48", "#488EFB", "#FB488E", "#8E8E48", "#8E8EFB", "#48488E", "#4848FB", "#FBFB8E"
                        , "#FBFB48", "#8E488E", "#8EFB8E", "#488E48", "#48FB48", "#FB8EFB", "#FB48FB", "#8E8E8E", "#484848", "#FBFBFB" };

        string grafID = (new Random(DateTime.Now.Millisecond)).Next().ToString();       //genereriramo slučajni ID koji će biti dio imena svih elemenata u grafu kako bi kasnije mogli preko Javascrripta pristupati objektima

        StringBuilder cijeliStupci = new StringBuilder();

        int redniBrojStupca = 0;                // inicijalizacija brojača isječaka
        int maxBrojStupaca = 10;                // prikazujemo n-1 stupaca i ostatak
        int pocetniOdmakStupaca = 10;           // za koliko je prvi stupac odmaknut od osi Y
        int razmakStupaca = 2;
        int visinaStupca = 250;                 // inicijalna visina stupca
        int sirina = 500;
        int visina=400;
        int ishodisteX=30;
        int ishodisteY=380;
        int odmakOdRuba = 60;
        int naslovX;
        int naslovY;




        List<IStupacZaGraf> stupci = new List<IStupacZaGraf>();
        

        string svgStr;
        string svgStrPočetak;//= "<svg id=\"" + grafID + "_svgContainer\" width = \"" + sirina.ToString() + "\" height = \"" + visina.ToString() + "\"class=\"stupciSVG\">";;
        string svgStrKraj = "\n</svg>\n";
        
            

    public StupciGraf(string naslovGrafa, List<PodatakZaGraf> ulazniPodaci, int verzijaGrafa) {                           // konstruktor


            // podesavamo ishodiste ovisno o verziji (verzija 1 nema labele ispod grafa)
            verzija = verzijaGrafa;
            ishodisteX = 30;
            if (verzija==1) {
                ishodisteY = 380;
            }
            else {
                ishodisteY = 320;
            }

            //      definiramo veličinu i osnove postavke za graf
            naslovX = sirina / 2;
            naslovY = 30;

            //ako ima podataka više od maxBrojStupaca, onda ih sortiraj po veličini podatka silazno tako da onaj ostatak prikazuje sume manjih
            ulazniPodaci.Sort((y, x) => x.Podatak.CompareTo(y.Podatak));


            svgStrPočetak = "\n<svg id=\"" + grafID + "_svgContainer\" width = \"" + sirina.ToString() + "\" height = \"" + visina.ToString() + "\"class=\"stupciSVG\">\n";

            // započni string
            svgStr = svgStrPočetak;

            // dodaj koordinatni sustav
            svgStr += nacrtajKoordinatniSustav(ishodisteX, ishodisteY, sirina - odmakOdRuba, ishodisteY - odmakOdRuba);
            svgStr += ispisiNaslov(naslovGrafa);

            // ispiši stupce 

            svgStr += iscrtajStupce(ulazniPodaci);

            
            // završi string
            svgStr += svgStrKraj;
        }

        public string ispisiNaslov(string pnaslov) {
            string naslov;
            naslov ="\n<g id=\""+grafID+"_grafNaslovGrupa\">\n";
            //naslov.Append("<text x=\""+naslovX.ToString()+"\" y=\"20\" style=\"fill:white;font-size:"+naslovSize.ToString()+";font-weight:bold;\">\n");
            naslov +="<text id=\"" + grafID + "_grafNaslov\" x=\"" + naslovX.ToString() + "\" y=\""+naslovY+"\" class=\"grafNaslov\">\n";
            naslov+=pnaslov;
            naslov+="</text>\n";
            naslov+="</g>\n";
            return naslov;

        }
        string nacrtajKoordinatniSustav(int pishodisteX, int pishodisteY,int duzinaXosi, int duzinaYosi) {
            string tekst;
            /*
            <g id="koordinatniSustav1" zIndex="6">
                    <line id="osX" x1="30" y1="350" x2="30" y2="150" fill="black" stroke="white" stroke-width="2" ></line>
                    <line id="osY" x1="30" y1="350" x2="370" y2="350" fill="black" stroke="white" stroke-width="2"></line>
                </g>
            */


            // koordinate Osi
            tekst = "\n<g id=\""+grafID+"_koordinatniSustav\" zIndex=\"6\">";

            // y - koordinatna OS
            tekst += "\n<line id=\""+grafID+"_osX\" x1=\""+pishodisteX.ToString()+"\" y1=\""+pishodisteY.ToString()
                    +"\" x2=\""+pishodisteX.ToString()+"\" y2=\""+(pishodisteY-duzinaYosi).ToString()
                    +"\" fill=\"black\" stroke=\"white\" stroke-width=\"2\" ></line>";

            // x -koordnatna OS
            tekst += "\n<line id=\"" + grafID + "_osY\" x1=\"" + pishodisteX.ToString() + "\" y1=\"" + pishodisteY.ToString()
                    + "\" x2=\"" + (pishodisteX + duzinaXosi).ToString() + "\" y2=\"" + (pishodisteY).ToString()
                    + "\" class=\"stupciKoordinatniSustav\" ></line>";

            tekst += "\n</g>";

            

            return tekst;
        }

        string iscrtajStupce(List<PodatakZaGraf> pulazniPodaci) {

            string stupciStr="";                           // tu ćemo spremiti kompletne stupce i vratiti string za pisanje

            // koliko ima podataka
            // ako ih ima više od maxBrojStupaca, onda stavi brojstupaca na maxBrojStupaca
            int brojStupaca;
            if (pulazniPodaci.Count() <= maxBrojStupaca) {
                brojStupaca = pulazniPodaci.Count();
            }
            else {
                brojStupaca = maxBrojStupaca;
            }


            int duzinaXosi = sirina - odmakOdRuba - ishodisteX;
            int sumaRazmaka = ((brojStupaca - 1) * razmakStupaca);
            int sirinaStupca = (duzinaXosi - sumaRazmaka) / brojStupaca;
            int startStupca = ishodisteX + pocetniOdmakStupaca;

            double najveciPodatak=pulazniPodaci.Max(podatak => podatak.Podatak);
            double faktorVelicineStupca = najveciPodatak / visinaStupca;

            double ostatakSumaPodataka = 0;
            if (pulazniPodaci.Count <= maxBrojStupaca) {
                foreach (PodatakZaGraf podatak in pulazniPodaci) {

                    // stupci.Add(new StupacZaGraf_v1(redniBrojStupca, grafID, startStupca, ishodisteY, sirinaStupca, Convert.ToInt32(podatak.Podatak / faktorVelicineStupca), boje[pulazniPodaci.IndexOf(podatak)], podatak.Naslov, podatak.Podatak));
                    DodajStupac(redniBrojStupca, grafID, startStupca, ishodisteY, sirinaStupca, Convert.ToInt32(podatak.Podatak / faktorVelicineStupca), boje[pulazniPodaci.IndexOf(podatak)], podatak.Naslov, podatak.Podatak);

                    redniBrojStupca++;
                    startStupca = startStupca + sirinaStupca + razmakStupaca;           // pripremi x koordinatu za idući stupac

                    // gledamo koliko stupaca stane. Znamo dužinu ishodišne osi, pa prema tome dimenzioniramo širinu svakog stupca.
                    // Naravno trebamo znati koliko podataka ima. postoji maximum broja stupaca, definiran na početku klase - maxBrojStupaca.
                }
            }
            else {
                int i = 1;
                foreach (PodatakZaGraf podatak in pulazniPodaci) {
                    if (i < maxBrojStupaca) {     //ove sad stavljamo u ostalo
                        //stupci.Add(new StupacZaGraf_v1(redniBrojStupca, grafID, startStupca, ishodisteY, sirinaStupca, Convert.ToInt32(podatak.Podatak / faktorVelicineStupca), boje[pulazniPodaci.IndexOf(podatak)], podatak.Naslov, podatak.Podatak));
                        DodajStupac(redniBrojStupca, grafID, startStupca, ishodisteY, sirinaStupca, Convert.ToInt32(podatak.Podatak / faktorVelicineStupca), boje[pulazniPodaci.IndexOf(podatak)], podatak.Naslov, podatak.Podatak);

                        redniBrojStupca++;
                        startStupca = startStupca + sirinaStupca + razmakStupaca;           // pripremi x koordinatu za idući stupac
                    }
                    else {
                        ostatakSumaPodataka += podatak.Podatak;
                    }
                    ++i;
                }

                // ako je bilo ostatka, zapiši ga
                if (ostatakSumaPodataka > 0) {
                    //stupci.Add(new StupacZaGraf_v1(1000, grafID, startStupca, ishodisteY, sirinaStupca, Convert.ToInt32(ostatakSumaPodataka / faktorVelicineStupca), "#FFFFFF", "Ostalo", ostatakSumaPodataka));
                    DodajStupac(1000, grafID, startStupca, ishodisteY, sirinaStupca, Convert.ToInt32(ostatakSumaPodataka / faktorVelicineStupca), "#FFFFFF", "Ostalo", ostatakSumaPodataka);
                }

            }

            // sad daj sve stupce u string
            foreach (IStupacZaGraf stupac in stupci) {
                stupciStr += stupac.ToString();
            }

            return stupciStr;
        }
        // ovdje dodajemo stupac ovisno o verziji grafa koja je odabrana. Imamo verzije 1 i 2
        void DodajStupac(int predniBroj, string pgrafID, int pposX, int pposY, int psirina, int pvisina, string pbojaStupca, string pnaslovStupca, double ppodatakStupca) {

            switch (verzija){
                case 1:
                    stupci.Add(new StupacZaGraf_v1(predniBroj, pgrafID, pposX, pposY, psirina, pvisina, pbojaStupca, pnaslovStupca, ppodatakStupca));
                    break;
                case 2:
                    stupci.Add(new StupacZaGraf_v2(predniBroj, pgrafID, pposX, pposY, psirina, pvisina, pbojaStupca, pnaslovStupca, ppodatakStupca));
                    break;
            }

            

        }
        public override string ToString() {
            return svgStr;
        }

    }
}