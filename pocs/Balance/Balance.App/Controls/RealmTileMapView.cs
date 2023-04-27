using System.ComponentModel;
using System.Diagnostics;
using Balance.App.Renders;
using Balance.Core.Models;
using Balance.Core.Services;

namespace Balance.App.Controls;

public partial class RealmTileMapView : UserControl
{
   private RealmTileMap? _map;
   private MapDisplayOptions _displayOptions = new();
   private readonly RealmTileRenderer _tileRenderer = new();

   public RealmTileMapView()
   {
      InitializeComponent();
   }

   public RealmTileMap? Map
   {
      get => _map;
      set
      {
         _map = value ?? new RealmTileMapFactory().Create(RealmTileMapFactory.Options.Medium);
         Setup();
      }
   }

   public MapDisplayOptions DisplayOptions
   {
      get => _displayOptions;
      set
      {
         _displayOptions = value;
         _tileRenderer.Options = _displayOptions;
         Setup();
      }
   }

   public event EventHandler<MouseCoordinateEventArgs> MouseSetOverCoordinate;
   public event EventHandler<EventArgs> MouseClearOverCoordinate;

   protected override void OnLoad(EventArgs e)
   {
      base.OnLoad(e);
      DoubleBuffered = true;
   }


   private void Setup()
   {
      if (Map is null)
         return;

      thePanel.Size = new Size(Map.Width * DisplayOptions.TileSize.Width, Map.Height * DisplayOptions.TileSize.Height);

      Invalidate();
   }

   private void thePanel_Paint(object sender, PaintEventArgs e)
   {
      foreach (var tile in Map!.Tiles)
      {
         if( tile is null)
            continue;

         var tileRect = GetTileRect(tile);
         _tileRenderer.Render(e.Graphics, tileRect, tile);
      }
   }

   private Rectangle GetTileRect(RealmTile tile) =>
      new(
         tile.Coordinate.Col * DisplayOptions!.TileSize.Width,
         tile.Coordinate.Row * DisplayOptions.TileSize.Height,
         DisplayOptions.TileSize.Width,
         DisplayOptions.TileSize.Height);

   private bool IsTracking => _mouseLocation is not null;
   private Point? _mouseLocation;
   private Coordinate? _mouseCoordinate;

   private void ClearTracking()
   {
      //Debug.WriteLine($"{nameof(ClearTracking)}");
      _mouseLocation = null;
      _mouseCoordinate = null;
      OnMouseClearOverCoordinate();
   }

   private void SetTracking(Point location)
   {
      _mouseLocation = location;
      _mouseCoordinate = new Coordinate( location.X / DisplayOptions.TileSize.Width, location.Y / DisplayOptions.TileSize.Height);
      OnMouseOverCoordinate(_mouseCoordinate);
      //Debug.WriteLine($"{nameof(SetTracking)}, Loc: {_mouseLocation}, Coord: {_mouseCoordinate}");
   }

   private void thePanel_MouseLeave(object sender, EventArgs e) => ClearTracking();

   private void thePanel_MouseMove(object sender, MouseEventArgs e) => SetTracking(e.Location);

   private void thePanel_MouseHover(object sender, EventArgs e)
   {
      //Debug.WriteLine($"{nameof(thePanel_MouseHover)}");
   }

   private void thePanel_MouseDown(object sender, MouseEventArgs e)
   {
      //Debug.WriteLine($"{nameof(thePanel_MouseDown)}");
   }

   private void thePanel_MouseEnter(object sender, EventArgs e)
   {
      //Debug.WriteLine($"{nameof(thePanel_MouseEnter)}");
   }

   private void thePanel_MouseUp(object sender, MouseEventArgs e)
   {
      //Debug.WriteLine($"{nameof(thePanel_MouseUp)}");
   }

   protected virtual void OnMouseOverCoordinate(Coordinate coordinate) => OnMouseOverCoordinate(new MouseCoordinateEventArgs(coordinate));

   protected virtual void OnMouseOverCoordinate(MouseCoordinateEventArgs e) => MouseSetOverCoordinate?.Invoke(this, e);

   protected virtual void OnMouseClearOverCoordinate() => MouseClearOverCoordinate?.Invoke(this, EventArgs.Empty);
}
