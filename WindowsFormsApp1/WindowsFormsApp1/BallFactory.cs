﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class BallFactory : IToyFactory
    {
        public Ball CreateNew()
        {
            return new Ball();
        }

    }
}
