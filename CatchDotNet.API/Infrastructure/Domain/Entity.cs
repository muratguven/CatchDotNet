﻿namespace CatchDotNet.API.Infrastructure.Domain
{
    public abstract class Entity : IEntity, IEquatable<Entity>
    {
        public virtual Guid Id { get; set; }

        public static bool operator ==(Entity? first, Entity? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator !=(Entity? first, Entity? second)
        {
            return !(first == second);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }
            if (obj.GetType() != GetType())
            {
                return false;
            }
            if (obj is not Entity entity)
            {
                return false;
            }
            return entity.Id == Id;
        }

        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }
            if (other.GetType() != GetType())
            {
                return false;
            }
            return other.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 33;
        }
    }

    public abstract class Entity<T> : IEntity<T>, IEquatable<Entity<T>>
    {
        public virtual T Id { get; set; }

        public static bool operator ==(Entity<T>? first, Entity<T>? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator !=(Entity<T>? first, Entity<T>? second)
        {
            return !(first == second);
        }

        public bool Equals(Entity<T>? other)
        {
            if (other is null)
            {
                return false;
            }
            if (other.GetType() != GetType())
            {
                return false;
            }

            return EqualityComparer<T>.Default.Equals((T)Id, other.Id);
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }
            if (obj is not Entity<T> entity)
            {
                return false;
            }

            return EqualityComparer<T>.Default.Equals(Id, entity.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() * 33;
        }
    }
}