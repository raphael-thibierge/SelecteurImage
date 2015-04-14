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
    public class SelectionMiniature : EventArgs
    {
        public Miniature miniature;
        public SelectionMiniature(Miniature m)
        {
            miniature = m;
        }
    }
        

        


    public partial class Selecteur : UserControl
    {
        List<Miniature> _listeMiniatures;
        int _largeurDefaultMiniature;
        int _hauteurDefaultMiniature;
        int _largeur;

        Point _origine;

        Selection _selection;

     



       
        public delegate void SelectionMini(object sender, SelectionMiniature e);

        public event SelectionMini selectionMiniature;

        public string CheminMiniature
        {
            get { return _selection.CheminImage; }
        }

           public Selecteur()
        {
            InitializeComponent();
            _listeMiniatures = new List<Miniature>();
            _hauteurDefaultMiniature = this.Height-barreDéfilement.Height;
            _largeurDefaultMiniature = _hauteurDefaultMiniature;
            _origine = new Point(0, 0);

            // barre de défilement
            barreDéfilement.Maximum = 0;
            barreDéfilement.LargeChange = 1;
            barreDéfilement.SmallChange = 0;

            // rectangle de selection (j'ai bien envie d'en faire une classe)
            _selection = null;
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
                    int largeurImage = (image.Width * _hauteurDefaultMiniature) / image.Height;
                    Image i = image.GetThumbnailImage(largeurImage, _hauteurDefaultMiniature, null, IntPtr.Zero);
                    _listeMiniatures.Add(new Miniature(i, nomDuFichier, largeur, 0));
                    largeur += largeurImage;
                    

                }
            }
            // Mise à jour de la barre de défilement
            if (_listeMiniatures.Count > 0)
            {
                barreDéfilement.Maximum = largeur;
                barreDéfilement.LargeChange = _largeurDefaultMiniature;
                barreDéfilement.SmallChange = _largeurDefaultMiniature;
            }
        }

        private void Selecteur_Paint(object sender, PaintEventArgs e)
        {
            if (_listeMiniatures.Count() > 0)
            {  
                int cpt = 0 ;
                foreach (Miniature miniature in _listeMiniatures)
                {
                    e.Graphics.DrawImage(miniature.Image, new Point(miniature.Position.X+_origine.X, miniature.Position.Y+_origine.Y));
                    cpt++;
                }
            }

            // dessin du rectangle de sélection
            if (_selection != null)
            {
                e.Graphics.DrawRectangle(_selection.Pinceau, _selection.Rect.X+_origine.X, 0+_origine.Y, _selection.Rect.Width, _selection.Rect.Height);
            }
           
        }




        private void défilement(object sender, ScrollEventArgs e)
        {
            switch (e.Type)
            {
                case ScrollEventType.EndScroll :
                    _origine.X = -e.NewValue;
                    break;

                case ScrollEventType.ThumbTrack :
                    _origine.X = -e.NewValue;
                    break;
            }
            Refresh();
        }

        private void Selecteur_MouseDown(object sender, MouseEventArgs e)
        {
            if (_listeMiniatures.Count > 0)
            {
                int positionX = e.Location.X - _origine.X;
                positionX -= positionX % _largeurDefaultMiniature;
                if (trouverMiniature(e.Location) != null){
                    Miniature m = trouverMiniature(e.Location);
                    _selection = new Selection(m);
                    if (selectionMiniature != null)
                    {
                        selectionMiniature(this, new SelectionMiniature(m));
                    }
                }
            }
            Refresh();
        }

        Miniature trouverMiniature(Point p)
        {
            foreach (Miniature miniature in _listeMiniatures)
            {
                if (miniature.Contient(new Point(p.X-_origine.X, p.Y-_origine.Y)))
                {
                    return miniature;
                }
            }
            return null;
        }
    }
}
