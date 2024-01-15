using Flunt.Notifications;
using Flunt.Validations;

namespace IWantApp.Domain.Products;

public class Category : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; }

    public Category(string name)
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNullOrEmpty(name, nameof(Name));
        AddNotifications(contract);

        Name = name;
        Active = true;
    }   
}

