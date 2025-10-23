using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace EchoFramework;

/// <summary>
/// The base class for any game using EchoFramework
/// </summary>
public class EchoGame : Game
{
    /// <summary>
    /// Gets the EchoGame instance
    /// </summary>
    /// <remarks>
    /// It has to be intsanciated first before accessing it
    /// </remarks>
    public static EchoGame Instance { get; private set; } = null!;

    /// <summary>
    /// Gets the GraphicsDeviceManager
    /// </summary>
    public static GraphicsDeviceManager Graphics { get; private set; } = null!;

    /// <summary>
    /// Gets the GraphicsDevice
    /// </summary>
    public static new GraphicsDevice GraphicsDevice { get; private set; } = null!;

    /// <summary>
    /// Gets the SpriteBatch
    /// </summary>
    /// <value></value>
    public static SpriteBatch SpriteBatch { get; private set; } = null!;

    /// <summary>
    /// Gets the ContentManager
    /// </summary>
    public static new ContentManager Content { get; private set; } = null!;

    /// <summary>
    /// Creates an EchoGame instance.
    /// </summary>
    /// <remarks>
    /// It may only be called once, otherwise it will throw an exception. Ideally it should be called in Program.cs
    /// </remarks>
    /// <param name="windowTitle">The title of the window</param>
    /// <param name="windowWidth">The width in pixels of the window</param>
    /// <param name="windowHeight">The height in pixels of the window</param>
    /// <param name="isWindowFullscreen">Determines if the window is fullscreen or not</param>
    public EchoGame(string windowTitle, int windowWidth, int windowHeight, bool isWindowFullscreen)
    {
        // Ensures there's only one instance created, and if not, assings it to the static reference
        if (Instance != null)
        {
            throw new InvalidOperationException("Only one EchoGame instance can be created");
        }
        Instance = this;

        // Gets the GraphicsDeviceManager and sets the base graphical values
        Graphics = new GraphicsDeviceManager(this);

        Graphics.PreferredBackBufferWidth = windowWidth;
        Graphics.PreferredBackBufferHeight = windowHeight;
        Graphics.IsFullScreen = isWindowFullscreen;

        Graphics.ApplyChanges();

        // Sets the title of the window
        Window.Title = windowTitle;

        // Sets up the ContentManager
        Content = base.Content;
        Content.RootDirectory = "Content";

        // Other settings by default (Change in the future)
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        base.Initialize();

        // Sets the GraphicsDevice and SpriteBatch once they can be set
        GraphicsDevice = base.GraphicsDevice;
        SpriteBatch = new(GraphicsDevice);
    }
}
