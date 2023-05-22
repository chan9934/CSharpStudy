using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShartpStudy
{
    public enum PlayerType
    {
        None,
        Knight,
        Archer,
        Mage
    }
    class Player
    {

        public int hp = 0;
        public int attack = 0;
        public PlayerType type = PlayerType.None;

        protected Player(PlayerType type)
        {
            this.type = type;
        }

        public void SetInfo(int hp, int attack)
        {
            this.hp = hp;
            this.attack = attack;
        }
        public int GetHp()
        {
            return hp;
        }
        public int GetAttack()
        {
            return attack;
        }

    }

    class Knight : Player
    {
        public Knight() : base(PlayerType.Knight)
        {
            SetInfo(100, 10);
        }
    }
    class Archer : Player
    {
        public Archer() : base(PlayerType.Archer)
        {
            SetInfo(75, 12);
        }
    }
    class Mage : Player
    {
        public Mage() : base(PlayerType.Mage)
        {
            SetInfo(50, 15);
        }
    }
}
