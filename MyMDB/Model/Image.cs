﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDB.Model
{
    /// <summary>
    /// Model for images.
    /// </summary>
    public class Image
    {
        public object Full { get; set; }
        public object Medium { get; set; }
        public object Thumb { get; set; }
    }
}
