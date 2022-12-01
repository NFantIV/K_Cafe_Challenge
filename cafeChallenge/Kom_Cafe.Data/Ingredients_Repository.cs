
    public class Ingredients_Repository
    {
        // private MenuItemRepository _mRepo;
        private int _count;
        private List<Ingredients> _ingredientsDb = new List<Ingredients>();
        public Ingredients_Repository()
        {
            Seed();
        }
        public bool AddIngredient (Ingredients ingredients)
        {
            if (ingredients is null)
            {
                return false;
            }
            else
            {
                _count++;
                ingredients.Id =_count;
                _ingredientsDb.Add(ingredients);
                return true;
            }
        }
        public List<Ingredients> GetIngredients()
        {
            return _ingredientsDb;
        }
        public Ingredients GetIngredient(int id)
        {
            foreach (var ingredients in _ingredientsDb)
            {
                if (ingredients.Id == id)
                {
                    return ingredients;
                }
            }
            return null;
        }
        private void Seed()
        {
            var lettuce = new Ingredients("Lettuce");
            var tomato = new Ingredients("Tomato");
            var eggs = new Ingredients("Eggs");
            var beef = new Ingredients("Beef");
            var cheese = new Ingredients("Cheese");
            var onions = new Ingredients("Onions");

            AddIngredient(lettuce);
            AddIngredient(tomato);
            AddIngredient(eggs);
            AddIngredient(beef);
            AddIngredient(cheese);
            AddIngredient(onions);
        }
    }
