using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Fields
{
    class Home : Field
    {
        private readonly GameColor color;
        public Home(int id, int posX, int posY, GameColor color) : base(id, posX, posY)
        {
            this.Type = FieldType.HomeField;
            this.color = color;
            GetImage();
            
        }

        private void GetImage()
        {
            switch (this.color)
            {
                case GameColor.Green:
                    this.Background = this.defaultImage = (ImageBrush)FindResource("GreenPiece");
                    break;
                case GameColor.Yellow:
                    this.Background = this.defaultImage = (ImageBrush)FindResource("YellowPiece");
                    break;
                case GameColor.Blue:
                    this.Background = this.defaultImage = (ImageBrush)FindResource("BluePiece");
                    break;
                case GameColor.Red:
                    this.Background = this.defaultImage = (ImageBrush)FindResource("RedPiece");
                    break;
                default:
                    throw new Exception("Unknown Error.");
            }
        }

        public override GameColor Color => this.color;
    }
}
