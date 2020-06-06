﻿using System;
using System.Collections.Generic;
using System.Text;

namespace yumaster.FileService.Service.Models
{
    public class ImageSize
    {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public static readonly ImageSize Raw = new ImageSize() { Name = "raw" };
    }
}
