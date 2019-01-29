using System;
using System.Collections.Generic;   

namespace Patterns.Builder
{   
    public struct Vector3
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }

    public abstract class Component
    {
        public bool isEnabled { get; }

        public string Name { get; set; }

        public void SetState(bool isEnabled)
        {
            isEnabled = true;
        }

        public abstract void DoSomeWork();
    }

    public class ScriptableObject : Component
    {
        public override void DoSomeWork()
        {
            Console.WriteLine("Executing user's code");
        }
    }

    public class ShaderScript : ScriptableObject
    {
        public void Calculate()
        {
            Console.WriteLine("Shader is computing");
        }
    }

    public class MovementScript : ScriptableObject
    {
        public void Calculate()
        {
            Console.WriteLine("GameObject is moving");
        }
    }

    public class Transform : Component
    {
        public Vector3 Position { get; set; }

        public override void DoSomeWork()
        {
            Console.WriteLine("Setting the position");
        }
    }

    public class ShapeTransform : Transform
    {
        public Vector3[] Vertices { get; set; }
        public string ShapeType { get; set; }
    }

    public class GameObject
    {
        private List<Component> components = new List<Component>();
        public string Name { get; set; }
        private Transform _transform;
        public Transform Transform
        {
            get { return _transform; }
            set { AddComponent<Transform>(value); }
        }

        private Component FindComponentOfType<T>()
        {
            return components.Find(x =>
            {
                var xType = x.GetType();
                var tType = typeof(T);
                return (xType == tType && !xType.IsAssignableFrom(tType) &&
                        !tType.IsAssignableFrom(xType));
            });
        }

        public Component AddComponent<T>(Component component) where T : Component
        {
            Component alreadyAdded = FindComponentOfType<T>();
            if (alreadyAdded == null)
            {
                components.Add(component);
                alreadyAdded = component;
            }
            return alreadyAdded;
        }

        public Component GetComponent<T>()
        {
            return FindComponentOfType<T>();
        }
    }

    public interface IGameObjectBuilder
    {
        void SetTransform(Transform transform);

        void SetVisibleComponent(Component component);

        void SetScriptComponent(Component component);
    }

    public class PlayerBuilder : IGameObjectBuilder
    {
        public void SetScriptComponent(Component component)
        {
            throw new NotImplementedException();
        }

        public void SetTransform(Transform transform)
        {
            throw new NotImplementedException();
        }

        public void SetVisibleComponent(Component component)
        {
            throw new NotImplementedException();
        }
    }
}
