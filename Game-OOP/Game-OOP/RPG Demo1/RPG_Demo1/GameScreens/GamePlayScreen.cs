namespace RPG_Demo1.GameScreens
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using RPG_Demo1.Component;
    using RPG_Demo1.MusicManager;
    using XRpgLibrary;
    using XRpgLibrary.SpriteClasses;
    using XRpgLibrary.TileEngine;

    public class GamePlayScreen : BaseGameState
    {
        #region Field Region

        private Engine engine = new Engine(32, 32);
        private TileMap map;
        private Player player;
        private Song song;
        private List<AnimatedSprite> sprites = new List<AnimatedSprite>();
        private AnimatedSprite sprite;
        private AnimatedSprite sprite2;
        private AnimatedSprite sprite3Sprite;
        private AnimatedSprite redMonkeyAnimatedSprite;
        
        #endregion

        #region Constructor Region

        public GamePlayScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
            this.player = new Player(game);
        }

        #endregion

        #region XNA Method Region

        public override void Update(GameTime gameTime)
        {
            this.player.Update(gameTime);
            this.sprite.Update(gameTime);

            Vector2 motion = new Vector2();

            if (InputHandler.KeyDown(Keys.W) || InputHandler.KeyDown(Keys.Up)) 
            {
                this.sprite.CurrentAnimation = AnimationKey.Up;
                motion.Y = -1;
            }
            else if (InputHandler.KeyDown(Keys.S) || InputHandler.KeyDown(Keys.Down)) 
            {
                this.sprite.CurrentAnimation = AnimationKey.Down;
                motion.Y = 1;
            }

            if (InputHandler.KeyDown(Keys.A) || InputHandler.KeyDown(Keys.Left)) 
            {
                this.sprite.CurrentAnimation = AnimationKey.Left;
                motion.X = -1;
            }
            else if (InputHandler.KeyDown(Keys.D) || InputHandler.KeyDown(Keys.Right)) 
            {
                this.sprite.CurrentAnimation = AnimationKey.Right;
                motion.X = 1;
            }

            if (motion != Vector2.Zero)
            {
                this.sprite.IsAnimating = true;
                motion.Normalize();

                this.sprite.Position += motion * this.sprite.Speed;
                this.sprite.LockToMap();

                if (this.player.Camera.CameraMode == CameraMode.Follow)
                {
                    this.player.Camera.LockToSprite(this.sprite);
                }
            }
            else 
            {
                this.sprite.IsAnimating = false;
            }

            if (InputHandler.KeyReleased(Keys.F)) 
            {
                this.player.Camera.ToggleCameraMode();
                if (this.player.Camera.CameraMode == CameraMode.Follow)
                {
                    this.player.Camera.LockToSprite(this.sprite);
                }
            }

            if (this.player.Camera.CameraMode != CameraMode.Follow) 
            {
                if (InputHandler.KeyReleased(Keys.C)) 
                {
                    this.player.Camera.LockToSprite(this.sprite);
                }
            }

            this.CheckForCollision(motion);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            this.GameRef.SpriteBatch.Begin(
                SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.PointClamp,
                null,
                null,
                null,
                Matrix.Identity);

            this.map.Draw(GameRef.SpriteBatch, this.player.Camera);
            this.sprite.Draw(gameTime, this.GameRef.SpriteBatch, this.player.Camera);

            foreach (var spr in this.sprites)
            {
                spr.Draw(gameTime, this.GameRef.SpriteBatch, this.player.Camera);
            }

            base.Draw(gameTime);

            this.GameRef.SpriteBatch.End();
        }

        protected override void LoadContent()
        {
            // load main sprite
            Texture2D spriteSheet = Game.Content.Load<Texture2D>("PlayerSprites/DwarfMale");
            var animations = Animations();
            this.sprite = new AnimatedSprite(spriteSheet, animations);

            // load bad sprites
            this.sprites = this.CreateSpritesList(animations);

            base.LoadContent();

            // create tilesets, background and splatter objects
            var tilesets = this.CreateTilesets();
            var background = GenerateBackground();
            var splatter = GenerateSplatter();

            // combine the total map
            List<MapLayer> mapLayers = new List<MapLayer>();
            mapLayers.Add(background);
            mapLayers.Add(splatter);

            this.map = new TileMap(tilesets, mapLayers);

            // load music
            Music gamePlayMusic = new Music("Music/LEVEL_1", this.song);
        }

        protected void CheckForCollision(Vector2 motion)
        {
            BoundingBox collisionDetectionSprite = new BoundingBox(
                new Vector3(this.sprite.Position.X - 2, this.sprite.Position.Y - 2, 0),
                new Vector3(this.sprite.Position.X + 2, this.sprite.Position.Y + 2, 0));
            BoundingBox collisionDetectionSprite2 = new BoundingBox(
                new Vector3(this.sprite2.Position.X - 2, this.sprite2.Position.Y - 2, 0),
                new Vector3(this.sprite2.Position.X + 2, this.sprite2.Position.Y + 2, 0));
            BoundingBox collisionDetectionSprite3 = new BoundingBox(
                new Vector3(this.sprite3Sprite.Position.X - 2, this.sprite3Sprite.Position.Y - 2, 0),
            new Vector3(this.sprite3Sprite.Position.X + 2, this.sprite3Sprite.Position.Y + 2, 0));
            BoundingBox collisionDetectionSprite4 = new BoundingBox(
                new Vector3(this.redMonkeyAnimatedSprite.Position.X - 2, this.redMonkeyAnimatedSprite.Position.Y - 2, 0),
                new Vector3(this.redMonkeyAnimatedSprite.Position.X + 2, this.redMonkeyAnimatedSprite.Position.Y + 2, 0));

            BoundingBox collisionHouse1 = new BoundingBox(new Vector3(300, 258, 0), new Vector3(405, 320, 0));

            // if they intersect = we have collision
            if (collisionDetectionSprite.Intersects(collisionHouse1))
            {
                this.sprite.Position -= motion * this.sprite.Speed;
                if (this.sprite.CurrentAnimation == AnimationKey.Down || this.sprite.CurrentAnimation == AnimationKey.Right)
                {
                    this.sprite.Position = new Vector2(this.sprite.Position.X - 1, this.sprite.Position.Y - 1);
                }
                else if (this.sprite.CurrentAnimation == AnimationKey.Up || this.sprite.CurrentAnimation == AnimationKey.Left)
                {
                    this.sprite.Position = new Vector2(this.sprite.Position.X + 1, this.sprite.Position.Y + 1);
                }
            }
                //here
            else if (collisionDetectionSprite2.Intersects(collisionDetectionSprite))
            {
                Music menu = new Music("Music/Boss_Fight", this.song);
                StateManager.PushState(GameRef.BattleScreen);

                this.sprite2.Position = new Vector2(-100, -100);
                sprites.Remove(sprite2);
            }
            else if (collisionDetectionSprite3.Intersects(collisionDetectionSprite))
            {
                Music menu = new Music("Music/Boss_Fight", this.song);
                StateManager.PushState(GameRef.BattleScreen);

                this.sprite3Sprite.Position = new Vector2(-100, -100);
                sprites.Remove(sprite3Sprite);

            }
            else if (collisionDetectionSprite4.Intersects(collisionDetectionSprite))
            {
                Music menu = new Music("Music/Boss_Fight", this.song);
                StateManager.PushState(GameRef.BattleScreen);
                
                this.redMonkeyAnimatedSprite.Position = new Vector2(-100, -100);
                sprites.Remove(redMonkeyAnimatedSprite);
            }
        }

        private static Dictionary<AnimationKey, Animation> Animations()
        {
            Dictionary<AnimationKey, Animation> animations = new Dictionary<AnimationKey, Animation>();

            Animation animation = new Animation(3, 32, 32, 0, 0);
            animations.Add(AnimationKey.Down, animation);

            animation = new Animation(3, 32, 32, 0, 32);
            animations.Add(AnimationKey.Left, animation);

            animation = new Animation(3, 32, 32, 0, 64);
            animations.Add(AnimationKey.Right, animation);

            animation = new Animation(3, 32, 32, 0, 96);
            animations.Add(AnimationKey.Up, animation);
            return animations;
        }

        private static MapLayer GenerateBackground()
        {
            MapLayer background = new MapLayer(40, 40);

            for (int y = 0; y < background.Height; y++)
            {
                for (int x = 0; x < background.Width; x++)
                {
                    Tile tile = new Tile(0, 0);
                    background.SetTile(x, y, tile);
                }
            }

            return background;
        }

        private static MapLayer GenerateSplatter()
        {
            MapLayer splatter = new MapLayer(40, 40);

            Random random = new Random();

            for (int i = 0; i < 80; i++)
            {
                int x = random.Next(0, 40);
                int y = random.Next(0, 40);
                int index = random.Next(2, 14);

                Tile tile = new Tile(index, 0);
                splatter.SetTile(x, y, tile);
            }

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

            return splatter;
        }

        private List<Tileset> CreateTilesets()
        {
            Texture2D tilesetTexture = Game.Content.Load<Texture2D>("Tilesets/starterTileSet1");
            Tileset tileset1 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            tilesetTexture = Game.Content.Load<Texture2D>("Tilesets/tileset2");
            Tileset tileset2 = new Tileset(tilesetTexture, 8, 8, 32, 32);

            List<Tileset> tilesets = new List<Tileset>();
            tilesets.Add(tileset1);
            tilesets.Add(tileset2);
            return tilesets;
        }

        private List<AnimatedSprite> CreateSpritesList(Dictionary<AnimationKey, Animation> animations)
        {
            Texture2D redMonkeyTexture2D = Game.Content.Load<Texture2D>("PlayerSprites/arc1");

            Texture2D elfTexture2D = Game.Content.Load<Texture2D>("PlayerSprites/ElfMale");

            Texture2D monkeyTexture2D = Game.Content.Load<Texture2D>("PlayerSprites/CaucasianFemale");
            this.sprite2 = new AnimatedSprite(monkeyTexture2D, animations);
            this.sprite2.Position = new Vector2(20, 300);
            this.sprite3Sprite = new AnimatedSprite(elfTexture2D, animations);
            this.sprite3Sprite.Position = new Vector2(400, 20);
            this.redMonkeyAnimatedSprite = new AnimatedSprite(redMonkeyTexture2D, animations);
            this.redMonkeyAnimatedSprite.Position = new Vector2(500, 300);

            this.sprites.Add(this.sprite2);
            this.sprites.Add(this.sprite3Sprite);
            this.sprites.Add(this.redMonkeyAnimatedSprite);

            return this.sprites;
        }

        #endregion
    }
}