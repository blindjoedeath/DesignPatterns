namespace Patterns.Prototype
{  
    public interface IPrototype
    {
        IPrototype Clone();
    }

    public class Color : IPrototype
    {
        public byte R;  public byte G;  public byte B;

        public Color(byte single)
        {
            R = G = B = single;
        }

        public Color(byte r, byte g, byte b)
        {
            R = r;  G = g;  B = b;    
        }

        public IPrototype Clone()
        {
            return new Color(this.R, this.G, this.B);
        }
    }

    public class Shape : IPrototype
    {
        public Color Color { get; set; } = new Color(0);
        public string Name { get; set; }

        public IPrototype Clone()
        {
            Color color = (Color)Color.Clone();
            return new Shape() { Color = color, Name = this.Name };
        }
    }
}