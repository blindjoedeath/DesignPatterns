using System;

namespace Patterns.AbstractFactory
{

    public abstract class GameMap
    {
        public float Area{get; set;}

        public abstract void Explore();
    }

    public class LavaMap: GameMap
    {

        public LavaMap()
        {
            Area = 666;
        }

        public override void Explore()
        {
            Console.WriteLine("Exploring lava map");
        }
    }

    public class ForestMap: GameMap
    {
        public ForestMap()
        {
            Area = 100;
        }

        public override void Explore()
        {
            Console.WriteLine("Exploring forest map");
        }
    }


    public abstract class Mob
    {
        public abstract void Interract();
    }

    public class PeaceMob: Mob
    {
        public override void Interract()
        {
            Console.WriteLine("Interracting well with peace mob");
        }
    }

    public class AggressiveMob: Mob
    {
        public override void Interract()
        {
            Console.WriteLine("Interracting bad with aggressive mob");
        }
    }

    public interface ILevelConstructor
    {
        GameMap GetMap();
        Mob[] GetMobs();
    }

    public class FirstLevelConstructor: ILevelConstructor
    {
        public GameMap GetMap()
        {
            return new ForestMap();
        }

        public Mob[] GetMobs()
        {
            return new Mob[]
            {
                new PeaceMob()
            };
        }
    }

    public class SecondLevelConstructor: ILevelConstructor
    {
        public GameMap GetMap()
        {
            return new LavaMap();
        }

        public Mob[] GetMobs()
        {
            return new Mob[]
            {
                new AggressiveMob()
            };
        }
    }

    public class GameSceneLoader
    {
        public ILevelConstructor _levelConstructor;

        public GameSceneLoader(ILevelConstructor levelConstructor)
        {
            this._levelConstructor = levelConstructor;
        }

        public void Load()
        {
            var map = _levelConstructor.GetMap();
            map.Explore();

            var mobs = _levelConstructor.GetMobs();
            mobs[0].Interract();
        }
    }
}