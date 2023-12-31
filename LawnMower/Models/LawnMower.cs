﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LawnMowerRentalAssignment.Models
{
    public enum LawnMowerModel
    {
        Electrical1,
        Electrical2,
        Petrol
    }

    public class LawnMower:RentalItem
    {
        [JsonIgnore]
        public override int MaxStock => GetMaxStock(Model);
        public LawnMowerModel Model { get; }
        [JsonIgnore]
        public double Effect { get { return GetEffect(); } }
        [JsonIgnore]
        public string EffectUnit { get { return GetUnit(); } }

        public LawnMower(LawnMowerModel model) {
            Model = model;
        }

        protected override string GetItemName() {
            return base.GetItemName() + " " + Model;
        }
        public override string ToString() {
            return base.ToString() + ", Effect: " + GetEffectToString();
        }

        public string GetEffectToString() {
            return Effect + EffectUnit;
        }

        protected override decimal GetPricePerDay() {
            return 50;
        }

        public static int GetMaxStock(LawnMowerModel model) {
            switch(model) {
                case LawnMowerModel.Electrical1:
                    return 7;
                case LawnMowerModel.Electrical2:
                    return 6;
                case LawnMowerModel.Petrol:
                    return 5;
                default:
                    return 0;
            }
        }

        private double GetEffect() {
            switch(Model) {
                case LawnMowerModel.Electrical1:
                    return 75.6;
                case LawnMowerModel.Electrical2:
                    return 146;
                case LawnMowerModel.Petrol:
                    return 862;
                default:
                    return 0;

            }
        }

        private string GetUnit() {
            if(Model == LawnMowerModel.Petrol) {
                return "g / kWh";
            }
            else {
                return "wH";
            }
        }
    }
}
