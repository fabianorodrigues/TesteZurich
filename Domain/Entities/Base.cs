using FluentValidator;
using System;

namespace Domain.Entities
{
    public abstract class Base : Notifiable
    {
        public Base()
        {
            Id = new Random().Next(1, int.MaxValue);
        }

        public int Id { get; private set; }
    }
}
