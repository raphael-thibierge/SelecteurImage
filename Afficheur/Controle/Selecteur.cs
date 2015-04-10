using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controle
{
    public partial class Selecteur : UserControl
    {

        List<Image> _listeImages;

        public Selecteur()
        {
            InitializeComponent();
            _listeImages = new List<Image>();
        }

        //initialise toutes les images en fonction du chemin
        public void init(string cheminDossier){
            Console.WriteLine(cheminDossier);
            
        }

        private void Selecteur_Paint(object sender, PaintEventArgs e)
        {
            
        }

        //permet de redimensionner une image en fonction de la hauteur du panel
        public void redimensionnerImage(Image image)
        {

        }
    }
}
