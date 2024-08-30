namespace CatchDotNet.Core.Domain;

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

public abstract class Entity<TKey> : IEntity<TKey>, IEquatable<Entity<TKey>>
{
    public virtual TKey Id { get; set; }

    public static bool operator ==(Entity<TKey>? first, Entity<TKey>? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Entity<TKey>? first, Entity<TKey>? second)
    {
        return !(first == second);
    }

    public bool Equals(Entity<TKey>? other)
    {
        if (other is null)
        {
            return false;
        }
        if (other.GetType() != GetType())
        {
            return false;
        }

        return EqualityComparer<TKey>.Default.Equals((TKey)Id, other.Id);
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
        if (obj is not Entity<TKey> entity)
        {
            return false;
        }

        return EqualityComparer<TKey>.Default.Equals(Id, entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode() * 33;
    }
}
