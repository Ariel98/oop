using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_по_ООП
{
    class Game
    {
        private Player _player;

        private StaticGameObject[] _staticObjects;

        private Item[] _items;

        int G = 20;
        int Force;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public Game()
        {
            // TODO: здесь будет инициализация переменных - герой, предметы, препятствия, монстры
        }

        public void HandleKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.Left:
                    Move(Direction.Left);
                    // Бег влево
                    break;
                case Keys.Right:
                    // Бег вправо
                    break;
                case Keys.Space:
                    // Прыжок
                    break;
                default:

                    break;
            }
            // Проверить, попал ли герой после движения на предмет
            // Если да - подобрать

        }

        /// <summary>
        /// Инициализировать конкретно собираемые предметы.
        /// </summary>
        private void InitializeItems()
        {

        }

        private void Move(Direction direction)
        {
            _player.Move(direction);
        }
    }
}