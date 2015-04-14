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
        private Image _imagePrincipale ;
        string _cheminImage;
        Image _grandeImage;

        public Afficheur()
        {
            _imagePrincipale = null;

            InitializeComponent();
            _cheminImage = null;
            _grandeImage = null;
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

        private void selecteurImage_MouseDown(object sender, MouseEventArgs e)
        {
           _cheminImage = selecteurImage.CheminMiniature;
           MiseAJourPropiétés();
           Refresh();
        }

        private void AffichageGrandeImage(object sender, PaintEventArgs e)
        {
            if (_cheminImage != null)
            {
                _grandeImage = Image.FromFile(_cheminImage);
                int largeurImage = (_grandeImage.Width * splitContainer2.Panel2.Height) / _grandeImage.Height;
                Image i = _grandeImage.GetThumbnailImage(largeurImage, splitContainer2.Panel2.Height, null, IntPtr.Zero);
                e.Graphics.DrawImage(i, new Point(0, 0));
            }
        }

        private void MiseAJourPropiétés()
        {
            if (_grandeImage != null)
            {
                BoitePropriété.SelectedObject = _grandeImage;
            }
        }


    }
}
