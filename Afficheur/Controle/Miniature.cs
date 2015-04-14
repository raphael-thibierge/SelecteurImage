using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controle
{
    public class Miniature
    {
       



        private Image _image;
        private string _chemmin;
        private Point _position;
        private Rectangle _rectangle;

        public Rectangle Rectangle
        {
            get { return _rectangle; }
            set { _rectangle = value; }
        }


        public Miniature(Image image, String chemin, int x, int y)
        {
            _image = image;
            _chemmin = chemin;
            _position.X = x;
            _position.Y = y ;
            _rectangle = new Rectangle(_position.X, _position.Y, _image.Width, _image.Height);
        }


        #region méthodes

        public bool Contient(Point point)
        {
            if (point.X > _position.X && point.X < _position.X+_image.Width
                && point.Y > _position.Y && point.Y < _position.Y + _image.Height)
            {
                return true;
            }
            return false;           
        }



        #endregion



        #region accesseurs
        public Image Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public string Chemmin
        {
            get { return _chemmin; }
            set { _chemmin = value; }
        }
        public Point Position
        {
            get { return _position; }
            set { _position = value; }
        }






        #endregion

    }
}
