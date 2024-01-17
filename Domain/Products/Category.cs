using Flunt.Notifications;
using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name, string createBy, string editedBy)
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(name, nameof(Name))
            .IsGreaterOrEqualsThan(name, 3, nameof(Name))
            .IsNotNullOrEmpty(createBy, nameof(CreatedBy))
            .IsNotNullOrEmpty(editedBy, nameof(EditedBy));
        AddNotifications(contract);

        Name = name;
        Active = true;
        CreatedBy = createBy;
        EditedBy = editedBy;
        CreatedOn = DateTime.UtcNow;
        EditedOn = DateTime.UtcNow;
    }
}

