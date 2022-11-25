﻿using SN2LNJ.abstractfolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN2LNJ.classes
{
    public class DetailedRating : Rating
    {
        protected override string GetDisplay()
        {
            //throw new NotImplementedException();
            return Title + "\n" + RatingReason;
            
        }

        public string RatingReason { get; set; }
    }
}
