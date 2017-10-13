/*
Copyright (c) 2012-2013, dewitcher Team
Copyright (c) 2017, Apollo OS
Copyright (c) 2017, Cosmos

All rights reserved.

See in the /Licenses folder for the licenses for each respected project.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AIC.Core.dev;
using C = AIC.Core.IO.PortIO;

namespace AIC_Framework.dev
{
    public partial class TextScreen
    {
        public static Color Foreground, Background;
        public static int X, Y;
        public enum Color : byte
        {
            Black = 0x0,
            Blue = 0x1,
            Green = 0x2,
            Cyan = 0x3,
            Red = 0x4,
            Magenta = 0x5,
            Brown = 0x6,
            Lightgray = 0x7,
            Gray = 0x8,
            Lightblue = 0x9,
            Lightgreen = 0xA,
            Lightcyan = 0xB,
            Lightred = 0xC,
            Lightmagenta = 0xD,
            Yellow = 0xE,
            White = 0xF
        }
        public static void PrintChar(char chr, int x, int y)
        {
            AIC.Core.dev.TextScreen.PrintChar(chr, x, y);
        }
        internal static int GetOffset(int X, int Y)
        {
            return Y * 80 + X;
        }
        public static void UpdateCursor(int X, int Y)
        {
            int tmp = GetOffset(X, Y);
            C.outb(0x3D4, 14);
            C.outb(0x3D5, (byte)(tmp >> 8));
            C.outb(0x3D4, 15);
            C.outb(0x3D5, (byte)tmp);
        }
        public static void RemoveCursor()
        {
            C.outb(0x3D4, 14);
            C.outb(0x3D5, 0x07);
            C.outb(0x3D4, 15);
            C.outb(0x3D5, 0xD0);
        }
    }
}
