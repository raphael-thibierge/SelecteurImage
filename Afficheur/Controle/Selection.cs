using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle
{
    class Selection
    {
        Rectangle _rectangle;
        Image _miniature;
        String _cheminImage;
        Pen _pinceau;

      

        public Selection(Rectangle rectangle, string cheminImage )
        {
            int epaisseur = 2;
            _pinceau = new Pen(Color.Red, epaisseur);
            _cheminImage = cheminImage;
            _rectangle = rectangle;
        }

        public Selection(Miniature miniature)
        {
            int epaisseur = 2;
            _pinceau = new Pen(Color.Red, epaisseur);
            _cheminImage = miniature.Chemmin;
            _rectangle = miniature.Rectangle;
        }


        #region Accesseurs

        public Rectangle Rect
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }

        public Image Image
        {
            get { return _miniature; }
            set { _miniature = value; }
        }

        public String CheminImage
        {
            get { return _cheminImage; }
            set { _cheminImage = value; }
        }

        public Pen Pinceau
        {
            get { return _pinceau; }
            set { _pinceau = value; }
        }

        #endregion



    }
}
