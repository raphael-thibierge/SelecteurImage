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
        public Afficheur()
        {
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
            }
        }
    }
}
