using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StardewValley;
using StardewValley.GameData.Objects;
using StardewValley.ItemTypeDefinitions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xTile.Layers;
using xTile.Tiles;

namespace CookingShowdownCode.Event.Command
{
    public class AddDishToMapCmd
    {
        public static void AddDishToMap(StardewValley.Event @event, string[] args, EventContext context)
        {
            Microsoft.Xna.Framework.Point point;
            string? dishId = null;
            string error;
            if (!ArgUtility.TryGetPoint(args, 1, out point, out error, "Point tilePos") || !ArgUtility.TryGet(args, 3, out dishId, out error, name: "string dishid"))
            {
                context.LogErrorAndSkip(error);
            }

            int x = @event.OffsetTileX(point.X);
            int y = @event.OffsetTileY(point.Y);

            var dishObject = ItemRegistry.Create(dishId) as StardewValley.Object;
            Game1.currentLocation.objects.TryAdd(new Vector2(x,y), dishObject);
            
            ++@event.currentCommand;
        }
    }
}
