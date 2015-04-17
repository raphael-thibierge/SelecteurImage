using Controle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Afficheur
{
    public partial class Afficheur : Form
    {
        private Image _imagePrincipale;

        public Afficheur()
        {
            _imagePrincipale = null;
            InitializeComponent();
        }

        private void ouvrirFichier_Click(object sender, EventArgs e)
        {
            //initialisation des images du selecteur
            FolderBrowserDialog explorateurDeFichier = new FolderBrowserDialog();
            explorateurDeFichier.RootFolder = Environment.SpecialFolder.Desktop;
            if (explorateurDeFichier.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string cheminDossier = explorateurDeFichier.SelectedPath;
                selecteurImage.init(cheminDossier);
                Refresh();
            }
            
        }


        private void AffichageGrandeImage(object sender, PaintEventArgs e)
        {
            if (_imagePrincipale != null)
            {
                
                int largeurImage = (_imagePrincipale.Width * splitContainer2.Panel2.Height) / _imagePrincipale.Height;
                Image i = _imagePrincipale.GetThumbnailImage(largeurImage, splitContainer2.Panel2.Height, null, IntPtr.Zero);
                e.Graphics.DrawImage(i, new Point(0, 0));
            }
        }

        private void MiseAJourPropiétés(string cheminImage)
        {
            _imagePrincipale = Image.FromFile(cheminImage);
            BoitePropriété.SelectedObject = _imagePrincipale;
            Refresh();
            
        }

        private void selecteurImage_selectionMiniature(object sender, Selecteur.SelectionMiniature e)
        {
            MiseAJourPropiétés(e.miniature.Chemmin);

        }

        private void selecteurImage_Load(object sender, EventArgs e)
        {

        }

        private void FafraichirTailleSelecteur(object sender, EventArgs e)
        {
            
        }

        private void BoutonDiaporama_Click(object sender, EventArgs e)
        {

            if (selecteurImage.ListeMiniatures.Count > 0)
            {
                Timer timer = new Timer();
                timer.Interval = 2000;
                foreach (Miniature miniature in selecteurImage.ListeMiniatures)
                {
                    MiseAJourPropiétés(miniature.Chemmin);

                }
            }
        }

    }
}
