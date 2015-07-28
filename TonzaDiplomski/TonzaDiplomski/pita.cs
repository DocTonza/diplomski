using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TonzaDiplomski {
    public class PitaGraf {
        string[] boje = new string[20]
                        { "#48FB8E", "#FB8E48", "#8EFB48", "#488EFB", "#FB488E", "#8E8E48", "#8E8EFB", "#48488E", "#4848FB", "#FBFB8E"
                        , "#FBFB48", "#8E488E", "#8EFB8E", "#488E48", "#48FB48", "#FB8EFB", "#FB48FB", "#8E8E8E", "#484848", "#FBFBFB" };



        double početniKut = 270;              //odakle počinjemo sa slaganjem pite. najčešće od 270 stupnjeva (-90)
        int maxIsjecaka = 14;               // prikazujemo n-1 isjecaka i ostali
        string svgStrPočetak, svgStrKraj;
        int sirina, visina, centarX, centarY, polumjer, naslovX, naslovY, naslovSize, legendaX, legendaY;
        StringBuilder cijelaPita = new StringBuilder();

        List<Isjecak> isječci = new List<Isjecak>();         //lista u kojoj cuvamo sve isjecke, te iz nje crtamo pitu i legendu
        double sumaPodataka;

        public PitaGraf(string naslovPite, List<PodatakZaGraf> ulazniPodaci)                                               // konstruktor
        {

            sirina = 460;
            visina = 350;
            centarX = 160;
            centarY = 190;
            polumjer = 120;


            //naslovX = centarX - polumjer;                         //ovaj koristimo ako ide naslov od početka pite
            naslovX = centarX;                                      //ovaj koristimo ako želimo da se naslov poravnava po središtu pite.
            naslovSize = 16;

            legendaX = centarX + polumjer + 50;
            legendaY = centarY - polumjer - 35;

            svgStrPočetak = "<svg width = \"" + sirina.ToString() + "\" height = \"" + visina.ToString() + "\"class=\"pitaSVG\">";
            svgStrKraj = "</svg>";

            //int i = 0;

            // sortiraj listu silazno
            ulazniPodaci.Sort((y, x) => x.Podatak.CompareTo(y.Podatak));

            // zbroji sve podatke jer nam treba suma zbog postotk
            foreach (PodatakZaGraf podatak in ulazniPodaci) {
                sumaPodataka += podatak.Podatak;
            }

            //generiraj isječke za graf
            double ostatakSumaPodataka = 0;
            if (ulazniPodaci.Count <= maxIsjecaka) {
                foreach (PodatakZaGraf podatak in ulazniPodaci) {
                    isječci.Add(new Isjecak(centarX, centarY, polumjer, početniKut, podatak.Podatak, Math.Round(podatak.Podatak / sumaPodataka * 100, 2), podatak.Naslov, boje[ulazniPodaci.IndexOf(podatak)]));
                    početniKut = isječci.Last().ZavršniKut;                //  ++i;
                }
            }else {
                int i = 1;
                foreach (PodatakZaGraf podatak in ulazniPodaci) {
                    
                    if (i < maxIsjecaka) {     //ove sad stavljamo u ostalo
                        isječci.Add(new Isjecak(centarX, centarY, polumjer, početniKut, podatak.Podatak, Math.Round(podatak.Podatak / sumaPodataka * 100, 2), podatak.Naslov, boje[ulazniPodaci.IndexOf(podatak)]));
                        početniKut = isječci.Last().ZavršniKut;
                    }
                    else {
                        ostatakSumaPodataka += podatak.Podatak;
                        
                    }
                     ++i;   
                }

                // ako je bilo ostatka, zapiši ga
                if (ostatakSumaPodataka>0)
                    isječci.Add(new Isjecak(centarX, centarY, polumjer, početniKut, ostatakSumaPodataka, Math.Round(ostatakSumaPodataka / sumaPodataka * 100, 2), "Ostatak", "#FFFFFF"));
            }


            //tu za sada punimo na ruke, ali ideja je da pošaljemo podatke koje smo pročitali iz baze
            //isječci.Add(new Isjecak(centarX, centarY, polumjer, početniKut, 45,"Naslov1",boje[0]));
            //isječci.Add(new Isjecak(centarX, centarY, polumjer, isječci[0].ZavršniKut, 38, "Naslov 2", boje[1]));
            //isječci.Add(new Isjecak(centarX, centarY, polumjer, isječci[1].ZavršniKut, 15, "Naslov 3", boje[2]));
            //isječci.Add(new Isjecak(centarX, centarY, polumjer, isječci[2].ZavršniKut, 2, "Naslov4", boje[3]));

            //iscrtavanje pite
            cijelaPita.Append(svgStrPočetak);

            //daj nam naslov  -- ovo treba biti parametrizirano
            ispisiNaslov(naslovPite);

            foreach (Isjecak isječak in isječci) {
                cijelaPita.Append(isječak.ToString());
            }
            // nacrtaj legendu
            nacrtajLegendu();

            // kraj za svg
            cijelaPita.Append(svgStrKraj);
        }

        public void ispisiNaslov(string pnaslov) {
            StringBuilder naslov = new StringBuilder();
            naslov.Append("<g>\n");
            //naslov.Append("<text x=\""+naslovX.ToString()+"\" y=\"20\" style=\"fill:white;font-size:"+naslovSize.ToString()+";font-weight:bold;\">\n");
            naslov.Append("<text x=\"" + naslovX.ToString() + "\" y=\"20\" class=\"grafNaslov\">\n");
            naslov.Append(pnaslov);
            naslov.Append("</text>\n");
            naslov.Append("</g>\n");
            cijelaPita.Append(naslov);

        }

        public void nacrtajLegendu() {
            string legenda = "";

            int stranicaKvadratica = 15;
            int pomakY = 20;
            int pocetakX = legendaX;
            int pocetakY = legendaY;
            foreach (Isjecak isjecak in isječci) {
                legenda += "<g>\n";
                legenda += "<path d=\"M" + pocetakX.ToString() + " " + pocetakY.ToString();                                                //pocetne koordinate za legendu
                legenda += " L" + (pocetakX + stranicaKvadratica).ToString() + " " + pocetakY.ToString();                                //gore desno
                legenda += " L" + (pocetakX + stranicaKvadratica).ToString() + " " + (pocetakY + stranicaKvadratica).ToString();   //dolje desno
                legenda += " L" + pocetakX.ToString() + " " + (pocetakY + stranicaKvadratica).ToString();                          //dolje lijevo
                legenda += " Z\"";
                legenda += " style=\"fill:" + isjecak.IsjecakBoja + ";\">";
                legenda += "</path>\n";
                legenda += "<text x=\"" + (pocetakX + 25).ToString() + "\" y=\"" + (pocetakY + 13).ToString() + "\" class=\"pitaLegenda\" >";

                legenda += isjecak.NaslovIsjecka.PadRight(10, ' ');
                //legenda += isjecak.Podatak;

                legenda += "</text>\n";
                legenda += "<text x=\"" + (pocetakX + 145).ToString() + "\" y=\"" + (pocetakY + 13).ToString() + "\" class=\"pitaLegendaDesno\" >";
                legenda += isjecak.Podatak;
                legenda += "</text>\n";
                legenda += "</g>\n";
                pocetakY += pomakY;
            }

            cijelaPita.Append(legenda);
            /*

                <path d="M350 50 L370 50 L370 70 L350 70 Z" style="fill:red"></path>
                <text x="375" y="65">Prvi item</text>    

        */
        }

        public override string ToString() {
            return cijelaPita.ToString();
        }

    }


}