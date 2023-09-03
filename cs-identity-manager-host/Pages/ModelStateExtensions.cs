namespace Amrita.IdentityManager.Host.Pages;

using Microsoft.AspNetCore.Mvc.ModelBinding;

public static class ModelStateExtensions
{
    public static void RemoveMany(this ModelStateDictionary modelState, params string[] keys)
    {
        foreach (var key in keys)
        {
            modelState.Remove(key);
        }
    }
}