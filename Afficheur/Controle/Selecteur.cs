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
        List<Miniature> _listeMiniatures;
        int largeurDefaultMiniature;
        int hauteurDefaultMiniature;
        int largeur;

        Point origine;

        Selection selection;

           public Selecteur()
        {
            InitializeComponent();
            _listeMiniatures = new List<Miniature>();
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

            // Pour chaques fichiers trouvées dans le répertoire
            int largeur = 0;
            foreach (string nomDuFichier in System.IO.Directory.GetFiles(cheminDossier))
            {
                // type d'images gérées
                if (System.IO.Path.GetExtension(nomDuFichier) == ".jpeg"
                    || System.IO.Path.GetExtension(nomDuFichier) == ".jpg"
                    || System.IO.Path.GetExtension(nomDuFichier) == ".png"
                    || System.IO.Path.GetExtension(nomDuFichier) == ".bmp"
                    )
                {
                    

                    Image image = Image.FromFile(nomDuFichier);
                    int largeurImage = (image.Width * hauteurDefaultMiniature) / image.Height;
                    Image i = image.GetThumbnailImage(largeurImage, hauteurDefaultMiniature, null, IntPtr.Zero);
                    _listeMiniatures.Add(new Miniature(i, nomDuFichier, largeur, 0));
                    largeur += largeurImage;
                    

                }
            }
            // Mise à jour de la barre de défilement
            if (_listeMiniatures.Count > 0)
            {
                barreDéfilement.Maximum = largeur;
                barreDéfilement.LargeChange = largeurDefaultMiniature;
                barreDéfilement.SmallChange = largeurDefaultMiniature;
            }
        }

        private void Selecteur_Paint(object sender, PaintEventArgs e)
        {
            if (_listeMiniatures.Count() > 0)
            {  
                int cpt = 0 ;
                foreach (Miniature miniature in _listeMiniatures)
                {
                    e.Graphics.DrawImage(miniature.Image, new Point(miniature.Position.X+origine.X, miniature.Position.Y+origine.Y));
                    cpt++;
                }
            }

            // dessin du rectangle de sélection
            if (selection != null)
            {
                e.Graphics.DrawRectangle(selection.Pinceau, selection.Rect.X+origine.X, 0+origine.Y, selection.Rect.Width, selection.Rect.Height);
            }
           
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
                if (trouverMiniature(e.Location) != null){
                    selection = new Selection(trouverMiniature(e.Location));
                }
            }
            Refresh();
        }

        Miniature trouverMiniature(Point p)
        {
            foreach (Miniature miniature in _listeMiniatures)
            {
                if (miniature.Contient(new Point(p.X-origine.X, p.Y-origine.Y)))
                {
                    return miniature;   
                }
            }
            return null;
        }

    }
}
