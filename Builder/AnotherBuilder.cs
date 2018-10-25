namespace Patterns.Builder
{   
    public class A
    {
        int x;
        int y;

        private A(Builder builder)
        {
            this.x = builder.X;
            this.y = builder.Y;
        }

        public class Builder
        {
            int _x;
            int _y;

            public int X
            {
                get { return _x; }
            }

            public int Y
            {
                get { return _y; }
            }

            public Builder SetX(int x)
            {
                this._x = x;
                return this;
            }

            public Builder SetY(int y)
            {
                this._y = y;
                return this;
            }

            public A Build()
            {
                return new A(this);
            }
        }
    }
}
