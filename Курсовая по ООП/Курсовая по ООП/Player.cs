using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовая_по_ООП
{
    enum Direction
    {
        Left,
        Right
    }

    enum VerticalPosition
    {
        Stand,
        Jump
    }

    // TODO: каждый класс в отдельный файл
    abstract class GameObject
    {
        protected Image[] _images;

        protected Image _image;

        public PictureBox PictureBox { get; set; }

        public Point Position;
    }

    abstract class MovableObject : GameObject
    {
        public Direction Direction { get; set; }

        public virtual void Move(Direction direction)
        {
            Direction = direction;
        }
    }

    abstract class StaticGameObject: GameObject
    {
        public virtual void Interruct()
        {
            // TODO: взаимодействие с пользователем
        }
    }

    class Door : StaticGameObject
    {

    }

    class Obstacle : StaticGameObject
    {

    }

    abstract class Item : StaticGameObject
    {
        public override void Interruct()
        {
            // TODO: скрыть предмет
        }
    }

    class Coin : Item
    {
        public Coin()
        {
            // TODO: добавить загрузку картинки в конструкторы наследников Item
            _image = Image.FromFile("");
        }
    }

    class Key : Item
    {

    }

    interface ICanJump
    {
        VerticalPosition VerticalPosition { get; set; }

        void Jump();
    }

    /// <summary>
    /// 
    /// </summary>
    class Player : MovableObject, ICanJump
    {
        public Player()
        {
            // TODO: загрузить в _images все картинки персонажа
            _image = Image.FromFile("stand_png.png");
        }

        public VerticalPosition VerticalPosition { get; set; }

        public void Jump()
        {

        }

        public override void Move(Direction direction)
        {
            base.Move(direction);
            var differenceX = direction == Direction.Right ? 50 : -50;
            Position = new Point(Position.X + differenceX, Position.Y);
        }

    }

    class Monster : MovableObject
    {

    }
}