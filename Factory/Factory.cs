using System;

namespace Patterns.Factory
{
    public abstract class Image
    {
        public bool IsVertical{get; set;}

        public abstract void Rotate();

        public abstract byte[] GetRawData();
    }

    public class UIImage : Image
    {
        public override byte[] GetRawData()
        {
            Console.WriteLine("Encoding UIImage into byte array on iOS");
            return new byte[0];
        }

        public override void Rotate()
        {
            Console.WriteLine("Rotating UIImage on iOS");
        }
    }

    public class AndroidImage : Image
    {
        public override byte[] GetRawData()
        {
            Console.WriteLine("Encoding AndroidImage into byte array on Android");
            return new byte[0];
        }

        public override void Rotate()
        {
            Console.WriteLine("Rotating AndroidImage on Android");
        }
    }


    public abstract class CameraController
    {
        public abstract Image TakePhoto();
    }

    public class IOSCamera : CameraController
    {
        public override Image TakePhoto()
        {
            Console.WriteLine("Running super duper iOS code");
            var image = new UIImage();
            image.IsVertical = false;
            return image;
        }
    }

    public class AndroidCamera : CameraController
    {
        public override Image TakePhoto()
        {
            Console.WriteLine("Running extra nice Android code");
            var image = new AndroidImage();
            return image;
        }
    }

    public interface IBackend
    {
        void Send(byte[] data);
    }

    public class Backend: IBackend
    {
        public void Send(byte[] data)
        {
            Console.WriteLine("Sending data to server");
        }
    }

    public class TakePhotoScreen
    {
        private IBackend _backend;
        private CameraController _cameraController;

        public TakePhotoScreen(CameraController cameraController, IBackend backend)
        {
            this._cameraController = cameraController;
            this._backend = backend;
        }

        public void ButtonClicked()
        {
            var photo = _cameraController.TakePhoto();
            if (photo.IsVertical)
            {
                photo.Rotate();
            }
            var bytes = photo.GetRawData();
            _backend.Send(bytes);
        }


    }

}