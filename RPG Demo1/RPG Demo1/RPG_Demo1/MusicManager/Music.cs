using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace RPG_Demo1.MusicManager
{
    public class Music:Game1
    {
        private Song song;
        private string songPath;

        public Song SONG 
        { 
            get { return song; }
            private set { song = value; }
        }

        public string SongPath 
        {
            get { return songPath; }
            set { songPath = value; }
        }
        public Music(string songPath, Song song) 
        {
            this.SongPath = songPath;
            this.SONG = song;
            LoadContent(); 
        }

        protected override void LoadContent()
        {
            SONG = Content.Load<Song>(SongPath);
            MediaPlayer.Play(SONG);
            base.LoadContent();
        }
    }
    
}
