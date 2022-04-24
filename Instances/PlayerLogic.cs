using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ether.Instances
{
    class PlayerLogic
    {
        public int HP = 5;
        int maxHP = 5;
        int AP = 1;
        int DF = 1;
        int EXP = 0;
        int LV = 1;
        int G = 0;

        public virtual int dmgcalc(int pwr)
        {
            return pwr - DF;
        }

        public virtual void maintenance()
        {
            hpcheck();
        }

        public virtual void hpcheck()
        {
            if (HP > maxHP)
            {
                HP = maxHP;
            }
        }
    }
}
