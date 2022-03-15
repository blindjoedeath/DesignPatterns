using System;
using System.Linq;

namespace Patterns.Iterator 
{
    public interface Iterable<Element>
    {
        bool HasMore { get; }
        Element Current { get; }
        Element GetNext();

    }

    public interface Interator<Element>
    {
        void ForEach(Action<Element> action);
    }

    public class Video
    {
        public String name;
        public String uri;

        public override string ToString()
        {
            return $"{this.name} {this.uri}";
        }
    }

    public class CachedVideoStorage
    {
        public Video[] cachedVideos = new [] 
        {
            new Video() { name = "video1", uri = "file://path/file.mp4" },
            new Video() { name = "video2", uri = "file://path/cached.mp4" }
        };
    }

    public class VideoUrlStorage
    {
        public Video[] serverVideos = new [] 
        {
            new Video() { name = "video1", uri = "https://server.com/video1.mp4" },
            new Video() { name = "video2", uri = "https://server.com/video2.mp4" },
            new Video() { name = "video3", uri = "https://server.com/video3.mp4" }
        };
    }

    public class VideoProvider: Iterable<Video>
    {
        private CachedVideoStorage cachedStorage = new CachedVideoStorage();

        private VideoUrlStorage serverStorage = new VideoUrlStorage();

        private int _index = 0;

        public bool HasMore 
        { 
            get 
            {
                return this._index < this.serverStorage.serverVideos.Length;
            }
        }
        
        private Video _current;
        public Video Current
        { 
            get
            {
                return this._current;
            }    
        }

        public Video GetNext()
        {
            var next = GetAt(this._index++);
            this._current = next;
            return next;
        }

        private Video GetAt(int index)
        {
            var serverVideo = this.serverStorage.serverVideos[index];
            var cachedVideo = this.cachedStorage.cachedVideos.FirstOrDefault(v => v.name == serverVideo.name);
            return cachedVideo ?? serverVideo;
        }
    } 

    public class ShowCase
    {
        public void Run()
        {
            var videoProvider = new VideoProvider();

            while(videoProvider.HasMore)
            {
                Console.WriteLine(videoProvider.GetNext());
            }
        }
    }
}