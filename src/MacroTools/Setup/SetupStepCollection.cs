using System;
using System.Collections.Generic;
using System.Linq;

namespace MacroTools.Setup
{
  /// <summary>
  /// A collection of <see cref="ISetupStep"/>s singletons which can be added and retrieved based on their type.
  /// </summary>
  public sealed class SetupStepCollection
  {
    private readonly Dictionary<Type, ISetupStep> _services = new();
    
    /// <summary>
    /// Registers an <see cref="ISetupStep"/> as a singleton.
    /// </summary>
    /// <param name="singleton"></param>
    /// <typeparam name="T"></typeparam>
    public void AddSingleton<T>(T singleton) where T : ISetupStep
    {
      _services.Add(singleton.GetType(), singleton);
    }

    /// <summary>
    /// Retrieves the registered singleton with the type <see cref="ISetupStep"/>.
    /// </summary>
    public T GetRequiredSetupStep<T>() where T : class, ISetupStep
    {
      return _services[typeof(T)] as T;
    }

    /// <summary>Returns all <see cref="ISetupStep"/>s in the collection.</summary>
    public IList<ISetupStep> GetAllSetupSteps() => _services.Values.ToList();
  }
}