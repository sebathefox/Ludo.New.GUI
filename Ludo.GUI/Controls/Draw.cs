using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Controls
{
    public static class Draw
    {

        public static object GetPieceImage(Field field)
        {
            switch (field.Color)
            {
                case GameColor.Green:
                    return (ImageBrush)field.FindResource("GreenPiece");
                case GameColor.Yellow:
                    return (ImageBrush)field.FindResource("YellowPiece");
                case GameColor.Blue:
                    return (ImageBrush)field.FindResource("BluePiece");
                case GameColor.Red:
                    return (ImageBrush)field.FindResource("RedPiece");
                default:
                    throw new Exception("Could not find the image of the piece.");
            }
        }

        public static object GetFieldImage(Field field)
        {
            switch (field.Color)
            {
                case GameColor.Green:
                    return (ImageBrush)field.FindResource("GreenField");
                case GameColor.Yellow:
                    return (ImageBrush)field.FindResource("YellowField");
                case GameColor.Blue:
                    return (ImageBrush)field.FindResource("BlueField");
                case GameColor.Red:
                    return (ImageBrush)field.FindResource("RedField");
                case GameColor.White:
                    return (ImageBrush)field.FindResource("WhiteField");
                default:
                    throw new Exception("Unknown Error.");
            }
        }

        public static object GetSpecialFieldImage(Field field)
        {
            switch (field.Type)
            {
                case FieldType.GlobeField:
                    return (ImageBrush)field.FindResource("GlobeField");
                case FieldType.HomeField:
                    return GetPieceImage(field);
                case FieldType.SafeField:
                    return GetFieldImage(field);
                case FieldType.StarField:
                    return (ImageBrush)field.FindResource("StarField");
                case FieldType.StartField:
                    return GetStartGlobe(field);
                default:
                    throw new Exception("Unknown Error.");
            }
        }

        private static object GetStartGlobe(Field field)
        {
            switch(field.Color)
            {
                case GameColor.Green:
                    return (ImageBrush)field.FindResource("GreenGlobe");
                case GameColor.Yellow:
                    return (ImageBrush)field.FindResource("YellowGlobe");
                case GameColor.Blue:
                    return (ImageBrush)field.FindResource("BlueGlobe");
                case GameColor.Red:
                    return (ImageBrush)field.FindResource("RedGlobe");
                case GameColor.White:
                    return (ImageBrush)field.FindResource("WhiteGlobe");
                default:
                    throw new Exception("Unknown Error.");
            }
        }
    }
}
