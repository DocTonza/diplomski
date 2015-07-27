using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TonzaDiplomski {
    public class Isjecak {
        /*gerenira isječak iz pite. Za svaki isječak pamtimo otkud počinje i koliki kut crtamo.
          Pomoću kuta otkrivamo koodridnate završetka kružnog isječka. Koordinate završetka su istovremeno i koordinate početka idućeg isječka
          vraća string koji generira path koji iscrtava isječak (ToString())
        */

        int centarX, centarY, polumjer;       // ovo bi trebali dobiti kao parametre
        double početniKut, završniKut;        // koji je početni kut (od kuda krećemo) i koliki je kut (točnije postotak) koji prikazuje isječak
        double x1, y1, x2, y2, xLbl, yLbl,xPolaKuta,yPolaKuta;               // početne i završne točke na kružnici (tu počinje i završava luk; računamo iz početnogKuta (x1,1) i završnogKuta (x2,y2))
        string naslovIsjecka;
        string isjecakBoja;
        string pathStr;                      // ovdje nam piše path dio koji zapravo crta isječak (<path d=...)
        double podatak;                       // ovdje piše vrijednost koju prikazujemo

        static List<Labele> prijasnjeLabele = new List<Labele>();          // tu čuvamo stare labele za usporedbu i poravnavanje


        public double PočetniKut {
            get {
                return početniKut;
            }

            set {
                početniKut = value;
            }
        }

        public double ZavršniKut {
            get {
                return završniKut;
            }

            set {
                završniKut = value;
            }
        }

        public string IsjecakBoja {
            get {
                return isjecakBoja;
            }

            set {
                isjecakBoja = value;
            }
        }

        public string NaslovIsjecka {
            get {
                return naslovIsjecka;
            }

            set {
                naslovIsjecka = value;
            }
        }

        public double Podatak {
            get {
                return podatak;
            }

            set {
                podatak = value;
            }
        }

        public Isjecak(int pcentarX, int pcentarY, int ppolumjer, double ppočetniKut, double ppodatak, double postotak, string naslov, string boja)           //konstruktor
        {
            centarX = pcentarX;
            centarY = pcentarY;
            polumjer = ppolumjer;
            završniKut = ppočetniKut + 360 * postotak / 100;
            naslovIsjecka = naslov;
            isjecakBoja = boja;
            podatak = ppodatak;

            x1 = Math.Ceiling(centarX + polumjer * Math.Cos(Math.PI * ppočetniKut / 180));
            y1 = Math.Ceiling(centarY + polumjer * Math.Sin(Math.PI * ppočetniKut / 180));

            x2 = Math.Ceiling(centarX + polumjer * Math.Cos(Math.PI * (završniKut) / 180));
            y2 = Math.Ceiling(centarY + polumjer * Math.Sin(Math.PI * (završniKut) / 180));

            // koordinate za labelu. Na polovini kuta
            xPolaKuta = Math.Ceiling(centarX + polumjer * Math.Cos(Math.PI * (ppočetniKut + ((završniKut - ppočetniKut) / 2)) / 180));
            yPolaKuta = Math.Ceiling(centarY + polumjer * Math.Sin(Math.PI * (ppočetniKut + ((završniKut - ppočetniKut) / 2)) / 180));

            //ispis samog odsječka
            pathStr = "<path d=\"M";
            pathStr += centarX.ToString() + "," + centarY.ToString();
            pathStr += " L" + x1.ToString() + "," + y1.ToString();
            pathStr += " A" + polumjer.ToString() + "," + polumjer.ToString();
            pathStr += " 0 " + ((postotak > 50) ? 1 : 0) + ",1," + x2.ToString() + "," + y2.ToString();                 //ako je kut > 180% (50%) onda srednja 0 mora biti 1 - large-arch-flag
            pathStr += " z\" style=\"stroke:#660000; fill:" + isjecakBoja + ";\" zIndex=\"6\"/>\n";

            // sad bi rado dodali i tekst za isječak

            // provjeri gdje smo u odnosu na centar pite. 
            // Ako smo iznad, pomakni labele gore, inače dolje.

            if (xPolaKuta - centarX > 0) {                              // desno od centra smo, povećaj X koordinatu.
                
                xLbl = xPolaKuta+ 5;
            }
            else {                                                      // lijevo smo od centra, smanji X koordinatu
                xLbl = xPolaKuta - 5; // (5+((postotak<5)? 20:0));
               
            }
            if (yPolaKuta - centarY > 0) {                              // ispod centra smo, povećaj Y koordinatu
                
                yLbl = yPolaKuta + 10;                                  // ovo je više zbog veličine slova; računa se donja lijeva strana teksta
            }
            else {
                yLbl = yPolaKuta - 5;// (5 + ((postotak < 5) ? 20 : 0));                                  
            }


            // ako već nešto piše u labelama, uspodedi s postojećim i popravi ako se sijeku
            if (prijasnjeLabele.Count>1) {
                if (Math.Abs(xLbl - prijasnjeLabele.Last().xLbl) < 35) {     //sijeku se po X osi
                    if (Math.Abs(yLbl - prijasnjeLabele.Last().yLbl) < 10) {
                        //sijeku se pomakni je gore ili dolje, ovisno da li si u gornjem ili donjem kvadrantu
                        xLbl = prijasnjeLabele.Last().xLbl - (xPolaKuta - centarX < 0 ? -18 : 18);                                        // 14

                        yLbl = prijasnjeLabele.Last().yLbl - (yPolaKuta - centarY > 0?-15:15);  //ako smo u gornjoj polovici, miči se prema gore, inače prema dolje
                    }

                    
                }

            }

            
            prijasnjeLabele.Add(new Labele(xLbl, yLbl));

            pathStr = pathStr + "<g transform=\"Translate(0,0)\" zIndex=\"1\">";
            //pathStr = pathStr + "<text x=\"" + x1.ToString() + "\" y=\"" + y2.ToString() + "\" fill=white >" + postotak.ToString();

            if (xPolaKuta - centarX > 0) {                              // promijeni alignment ako smo lijevo od centra
                pathStr = pathStr + "<text x=\"" + xLbl.ToString() + "\" y=\"" + yLbl.ToString() + "\" class=\"pitaPostotciTipsDesni\" >" + postotak.ToString() + "%";
            }
            else {
                pathStr = pathStr + "<text x=\"" + xLbl.ToString() + "\" y=\"" + yLbl.ToString() + "\" class=\"pitaPostotciTipsLijevi\" >" + postotak.ToString() + "%";
            }
            pathStr += "</text>\n</g>\n";

            
            // dodaj linije od xLbl i yLbl do početka texta
            pathStr+="<line x1 =\""+xPolaKuta.ToString()+"\" y1 =\""+yPolaKuta.ToString()+"\" x2 =\""+xLbl.ToString()+"\" y2 =\""+yLbl.ToString()
                    + "\" style=\"stroke:"+isjecakBoja+ "; stroke-width:2\";stroke-linecap=\"round\"/>";
        }

        void srediLabele() {

        }

        //style="stroke:rgb(255,0,0);stroke-width:2"
        public override string ToString() {
            return pathStr;
        }
    }

    public class Labele {
        double m_xLbl, m_yLbl;
        public Labele(double pxLbl, double pyLbl) {
            m_xLbl = pxLbl;
            m_yLbl = pyLbl;
        }
        public double xLbl {
            get {
                return m_xLbl;
            }
        }
        public double yLbl {
            get {
                return m_yLbl;
            }
        }
    }
}