using StardewValley;
using StardewValley.Inventories;
using StardewValley.Menus;
using StardewValley.Network;
using StardewValley.Objects;

using Microsoft.Xna.Framework;



namespace CookingShowdownCode
{
    internal class CookGameLocation : GameLocation
    {
        public static void ActivateCompetitionKitchen()
        {
            List<NetMutex> mutexes = new List<NetMutex>();
            List<Chest> mini_fridges = new List<Chest>();
            MultipleMutexRequest multipleMutexRequest = new MultipleMutexRequest(mutexes, (Action<MultipleMutexRequest>)(request =>
            {
                List<IInventory> materialContainers = new List<IInventory>();
                foreach (Chest chest in mini_fridges)
                    materialContainers.Add((IInventory)chest.Items);
                Vector2 centeringOnScreen = Utility.getTopLeftPositionForCenteringOnScreen(800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2);
                Game1.activeClickableMenu = (IClickableMenu)new CraftingPage((int)centeringOnScreen.X, (int)centeringOnScreen.Y, 800 + IClickableMenu.borderWidth * 2, 600 + IClickableMenu.borderWidth * 2, true, true, materialContainers);
                Game1.activeClickableMenu.exitFunction = new IClickableMenu.onExit(request.ReleaseLocks);
            }), (Action<MultipleMutexRequest>)(request => Game1.showRedMessage(Game1.content.LoadString("Strings\\UI:Kitchen_InUse"))));
        }
    }
}
