using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TonzaDiplomski {
    public class CrtaGraf {

        // inicijalizacije
        int verzija=2;
        string[] boje = new string[20]
                     { "#48FB8E", "#FB8E48", "#8EFB48", "#488EFB", "#FB488E", "#8E8E48", "#8E8EFB", "#48488E", "#4848FB", "#FBFB8E"
                        , "#FBFB48", "#8E488E", "#8EFB8E", "#488E48", "#48FB48", "#FB8EFB", "#FB48FB", "#8E8E8E", "#484848", "#FBFBFB" };

        string grafID = (new Random(DateTime.Now.Millisecond)).Next().ToString();       //genereriramo slučajni ID koji će biti dio imena svih elemenata u grafu kako bi kasnije mogli preko Javascrripta pristupati objektima

        //StringBuilder cijeliStupci = new StringBuilder();

        // int redniBrojStupca = 0;                // inicijalizacija brojača isječaka
        // int maxBrojStupaca = 10;                // prikazujemo n-1 stupaca i ostatak
        // int pocetniOdmakStupaca = 10;           // za koliko je prvi stupac odmaknut od osi Y
        // int razmakStupaca = 2;
        int visinaNajviseTocke;                 // (bila je 250) maksimalna visina najviše točke. Ako je navjviša točka više od ovog, radimo skaliranje pomoću faktoraSkaliranja = najvećiPodatak / visinaNajviseTocke
        double faktorSkaliranja = 1;   
        int sirina = 500;
        int visina=400;
        int ishodisteX=30;
        int ishodisteY=380;
        int odmakOdRuba = 60;
        int naslovX;
        int naslovY;
        string naslov { get; set; }





        //List<TockeZaGraf> točke = new List<TockeZaGraf>();
        

        string svgStr;
        string svgStrPočetak;
        string svgStrKraj = "\n</svg>\n";
        
            

    public CrtaGraf(string naslovGrafa, List<PodatakZaGraf> ulazniPodaci, int verzijaGrafa) {                           // konstruktor


            // podesavamo ishodiste ovisno o verziji (verzija 1 nema labele ispod grafa)
            verzija = verzijaGrafa;
            ishodisteX = 30;
            if (verzija==1) {
                ishodisteY = 320;           //380
            }
            else {
                ishodisteY = 320;
            }

            visinaNajviseTocke = ishodisteY - odmakOdRuba - 20;            // 10 px od vrha Y osi

            //      definiramo veličinu i osnove postavke za graf
            naslovX = sirina / 2;
            naslovY = 30;

            //ako ima podataka više od maxBrojStupaca, onda ih sortiraj po veličini podatka silazno tako da onaj ostatak prikazuje sume manjih
            //ulazniPodaci.Sort((y, x) => x.Podatak.CompareTo(y.Podatak));


            svgStrPočetak = "\n<svg id=\"" + grafID + "_svgContainer\" width = \"" + sirina.ToString() + "\" height = \"" + visina.ToString() + "\"class=\"stupciSVG sjena\">\n";

            // započni string
            svgStr = svgStrPočetak;

            // dodaj koordinatni sustav
            svgStr += nacrtajKoordinatniSustav(ishodisteX, ishodisteY, sirina - odmakOdRuba, ishodisteY - odmakOdRuba);
            svgStr += ispisiNaslov(naslovGrafa);
            svgStr += crtajTocke(ulazniPodaci);


            // ispiši točke 
            svgStr += crtajTocke(ulazniPodaci);
            

            
            // završi string
            svgStr += svgStrKraj;
        }

        private string crtajTocke(List<PodatakZaGraf> pulazniPodaci) {
            string tekst="";
            // tu sad crtamo točke i malo računamo

            //nađi najveću vrijednost
            double najveciPodatak = pulazniPodaci.Max(podatak => podatak.Podatak);
            //nađi najmanju vrijednost
            double najmanjiPodatak = pulazniPodaci.Min(podatak => podatak.Podatak);
            int brojPodataka = pulazniPodaci.Count();
            //faktorSkaliranja = Convert.ToInt32(Math.Round(najveciPodatak / Convert.ToDouble(visinaNajviseTocke)));
            faktorSkaliranja = Math.Round(najveciPodatak / Convert.ToDouble(visinaNajviseTocke),2);
            // razmak po X-u računamo tako da širinu X osi podijelimo sa brojem podataka
            int razmakPoX = (sirina - odmakOdRuba - ishodisteX)/pulazniPodaci.Count();

            // sad znamo raznak, faktorSkaliranja, idemo crtati graf
            int startTocke = ishodisteX+razmakPoX;
            tekst = "\n<path id=\""+grafID+"_linijaGrafa\" d=\"M";
           
            foreach (PodatakZaGraf podatak in pulazniPodaci) {
                tekst += startTocke.ToString() + " " + (ishodisteY-Convert.ToInt32((podatak.Podatak / faktorSkaliranja))).ToString()+" L";
                startTocke += razmakPoX;

            }
            tekst = tekst.Substring(0, tekst.Length - 1);           //makniZadnji L koji nam ne treba
            tekst += "\"  class=\"crtaGrafCrta\" />\n";

            // dodaj kruzice na točke
            startTocke = ishodisteX + razmakPoX;            //reset na početak

            foreach (PodatakZaGraf podatak in pulazniPodaci) {

                // dodaj oznake po X osi
                tekst += "\n<circle cx=\"" + startTocke.ToString() + "\" cy=\"" + ishodisteY.ToString() + "\" r=\"1\" class=\"crtaGrafKruzicNaOsiX\" />";

                // kruzici po grafu
                tekst +="\n<circle cx=\""+startTocke.ToString()+"\" cy=\""+ (ishodisteY - Convert.ToInt32((podatak.Podatak / faktorSkaliranja))).ToString() + "\" r=\"1\" class=\"crtaGrafManjiKruzic\" />";
                tekst += "\n<circle cx=\"" + startTocke.ToString() + "\" cy=\"" + (ishodisteY - Convert.ToInt32((podatak.Podatak / faktorSkaliranja))).ToString() + "\" r=\"4\" class=\"crtaGrafVeciKruzic\" />";

                // dodaj podatak na vrh priče
                tekst += "<text x=\""+ startTocke.ToString()+"\" y=\""+ (ishodisteY - Convert.ToInt32((podatak.Podatak / faktorSkaliranja))-15).ToString()+"\" class=\"crtaGrafPodaci\">" +podatak.Podatak+"</text>";

                // dodaj labelu ispod X osi
                tekst += "\n<text x=\"" + startTocke.ToString() + "\" y=\"" + (ishodisteY + 15).ToString() 
                    + "\" class=\"crtaGrafLabele\" transform=\"rotate(-60,"+ startTocke.ToString()+","+ (ishodisteY + 15).ToString()+")\">" + podatak.Naslov + "</text>";

                startTocke += razmakPoX;
            }

                //  ideja je da najviša vrijednost bude oko 260 px iznad osi X. Iračunaj faktor skaliranja za najveću vrijednost, ako je veća od toga.
                //   faktor skaliranja je rezultat cjelobrojnog djeljenja visine i najvećeg podatka

                return tekst;
        }

        public string ispisiNaslov(string pnaslov) {
            string naslov;
            naslov ="\n<g id=\""+grafID+"_grafNaslovGrupa\">\n";
            naslov +="<text id=\"" + grafID + "_grafNaslov\" x=\"" + naslovX.ToString() + "\" y=\""+naslovY+"\" class=\"grafNaslov\">\n";
            naslov+=pnaslov;
            naslov+="</text>\n";
            naslov+="</g>\n";
            return naslov;

        }
        string nacrtajKoordinatniSustav(int pishodisteX, int pishodisteY,int duzinaXosi, int duzinaYosi) {

            string tekst;
           
            // koordinate Osi
            tekst = "\n<g id=\""+grafID+"_koordinatniSustav\" zIndex=\"6\">";

            // y - koordinatna OS
            tekst += "\n<line id=\""+grafID+"_osX\" x1=\""+pishodisteX.ToString()+"\" y1=\""+pishodisteY.ToString()
                    +"\" x2=\""+pishodisteX.ToString()+"\" y2=\""+(pishodisteY-duzinaYosi).ToString()
                    +"\" fill=\"black\" stroke=\"black\" stroke-width=\"2\" ></line>";

            // x -koordnatna OS
            tekst += "\n<line id=\"" + grafID + "_osY\" x1=\"" + pishodisteX.ToString() + "\" y1=\"" + pishodisteY.ToString()
                    + "\" x2=\"" + (pishodisteX + duzinaXosi).ToString() + "\" y2=\"" + (pishodisteY).ToString()
                    + "\" class=\"stupciKoordinatniSustav\" ></line>";

            tekst += "\n</g>";

            

            return tekst;
        }
        public override string ToString() {
            return svgStr;
        }

    }
}