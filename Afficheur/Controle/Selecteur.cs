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

        List<String> _listeCheminImages;
        List<Image> _listeMiniatures;
        int largeurDefaultMiniature;
        int hauteurDefaultMiniature;
        Point origine;

        Selection selection;

           public Selecteur()
        {
            InitializeComponent();
            _listeCheminImages = new List<String>();
            _listeMiniatures = new List<Image>();
            hauteurDefaultMiniature = this.Height-barreDéfilement.Height;
            largeurDefaultMiniature = hauteurDefaultMiniature;
            origine = new Point(0, 0);

            // barre de défilement
            barreDéfilement.Maximum = 0;
            barreDéfilement.LargeChange = 1;
            barreDéfilement.SmallChange = 0;

            // rectangle de selection (j'ai bien envie d'en faire une classe)
            selection = null;
        }

        //initialise toutes les images en fonction du chemin
        public void init(string cheminDossier){
            if (_listeMiniatures.Count > 0)
                _listeMiniatures.Clear();

            if (_listeCheminImages.Count > 0)
                _listeCheminImages.Clear();


            // Pour chaques fichiers trouvées dans le répertoire
            foreach (string nomDuFichier in System.IO.Directory.GetFiles(cheminDossier))
            {
                // type d'images gérées
                if (System.IO.Path.GetExtension(nomDuFichier) == ".jpeg"
                    || System.IO.Path.GetExtension(nomDuFichier) == ".jpg"
                    || System.IO.Path.GetExtension(nomDuFichier) == ".png"
                    || System.IO.Path.GetExtension(nomDuFichier) == ".bmp"
                    )
                {
                    // on ajoute le chemin de l'image dans la liste d'image
                    _listeCheminImages.Add(nomDuFichier);

                    Image image = Image.FromFile(nomDuFichier);
                    _listeMiniatures.Add(image.GetThumbnailImage(largeurDefaultMiniature, hauteurDefaultMiniature, null, IntPtr.Zero));

                }
            }
            // Mise à jour de la barre de défilement
            if (_listeMiniatures.Count > 0)
            {
                barreDéfilement.Maximum = (_listeMiniatures.Count()+1) * largeurDefaultMiniature - this.Width;
                barreDéfilement.LargeChange = largeurDefaultMiniature;
                barreDéfilement.SmallChange = largeurDefaultMiniature;
            }
        }

        private void Selecteur_Paint(object sender, PaintEventArgs e)
        {
            if (_listeCheminImages.Count > 0)
            {  
                int cpt = 0 ;
                foreach (Image image in _listeMiniatures)
                {
                    e.Graphics.DrawImage(image, new Point(largeurDefaultMiniature*cpt+origine.X, 0+origine.Y));
                    cpt++;
                }
            }

            if (selection != null)
            {
                e.Graphics.DrawRectangle(selection.Pinceau, selection.Rect.X+origine.X, 0+origine.Y, selection.Rect.Width, selection.Rect.Height);
                
            }
           
        }

        //permet de redimensionner une image en fonction de la hauteur du panel
        public void redimensionnerImage(Image image)
        {

        }

        private void défilement(object sender, ScrollEventArgs e)
        {
       
            switch (e.Type)
            {
                case ScrollEventType.EndScroll :
                    origine.X = -e.NewValue;
                    break;

                case ScrollEventType.ThumbTrack :
                    origine.X = -e.NewValue;
                    break;
            }
            Refresh();
        }

        private void Selecteur_MouseDown(object sender, MouseEventArgs e)
        {
            if (_listeMiniatures.Count > 0)
            {
                int positionX = e.Location.X - origine.X;
                positionX -= positionX % largeurDefaultMiniature;
                selection = new Selection(new Rectangle(positionX, 0, largeurDefaultMiniature, hauteurDefaultMiniature), "ahah");
            }
            Refresh();
        }

    }
}
