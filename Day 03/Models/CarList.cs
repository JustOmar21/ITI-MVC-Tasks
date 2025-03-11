using Microsoft.AspNetCore.Mvc;

namespace Day_03.Models
{
    public class CarList
    {
        public static List<Car> Cars = new List<Car>
        {
            new Car { ID = 1, Manfacture = "Toyota", Model = "Corolla", Color = "White" },
            new Car { ID = 2, Manfacture = "Honda", Model = "Civic", Color = "Black" },
            new Car { ID = 3, Manfacture = "Ford", Model = "Mustang", Color = "Red" },
            new Car { ID = 4, Manfacture = "Chevrolet", Model = "Camaro", Color = "Blue" },
            new Car { ID = 5, Manfacture = "Tesla", Model = "Model 3", Color = "Silver" },
            new Car { ID = 6, Manfacture = "BMW", Model = "M3", Color = "Grey" },
            new Car { ID = 7, Manfacture = "Audi", Model = "A4", Color = "White" },
            new Car { ID = 8, Manfacture = "Mercedes", Model = "C-Class", Color = "Black" },
            new Car { ID = 9, Manfacture = "Volkswagen", Model = "Golf", Color = "Yellow" },
            new Car { ID = 10, Manfacture = "Nissan", Model = "GT-R", Color = "Orange" }
        };
    }
}
