﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopModel.Entities
{
    public class Cart
    {
        public readonly List<CartLine> Lines = new List<CartLine>();
        public ShippingDetails ShippingDetails { get; set; }
        public void Clear()
        {
            Lines.Clear();
        }
        public void AddItem(Recept recept, int quantity)
        {
            var isPresent = false;
            foreach (var cartLine in Lines.Where(cartLine => recept.Id == cartLine.Recept.Id))
            {
                cartLine.Quantity += quantity;
                isPresent = true;
            }
            if (!isPresent)
            {
                Lines.Add(new CartLine{Recept = recept,Quantity = quantity});
            }
        }
        public void MinusItem(Recept recept, int quantity)
        {
            foreach (var cartLine in
                Lines.Where(cartLine => recept.Id == cartLine.Recept.Id).Where(cartLine => cartLine.Quantity - quantity > 0))
            {
                cartLine.Quantity -= quantity;
            }
        }

        public void RemoveItem(Recept recept)
        {
            Lines.RemoveAll(l => l.Recept.Id == recept.Id);
        }

        public decimal ComputeTotalValue()
        {
            return Lines.Sum(cartLine => cartLine.Recept.Price*cartLine.Quantity);
        }

        public int GetMinutesCooking()
        {
            try
            {
                var max = Lines[0].Recept.TimeCooking;
                return Lines.Aggregate(max, (current, cartLine) => Math.Max(current, cartLine.Recept.TimeCooking));
            }
            catch (Exception)
            {
                return 0;
            }
            
        }
    }
}
