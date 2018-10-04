using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ludo.Base;

namespace Ludo.GUI
{
    class BoardHandler : List<Field>
    {
        private List<Field> fields;
        public BoardHandler()
        {
            this.fields = new List<Field>();
        }

        public void DrawBoard()
        {

            for (int i = 1; i <= 72; i++)
            {

            }


            //----------- DIVIDER --------------

            //    for (int i = 1; i <= 72; i++)
            //    {
            //        if (i == 1)
            //            fields.Add(new Fields.White(i, 2 + 32 * i, 250));
            //        else if (i == 2)
            //            fields.Add(new Fields.Start(i, 2 + 32 * i, 250, GameColor.Green));
            //        else if (i <= 6)
            //            fields.Add(new Fields.White(i, 2 + 32 * i, 250));
            //        // GO UP!
            //        else if (i <= 12)
            //            if (i == 7)
            //                fields.Add(new Fields.Star(i, 226, 250 - 32 * (i - 6)));
            //            else if (i == 10)
            //                fields.Add(new Fields.Globe(i, 226, 250 - 32 * (i - 6)));
            //            else
            //                fields.Add(new Fields.White(i, 226, 250 - 32 * (i - 6)));
            //        // GO RIGHT!
            //        else if (i <= 14)
            //            if (i == 13)
            //                fields.Add(new Fields.Star(i, 226 + 32 * (i - 12), 58));
            //            else
            //                fields.Add(new Fields.White(i, 226 + 32 * (i - 12), 58));
            //        // GO DOWN!
            //        else if (i <= 19)
            //            if (i == 15)
            //                fields.Add(new Fields.Start(i, 290, 58 + 32 * (i - 14), GameColor.Yellow));
            //            else
            //                fields.Add(new Fields.White(i, 290, 58 + 32 * (i - 14)));
            //        // GO RIGHT!
            //        else if (i <= 25)
            //            if (i == 20)
            //                fields.Add(new Fields.Star(i, 290 + 32 * (i - 19), 250));
            //            else if (i == 23)
            //                fields.Add(new Fields.Globe(i, 290 + 32 * (i - 19), 250));
            //            else
            //                fields.Add(new Fields.White(i, 290 + 32 * (i - 19), 250));
            //        // GO DOWN!
            //        else if (i <= 27)
            //            if (i == 26)
            //                fields.Add(new Fields.Star(i, 482, 250 + 32 * (i - 25)));
            //            else
            //                fields.Add(new Fields.White(i, 482, 250 + 32 * (i - 25)));
            //        // GO LEFT!
            //        else if (i <= 32)
            //            if (i == 28)
            //                fields.Add(new Fields.Start(i, 482 - 32 * (i - 27), 314, GameColor.Blue));
            //            else
            //                fields.Add(new Fields.White(i, 482 - 32 * (i - 27), 314));
            //        // GO DOWN!
            //        else if (i <= 38)
            //            if (i == 33)
            //                fields.Add(new Fields.Star(i, 290, 314 + 32 * (i - 32)));
            //            else if (i == 36)
            //                fields.Add(new Fields.Globe(i, 290, 314 + 32 * (i - 32)));
            //            else
            //                fields.Add(new Fields.White(i, 290, 314 + 32 * (i - 32)));
            //        // GO LEFT!
            //        else if (i <= 40)
            //            if (i == 39)
            //                fields.Add(new Fields.Star(i, 290 - 32 * (i - 38), 506));
            //            else
            //                fields.Add(new Fields.White(i, 290 - 32 * (i - 38), 506));
            //        // GO UP!
            //        else if (i <= 45)
            //            if (i == 41)
            //                fields.Add(new Fields.Start(i, 226, 506 - 32 * (i - 40), GameColor.Red));
            //            else
            //                fields.Add(new Fields.White(i, 226, 506 - 32 * (i - 40)));
            //        // GO LEFT!
            //        else if (i <= 51)
            //            if (i == 46)
            //                fields.Add(new Fields.Star(i, 226 - 32 * (i - 45), 314));
            //            else if (i == 49)
            //                fields.Add(new Fields.Globe(i, 226 - 32 * (i - 45), 314));
            //            else
            //                fields.Add(new Fields.White(i, 226 - 32 * (i - 45), 314));
            //        // GO UP!
            //        else if (i == 52)
            //            fields.Add(new Fields.Star(i, 34, 282));

            //        // Add green safe fields
            //        else if (i <= 57)
            //            fields.Add(new Fields.Safe(i, 34 + 32 * (i - 52), 282, GameColor.Green));

            //        // Add yellow safe fields
            //        else if (i <= 62)
            //            fields.Add(new Fields.Safe(i, 258, 58 + 32 * (i - 57), GameColor.Yellow));

            //        // Add red safe fields
            //        else if (i <= 67)
            //            fields.Add(new Fields.Safe(i, 290 + 32 * (i - 62), 282, GameColor.Blue));

            //        // Add blue safe fields
            //        else if (i <= 72)
            //            fields.Add(new Fields.Safe(i, 258, 506 - 32 * (i - 67), GameColor.Red));
            //    }
            //    // Gets the startfields and adds them to a variable
            //    startFields = fields.Where(field => field.Type == FieldType.StartField).ToArray();
            //}
        }
    }
}
