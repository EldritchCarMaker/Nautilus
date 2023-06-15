using Nautilus.Crafting;
using UnityEngine;

namespace Nautilus.Assets.Gadgets.GadgetMonobehaviours;
/// <summary>
/// A component to be added to a prefab that gives it's associated CustomPrefab the CraftingGadget
/// </summary>
public class PrefabCraftingMono : GadgetMonobehaviourBase
{
    /// <inheritdoc/>
    protected override void AddGadget()
    {
        Prefab.SetRecipe(recipeData)
            .WithCraftingTime(craftingTime)
            .WithFabricatorType(fabricatorType)
            .WithStepsToFabricatorTab(stepsToFabricatorTab);
    }

    public RecipeData recipeData;
    public float craftingTime;
    public CraftTree.Type fabricatorType;
    public string[] stepsToFabricatorTab;
}
