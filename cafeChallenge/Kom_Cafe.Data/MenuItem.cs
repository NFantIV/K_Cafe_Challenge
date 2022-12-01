
    public class MenuItem
    {
    public MenuItem() { }
    public MenuItem (string mealName, string mealDescription, List<Ingredients> mealIngredients, decimal mealPrice)
    {
        MealName = mealName;
        MealDescription = mealDescription;
        MealPrice = mealPrice;
        IngredientsList = mealIngredients;
    }
    public MenuItem(string mealName)
    {
        MealName = mealName;
    }


        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public List<Ingredients> IngredientsList { get; set; } = new List<Ingredients>();
        public decimal MealPrice { get; set; }

        public override string ToString()
        {
            string str = $"{MealNumber}\n";
            str += $"{MealName}\n";
            str += $"{MealDescription}\n";

            if (IngredientsList.Count > 0)
            {
                foreach (var item in IngredientsList)
                {
                    str += $"{item.Name}\n";
                }
            }
            else
            {
                str += "There are no ingredients\n";
            }
            str += $"{MealPrice}\n";
            str += "=====================================\n";


            return str;
        }
    }
