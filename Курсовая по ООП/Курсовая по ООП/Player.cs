using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

    abstract class GameObject
    {
        public Image Image;

        public Point Position;
    }

    abstract class MovableObject : GameObject
    {
        public Image[] PlayerImages;

        public Direction Direction { get; set; }

        public void Move()
        { }
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

    }

    class Key : Item
    {

    }

    interface ICanJump
    {
        public VerticalPosition VerticalPosition { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    class Player : MovableObject
    {     
    }

    class Monster : MovableObject
    {

    }
}