using System;

namespace LendingCompany.Domain.Model
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }
    }
}
