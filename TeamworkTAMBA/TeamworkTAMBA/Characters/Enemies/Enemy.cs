﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TeamworkTAMBA
{
    using System.Drawing;

    public class Enemy : Characters
    {
        public Enemy(Image image,Point location,int id) :
            base(image,location,id)
        {
            
        }
        // TODO: .. loot!!!
    }
}
