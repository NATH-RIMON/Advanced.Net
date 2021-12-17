using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Service
{
    public class SMSLength
    {

        public int Length { set; get; }

        public int Count { set; get; }

        public void Calculate(string msg)
        {
            decimal count;
            if (IsUnicode(msg))
            {
                count = (decimal)msg.Length / 70;
                Count = (int)Math.Ceiling(count);
                Length = msg.Length;
            }
            else
            {
                count = (decimal)msg.Length / 160;
                Count = (int)Math.Ceiling(count);
                Length = msg.Length;
            }


        }

        public bool IsUnicode(string input)
        {
            const int MaxAnsiCode = 255;

            return input.Any(c => c > MaxAnsiCode);
        }
    }
}