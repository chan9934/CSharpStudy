using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShartpStudy
{

    enum CreatureType
    {
        None,
        Player,
        Monster
    }
    class Creature
    {
        protected CreatureType ct = CreatureType.None;
        protected int hp = 0;
        protected int attack = 0;

        protected Creature(CreatureType ct)
        {
            this.ct = ct;
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

        public void OnDamaged(int damage)
        {
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
        }

        public bool IsDead()
        {
            if(hp <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
