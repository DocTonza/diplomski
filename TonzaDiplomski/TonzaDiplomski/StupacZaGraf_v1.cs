using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TonzaDiplomski {
    public class StupacZaGraf_v1 : IStupacZaGraf {
        int posX;
        int posY;
        int sirina;
        int visina;
        string bojaStupca;
        string naslovStupca;
        double podatakStupca;

        string stupacStr;           //tu smo kreirali cijeli stupac

        public int PosX {
            get {
                return posX;
            }

            set {
                posX = value;
            }
        }

        public int PosY {
            get {
                return posY;
            }

            set {
                posY = value;
            }
        }

        public int Sirina {
            get {
                return sirina;
            }

            set {
                sirina = value;
            }
        }

        public int Visina {
            get {
                return visina;
            }

            set {
                visina = value;
            }
        }

        public string BojaStupca {
            get {
                return bojaStupca;
            }

            set {
                bojaStupca = value;
            }
        }

        public string NaslovStupca {
            get {
                return naslovStupca;
            }

            set {
                naslovStupca = value;
            }
        }

        public double PodatakStupca {
            get {
                return podatakStupca;
            }

            set {
                podatakStupca = value;
            }
        }
        
        
        // konstruktor
        public StupacZaGraf_v1(int predniBroj, string pgrafID, int pposX,int pposY,int psirina, int pvisina, string pbojaStupca, string pnaslovStupca, double ppodatakStupca) {
            posX = pposX;
            posY = pposY;
            sirina = psirina;
            visina = pvisina;
            bojaStupca = pbojaStupca;
            naslovStupca = pnaslovStupca;
            podatakStupca = ppodatakStupca;
            

            //privatne
            int duzinaLinijeNaslova = 25;
            string stupacID=pgrafID+"_stupac_"+predniBroj;
            string stupacLabelaGrupaID = pgrafID + "_stupacLabelaGrupa_" + predniBroj;
            string stupacLabelaID= pgrafID + "_stupacLabelaTekst_" + predniBroj;
            string stupacLabelaLinijaID = pgrafID + "_stupacLabelaLinija_" + predniBroj;

            //stupac
            stupacStr = "<rect id=\""+stupacID+"\" x=\""+posX.ToString()+"\" y=\""+(posY- visina).ToString()+"\" height=\""+(visina-2).ToString()+"\" width=\""+sirina.ToString()+ "\" fill=\"" + bojaStupca + "\"/>";

            //naslov stupca i linija, zarotirani
            stupacStr += "\n<g id=\""+stupacLabelaGrupaID+ "\" transform=\"rotate(10,"+(posX + (sirina) / 2).ToString() + "," + (posY - visina).ToString() + ")\">";

            //linija
            stupacStr += "\n<line id=\""+stupacLabelaLinijaID+"\" x1=\"" + (posX+(sirina) / 2).ToString() + "\" y1=\"" + (posY - visina).ToString()
                      + "\" x2=\"" + (posX + (sirina) / 2).ToString() + "\" y2=\"" + (posY - visina - duzinaLinijeNaslova).ToString()
                      + "\" fill=\"black\" stroke=\"black\" stroke-width=\"1\"/>";

            // text
            stupacStr += "\n<text id=\""+stupacLabelaID+"\" x=\""+ (posX + (sirina) / 2).ToString() +"\" y=\"" + (posY - visina - duzinaLinijeNaslova).ToString() 
                        + "\" transform=\"rotate(-90,"+ (posX + (sirina) / 2).ToString()+"," + (posY - visina - duzinaLinijeNaslova-4).ToString()+")\" class=\"stupciNaslov\">"
                        +pnaslovStupca+" ("+ppodatakStupca+")</text>";
            stupacStr += "\n</g>\n";

        }


        // transform="rotate(-90,20,150)"
        public override string ToString() {
            return stupacStr;
        }
    }
}