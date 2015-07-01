using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

using XRpgLibrary;
using XRpgLibrary.TileEngine;
using XRpgLibrary.SpriteClasses;

using RPG_Demo1.Component;
using RPG_Demo1.MusicManager;

namespace RPG_Demo1.GameScreens
{
    public class GamePlayScreen:BaseGameState
    {
        #region Field Region

        private Engine engine = new Engine(32, 32);
        private Tileset tileset;
        private TileMap map;
        private Player player;
        private Song song;


        private AnimatedSprite sprite;
        private AnimatedSprite sprite2;
        private AnimatedSprite sprite3Sprite;
        private AnimatedSprite redMonkeyAnimatedSprite;
        

       

        #endregion
        
        #region Property Region
        #endregion

        #region Constructor Region

        public GamePlayScreen(Game game, GameStateManager manager) : base(game, manager) 
        {
            player = new Player(game);
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            Texture2D redMonkeyTexture2D = Game.Content.Load<Texture2D>("PlayerSprites/arc1");

            Texture2D elfTexture2D = Game.Content.Load<Texture2D>("PlayerSprites/ElfMale");
            
            Texture2D _monkeyTexture2D = Game.Content.Load<Texture2D>("PlayerSprites/CaucasianFemale");

            Dictionary<AnimationKey, Animation> animations2 = new Dictionary<AnimationKey, Animation>();

            Animation animation2 = new Animation(3, 32, 32, 0, 0);
            animations2.Add(AnimationKey.Down, animation2);

            animation2 = new Animation(3, 32, 32, 0, 32);
            animations2.Add(AnimationKey.Left, animation2);

            animation2 = new Animation(3, 32, 32, 0, 64);
            animations2.Add(AnimationKey.Right, animation2);

            animation2 = new Animation(3, 32, 32, 0, 96);
            animations2.Add(AnimationKey.Up, animation2);

            

            Texture2D spriteSheet = Game.Content.Load<Texture2D>("PlayerSprites/DwarfMale");
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);

            sprite = new AnimatedSprite(spriteSheet, animations);
            sprite2 = new AnimatedSprite(_monkeyTexture2D, animations);
            sprite2.Position = new Vector2(20, 300);
            sprite3Sprite=new AnimatedSprite(elfTexture2D,animations);
            sprite3Sprite.Position=new Vector2(400,20);
            redMonkeyAnimatedSprite=new AnimatedSprite(redMonkeyTexture2D,animations);
            redMonkeyAnimatedSprite.Position=new Vector2(500,300);

            base.LoadContent();

            
            Texture2D tilesetTexture = Game.Content.Load<Texture2D>("Tilesets/starterTileSet1");
            Tileset tileset1 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            tilesetTexture = Game.Content.Load<Texture2D>("Tilesets/tileset2");
            Tileset tileset2 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            List<Tileset> tilesets = new List<Tileset>();
            tilesets.Add(tileset1);
            tilesets.Add(tileset2);

            MapLayer layer = new MapLayer(40, 40);

            for (int y = 0; y < layer.Height; y++) 
            {
                for (int x = 0; x < layer.Width; x++) 
                {
                    Tile tile = new Tile(0, 0);
                    layer.SetTile(x, y, tile);
                }
            }

           MapLayer splatter = new MapLayer(40, 40);
  
           Random random = new Random();
          
           for (int i = 0; i < 80; i++) 
           {
               int x = random.Next(0, 40);
               int y = random.Next(0, 40);
               int index = random.Next(2, 14);
          
               Tile tile = new Tile(index,0);
               splatter.SetTile(x, y, tile);
           }
           #region Constructing House

           splatter.SetTile(1, 1, new Tile(0, 1));
           splatter.SetTile(2, 1, new Tile(2, 1));
           splatter.SetTile(3, 1, new Tile(0, 1));
           splatter.SetTile(4, 1, new Tile(0, 1));
           splatter.SetTile(1, 0, new Tile(17, 1));
           splatter.SetTile(2, 0, new Tile(18, 1));
           splatter.SetTile(3, 0, new Tile(19, 1));
           splatter.SetTile(4, 0, new Tile(20, 1));
           splatter.SetTile(10, 10, new Tile(24, 1));
           splatter.SetTile(11, 10, new Tile(28, 1));
           splatter.SetTile(12, 10, new Tile(29, 1));
           splatter.SetTile(10, 9, new Tile(25, 1));
           splatter.SetTile(11, 9, new Tile(26, 1));
           splatter.SetTile(12, 9, new Tile(27, 1));

           #endregion
            
           List<MapLayer> mapLayers = new List<MapLayer>();
           mapLayers.Add(layer);
           mapLayers.Add(splatter);

           map = new TileMap(tilesets, mapLayers);

           Music GamePlayMusic = new Music("Music/LEVEL_1", song);
          
            
        }
        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            sprite.Update(gameTime);
            sprite2.Update(gameTime);
           


            //collision not tested
            BoundingBox CollisionDetectionPlayer = new BoundingBox(new Vector3(sprite.Position.X - 2, sprite.Position.Y - 2, 0),
                new Vector3(sprite.Position.X + 2, sprite.Position.Y + 2, 0));

            BoundingBox CollisionHouse1 = new BoundingBox(new Vector3(300, 258, 0), new Vector3(405, 320, 0));

            Vector2 motion = new Vector2();

            if (InputHandler.KeyDown(Keys.W)||InputHandler.KeyDown(Keys.Up)) 
            {
                sprite.CurrentAnimation = AnimationKey.Up;
                motion.Y = -1;
            }
            else if (InputHandler.KeyDown(Keys.S)||InputHandler.KeyDown(Keys.Down)) 
            {
                sprite.CurrentAnimation = AnimationKey.Down;
                motion.Y = 1;
            }
            if (InputHandler.KeyDown(Keys.A)||InputHandler.KeyDown(Keys.Left)) 
            {
                sprite.CurrentAnimation = AnimationKey.Left;
                motion.X = -1;
            }
            else if (InputHandler.KeyDown(Keys.D)||InputHandler.KeyDown(Keys.Right)) 
            {
                sprite.CurrentAnimation = AnimationKey.Right;
                motion.X = 1;
            }

            if (motion != Vector2.Zero)
            {
                sprite.IsAnimating = true;
                motion.Normalize();

                sprite.Position += motion * sprite.Speed;
                sprite.LockToMap();

                if (player.Camera.CameraMode == CameraMode.Follow) player.Camera.LockToSprite(sprite);
            }
            else 
            {
                sprite.IsAnimating = false;
            }

            if (CollisionDetectionPlayer.Intersects(CollisionHouse1)) 
            {
               sprite.Position -= motion  * sprite.Speed;
               if (sprite.CurrentAnimation == AnimationKey.Down || sprite.CurrentAnimation == AnimationKey.Right) 
               {
                   sprite.Position = new Vector2(sprite.Position.X -1, sprite.Position.Y - 1);
               }
               else if (sprite.CurrentAnimation == AnimationKey.Up || sprite.CurrentAnimation == AnimationKey.Left) 
               {
                   sprite.Position = new Vector2(sprite.Position.X + 1, sprite.Position.Y + 1);

               }   
            }

            if (InputHandler.KeyReleased(Keys.F)) 
            {
                player.Camera.ToggleCameraMode();
                if (player.Camera.CameraMode == CameraMode.Follow) player.Camera.LockToSprite(sprite);
            }

            if (player.Camera.CameraMode != CameraMode.Follow) 
            {
                if (InputHandler.KeyReleased(Keys.C)) 
                {
                    player.Camera.LockToSprite(sprite);
                }
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            

            GameRef.spriteBatch.Begin
                (SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                Matrix.Identity
                );
            map.Draw(GameRef.spriteBatch,player.Camera);
            sprite.Draw(gameTime, GameRef.spriteBatch, player.Camera);

            sprite2.Draw(gameTime, GameRef.spriteBatch, player.Camera);
            sprite3Sprite.Draw(gameTime, GameRef.spriteBatch, player.Camera);
            redMonkeyAnimatedSprite.Draw(gameTime,GameRef.spriteBatch,player.Camera);

            base.Draw(gameTime);

            GameRef.spriteBatch.End();
        }

        #endregion

        #region Abstract Method Region
        #endregion
    }
}
