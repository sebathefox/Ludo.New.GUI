using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Fields
{
    class Start : Field
    {
        private readonly GameColor color;
        public Start(int id, int posX, int posY, GameColor color) : base(id, posX, posY)
        {
            this.Type = FieldType.StartField;
            this.color = color;
            GetImage();
        }

        private void GetImage()
        {
            switch (this.color)
            {
                case GameColor.Green:
                    this.Background = this.defaultImage = (ImageBrush)FindResource("GreenGlobe");
                    break;
                case GameColor.Yellow:
                    this.Background = this.defaultImage = (ImageBrush)FindResource("YellowGlobe");
                    break;
                case GameColor.Blue:
                    this.Background = this.defaultImage = (ImageBrush)FindResource("BlueGlobe");
                    break;
                case GameColor.Red:
                    this.Background = this.defaultImage = (ImageBrush)FindResource("RedGlobe");
                    break;
                default:
                    throw new Exception("Unknown Error.");
            }
        }

        public override GameColor Color => this.color;

        //TODO Make this class the startfield for the pieces
    }
}
