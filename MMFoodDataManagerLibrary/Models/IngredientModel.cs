namespace MMFoodDataManagerLibrary.Models
{
    public class IngredientModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public IngredientCategoryDBModel Category { get; set; }
    }
}