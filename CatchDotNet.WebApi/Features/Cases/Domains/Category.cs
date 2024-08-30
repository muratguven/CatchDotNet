using CatchDotNet.Core.Domain;

namespace CatchDotNet.WebApi.Features.Cases.Domains;

public class Category : Entity
{
    public Category(Guid? parentId, string name, bool ısActived)
    {
        ParentId = parentId;
        Name = name;
        IsActived = ısActived;
    }

    public Guid? ParentId { get; private set; }
    public string Name {  get; private set; }
    public bool IsActived { get; private set; }

    public void ChangeParent(Guid parentId) => ParentId = parentId; 

    public void SetName(string name) => Name = name;

    public void ChangeActivity(bool isActive) => IsActived = isActive;
}
