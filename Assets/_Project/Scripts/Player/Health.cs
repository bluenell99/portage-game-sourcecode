using System;
using UnityEngine;

public class Health : Stat, IDamageable
{

   [SerializeField] private EventChannel<Empty> _deathEventChannel;
   
   public void TakeDamage(int amount)
   {
      UpdateStat(-amount);

      if (Current <= Max)
      {
         _deathEventChannel.Invoke(new Empty());
      }
      
   }
}