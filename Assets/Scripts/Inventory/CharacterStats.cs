using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.Collections.ObjectModel;


namespace Mira.CharacterStats
{
    [Serializable]
    public class CharacterStats
    {
        public float BaseValue;


        public virtual float Value
        {
            get
            {
                if (isDirty || BaseValue != lastBaseValue)
                {
                    lastBaseValue = BaseValue;
                    _value = CalculateFinalValue();
                    isDirty = false;
                }
                return _value;
            }

        }

        protected bool isDirty = true;
        protected float _value;
        protected float lastBaseValue = float.MinValue;

        protected readonly List<StatModifier> statsModifiers;
        public readonly ReadOnlyCollection<StatModifier> StatModifiers;

        public CharacterStats()
        {
            statsModifiers = new List<StatModifier>();
            StatModifiers = statsModifiers.AsReadOnly();
        }

        public CharacterStats(float baseValue) : this()
        {
            BaseValue = baseValue;

        }

        public virtual void AddModifier(StatModifier mod)
        {
            isDirty = true;
            statsModifiers.Add(mod);
            statsModifiers.Sort(CompareModifierOrder);
        }

        protected virtual int CompareModifierOrder(StatModifier a, StatModifier b)
        {
            if (a.Order < b.Order)

                return -1;

            else if (a.Order > b.Order)

                return 1;
            return 0;

        }

        public virtual bool RemoveModifiers(StatModifier mod)
        {
            if (statsModifiers.Remove(mod))
            {
                isDirty = true;
                return true;
            }
            return false;
        }

        public virtual bool RemoveAllModifiersFromSource(object source)
        {
            bool didRemove = false;
            for (int i = statsModifiers.Count - 1; i >= 0; i--)
            {
                if (statsModifiers[i].Source == source)
                {
                    isDirty = true;
                    didRemove = true;
                    statsModifiers.RemoveAt(i);
                }
            }
            return didRemove;
        }

        protected virtual float CalculateFinalValue()
        {
            float finalValue = BaseValue;
            float sumPercentAdd = 0;

            for (int i = 0; i < statsModifiers.Count; i++)
            {

                StatModifier mod = statsModifiers[i];

                if (mod.Type == StatModType.Flat)
                {
                    finalValue += mod.Value;
                }
                else if (mod.Type == StatModType.PercentAdd)
                {
                    sumPercentAdd += mod.Value;
                    if (i + 1 >= statsModifiers.Count || statsModifiers[i + 1].Type != StatModType.PercentAdd)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                }
                else if (mod.Type == StatModType.PercentMult)
                {
                    finalValue *= 1 + mod.Value;
                }


            }

            return (float)Math.Round(finalValue, 4);
        }
    }
}
