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
        void AddPlayer(string name, int id);

        Player GetPlayer(int id);

        Field GetField(int id);

        void DrawBoard(Canvas canvas);

        void UpdateField(Field field, ImageBrush image);

        void Piece_OnMove(IGamePiece piece);

        void UpdateDie(Button button);

        List<Player> GetPlayers { get; }

        List<Field> GetFields { get;  }

        List<Field> GetPlayerFields(int id);

        List<Field> AddPlayerFields(GameColor color, int offset);
    }
}
