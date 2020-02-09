using FluentValidator;
using System;

namespace Domain.Entities
{
    public abstract class Base : Notifiable
    {
        public Base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
