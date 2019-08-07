using System;

namespace LambdaShoppingListWebAi.Models
{
    public class Item
    {
        public Item(string name, int quantity)
        {
            Id = Guid.NewGuid();
            Name = name;
            Quantity = quantity;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Quantity { get; private set; }

        public void ChangeId(Guid id)
        {
            Id = id;
        }
    }
}
