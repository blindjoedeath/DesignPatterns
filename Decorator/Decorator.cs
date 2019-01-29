using System;

namespace Patterns.Decorator
{
	public interface IMedia
	{
		void Load();
		void Destroy();
	}

	public class Video : IMedia
	{
		public void Load()
		{
			Console.WriteLine("Загрузили видео");
		}

		public void Destroy()
		{
			Console.WriteLine("Выгрузили видео");
		}
	}

	public class MediaPlayer
	{
		public void ShowMedia(IMedia media)
		{
			media.Load();
			media.Destroy();
		}
	}

	public abstract class MediaDecorator : IMedia
	{
		protected IMedia _media;

		public MediaDecorator(IMedia media)
		{
			_media = media;
		}

		public abstract void Load();
		public abstract void Destroy();
	}

	public class SubtitleDecorator : MediaDecorator
	{
		public SubtitleDecorator(IMedia media) : base(media)
		{
			
		}
		
		public override void Load()
		{
			Console.WriteLine("Добавляем субтитры");
			_media.Load();
		}

		public override void Destroy()
		{
			Console.WriteLine("Удаляем субтитры");
			_media.Destroy();
		}
	}

	public class SoundTrackDecorator : MediaDecorator
	{

		public SoundTrackDecorator(IMedia media) : base(media)
		{
			
		}
		
		public override void Load()
		{
			Console.WriteLine("Добавляем озвучку");
			_media.Load();
		}

		public override void Destroy()
		{
			Console.WriteLine("Удаляем озвучку");
			_media.Destroy();
		}	
	}

	public class FilterDecorator : MediaDecorator
	{
		public FilterDecorator(IMedia media) : base(media)
		{
			
		}
		
		public override void Load()
		{
			Console.WriteLine("Добавляем фильтр на видео");
			_media.Load();
		}

		public override void Destroy()
		{
			Console.WriteLine("Удаляем фильтр");
			_media.Destroy();
		}	
	}
}