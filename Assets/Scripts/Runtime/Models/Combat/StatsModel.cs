using Assets.Scripts.Runtime.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Runtime.Models.Combat
{
    public class StatsModel
    {
        public float MaxValue { get; private set; }
        public float Value { get; private set; }
        public StatsModel(float maxValue)
        {
            MaxValue = maxValue;
            Value = maxValue;
        }
        //public void RestoreStat(float value, float time)
        //{
        //    RootController.Instance.RunCoroutine(RestoreStatCoroutine(value, time));
        //}
        public void IncreaseMaxValue(float value)
        {
            MaxValue = +value;
            if (MaxValue <= 0f)
                MaxValue = 0f;
        }
        public void DecreaseMaxValue(float value)
        {
            MaxValue -= value;
            if (MaxValue <= 0f)
                MaxValue = 0f;
        }
        public void IncreaseStatInstant(float value)
        {
            Value += value;
            if (Value > MaxValue)
            {
                Value = MaxValue;
            }
        }
        public void DecreaseStatInstant(float value)
        {
            Value -= value;
            if (Value <= 0f)
                Value = 0f;
        }
        
    }
}
