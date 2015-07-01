namespace RPG_Demo1.MusicManager
{
    using Microsoft.Xna.Framework.Media;

    public class Music : Game1
    {
        public Music(string songPath, Song song)
        {
            this.SongPath = songPath;
            this.Song = song;
            this.LoadContent();
        }

        public Song Song { get; private set; }

        public string SongPath { get; set; }

        protected override void LoadContent()
        {
            this.Song = Content.Load<Song>(this.SongPath);
            MediaPlayer.Play(this.Song);
        }
    }
}