using CatchDotNet.Core.Domain;

namespace CatchDotNet.WebApi.Features.Cases.Domains
{
    public class Status : Entity
    {
        public Status(string name, bool isActive)
        {
            Name = name;
            IsActive = isActive;
        }

        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public void ChangeName(string name) => Name = name;

        public void ChangeActivity(bool isActive) => IsActive = isActive;

    }
}