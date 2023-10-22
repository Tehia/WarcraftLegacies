using System;
using System.Collections.Generic;
using System.Linq;

namespace MacroTools.Setup
{
  /// <summary>
  /// A collection of <see cref="IService"/>s singletons which can be added and retrieved based on their type.
  /// </summary>
  public sealed class ServiceCollection
  {
    private readonly Dictionary<Type, IService> _services = new();
    
    /// <summary>
    /// Registers an <see cref="IService"/> as a singleton.
    /// </summary>
    /// <param name="singleton"></param>
    /// <typeparam name="T"></typeparam>
    public void Add<T>(T singleton) where T : IService
    {
      _services.Add(singleton.GetType(), singleton);
    }

    /// <summary>
    /// Retrieves the registered singleton with the type <see cref="IService"/>.
    /// </summary>
    public T GetRequired<T>() where T : class, IService
    {
      return _services[typeof(T)] as T;
    }

    /// <summary>Returns all <see cref="IService"/>s in the collection.</summary>
    public IList<IExecutableService> GetAllExecutableSetupSteps() =>
      _services.Values.OfType<IExecutableService>().ToList();
  }
}