using CatchDotNet.Core.Domain;

namespace CatchDotNet.WebApi.Features.Cases.Domains
{
    public class Case : AuditedAggregateRoot
    {
        public Case()
        {
            
        }
        public Case(Guid customerId, Guid categoryId, Guid statusId, string title, string description)
        {
            CustomerId = customerId;
            CategoryId = categoryId;
            StatusId = statusId;
            Title = title;
            Description = description;
            
        }

        public Guid CustomerId { get; private set; }

        public Guid CategoryId { get; private set; }

        public Guid StatusId { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        // Navigation Properties
        
        public Category Category { get; private set; }

        public Status Status { get; private set; }


        // Another Module
        public void ChangeCustomer(Guid customerId) => CustomerId = customerId;
        
        public void ChangeCategory(Guid categoryId) => CategoryId = categoryId;
        public void ChangeCategory(Category category)
        {
            CategoryId = category.Id;
            Category = category;
        }

        public void ChangeStatus(Guid statusId) => StatusId = statusId;

        public void ChangeStatus(Status status)
        {
            StatusId = status.Id;
            Status = status;
        }

        public void SetDetails(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void ChangeTitle(string title) => Title = title;
        public void ChangeDescription(string description) => Description = description;





    }
}
