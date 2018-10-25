namespace Patterns.Prototype
{
    using System;
    
    public class NETClone : ICloneable
    {
        public Color color;
        public NETClone()
        {
            color = new Color(0);
        }

        public NETClone(Color col)
        {
            color = col;
        }

        public object Clone()
        {
            return new NETClone((Color)color.Clone());
        }
    }
}
