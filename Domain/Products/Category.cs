using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http.HttpResults;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public Category(string name, string createdBy, string editedBy)
    {
        Name = name;
        Active = true;
        CreatedBy = createdBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;

        Validate();
    }

    private void Validate()
    {
        var contract = new Contract<Notification>()
                    .Requires()
                    .IsNotNullOrEmpty(Name, nameof(Name))
                    .IsGreaterOrEqualsThan(Name, 3, nameof(Name))
                    .IsNotNullOrEmpty(CreatedBy, nameof(CreatedBy))
                    .IsNotNullOrEmpty(EditedBy, nameof(EditedBy));
        AddNotifications(contract);
    }

    public void EditInfo(string name,bool active)
    {
        Active = active;
        Name = name;

        Validate();
    }
}

