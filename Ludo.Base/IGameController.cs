using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ludo.Base
{
    public interface IGameController : IGameMovement
    {
        /// <summary>
        /// Adds a new player to the controller
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="id">The id of the player</param>
        void AddPlayer(string name, int id);

        /// <summary>
        /// Gets the id of the player at the specified index
        /// </summary>
        /// <param name="id">the specified index</param>
        /// <returns>The player object at the index</returns>
        Player GetPlayer(int id);

        /// <summary>
        /// Draws the board on the screen
        /// </summary>
        /// <param name="canvas">The canvas object to draw the board on</param>
        void DrawBoard(Canvas canvas);

        /// <summary>
        /// Updates the image of a field
        /// </summary>
        /// <param name="field">The field to update</param>
        /// <param name="image">The image to set as background</param>
        void UpdateField(Field field, ImageBrush image);

        /// <summary>
        /// Updates the dice's graphics
        /// </summary>
        /// <param name="button">The button object that is acting as the die</param>
        void UpdateDie(Button button);

        /// <summary>
        /// Adds the player's homefields
        /// </summary>
        /// <param name="color">The color of the fields</param>
        /// <param name="offset">The offset of the playerfields</param>
        /// <returns></returns>
        List<Field> AddPlayerFields(GameColor color, int offset);
    }
}
