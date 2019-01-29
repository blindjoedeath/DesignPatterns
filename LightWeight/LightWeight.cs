using System.Collections.Generic;

namespace SandBox.Patterns.LightWeight
{

    public class Texture
    {
        // consumes memory
    }

    public class Sprite
    {
        public Sprite(Texture fromTexture, Color color)
        {

        }

        public void Draw(Vector position)
        {
            // draws repeated sprite on unique position
        }
    }

    public class SpriteFactory
    {
        private static Dictionary<Texture, Dictionary<Color, Sprite>> buffer = new Dictionary<Texture, Dictionary<Color, Sprite>>();
        public static Sprite Create(Texture texture, Color color)
        {
            if(buffer[texture][color] == null)
            {
                buffer[texture][color] = new Sprite(texture, color);
            }
            return buffer[texture][color];
        }
    }

    public struct Vector
    {
        public int x;
        public int y;
    }

    public struct Color
    {
        public int r;
        public int g;
        public int b;
    }

    public class UIElement
    {
        public Vector position;
        public Sprite sprite;

        public UIElement(Texture texture, Color color, Vector position)
        {
            sprite = SpriteFactory.Create(texture, color);
            this.position = position;
        }

        private void StartListenTaps()
        {
            //...
        }

        public void Draw()
        {
            StartListenTaps();
            sprite.Draw(position);
        }
    }
}