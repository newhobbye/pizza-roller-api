﻿namespace RollerPizza.Model
{
    public interface IItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public double Value { get; set; }
        
        
    }
}
