using System;

namespace TourManagement.API.Dtos
{
    public class IngredientDto
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public int Weight { get; set; }

        public string Description { get; set; }

    }
}
