using System;
using System.Collections.Generic;

namespace TourManagement.API.Dtos
{
    public class FoodItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }

        public List<IngredientDto> Ingredients { get; set; }= new List<IngredientDto>();
    }
}
