﻿using _2._2._1._GAME.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Logic.Handling.ControlHandling
{
    public class MoveHandler : Handler
    {
        public bool DoMove = false;
        public override void HandleRequest()
        {
            DoMove = true;
        }
    }
}
