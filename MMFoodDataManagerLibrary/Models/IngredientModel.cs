namespace MMFoodDataManagerLibrary.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public IngredientCategoryDBModel Category { get; set; }
    }
}