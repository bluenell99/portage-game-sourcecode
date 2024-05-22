using System.Collections.Generic;
using UnityEngine;

public abstract class EventChannel<T> : ScriptableObject
{
   private readonly HashSet<EventListener<T>> observers = new();

   public void Invoke(T value)
   {
      foreach (var observer in observers)
      {
         observer.Raise(value);
      }
   }

   public void Register(EventListener<T> observer) => observers.Add(observer);

   public void DeRegister(EventListener<T> observer) => observers.Remove(observer);
}

public readonly struct Empty {}

[CreateAssetMenu(menuName = "Events/Empty Channel")]
public class EventChannel : EventChannel<Empty> {}