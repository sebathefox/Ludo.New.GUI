﻿using Ludo.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Ludo.GUI.Fields
{
    class White : Field
    {
        private GameColor color;
        
        public White(int id, int posX, int posY) : base(id, posX, posY)
        {
            this.Type = FieldType.BaseField;
            this.Background = this.defaultImage = (ImageBrush) FindResource("WhiteField");

        }

        public override GameColor Color => this.color;

        public GameColor SetColor { get => this.color; set => this.color = value; }
    }
}
