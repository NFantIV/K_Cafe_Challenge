
public class MenuItemRepository
{
    private List<MenuItem> _mItemDb = new List<MenuItem>();
    private int _count;
    private readonly Ingredients_Repository _iRepo;

    public MenuItemRepository(Ingredients_Repository iRepo)
    {
        _iRepo = iRepo;
        Seed();
    }


    public bool AddItemToMenu(MenuItem menuItem)
    {
        if (menuItem is null)
        {
            return false;
        }
        else
        {
            _count++;
            menuItem.MealNumber = _count;
            _mItemDb.Add(menuItem);
            return true;
        }
    }
    public List<MenuItem> GetMenuItems()
    {
        return _mItemDb;
    }

    public MenuItem GetMenuItem(int MealNumber)
    {
        foreach (MenuItem menuItem in _mItemDb)
        {
            if (menuItem.MealNumber == MealNumber)
            {
                return menuItem;
            }
        }
        return null;
    }

    public bool DeleteMenuItem(int mealNumber)
    {
        MenuItem menuItem = GetMenuItem(mealNumber);
        return _mItemDb.Remove(menuItem);
    }
    private void Seed()
    {
        var beef = new Ingredients
        {
            Name = "Beef"
        };

        var cheese = new Ingredients
        {
            Name = "Cheese"
        };

        var onions = new Ingredients
        {
            Name = "Onions"
        };
        var chicken = new Ingredients
        {
            Name = "Chicken",

        };
        var veggies = new Ingredients
        {
            Name = "Veggies"
        };

        _iRepo.AddIngredient(chicken);
        _iRepo.AddIngredient(veggies);
        _iRepo.AddIngredient(beef);
        _iRepo.AddIngredient(cheese);
        _iRepo.AddIngredient(onions);
        
        var menuItemA = new MenuItem("Tacos", "Premium beef tacos with cheese and onions", new List<Ingredients>
        {
            _iRepo.GetIngredient(4),
            _iRepo.GetIngredient(5),
            _iRepo.GetIngredient(6),
        }, 7.75m);
        var menuItemB = new MenuItem("Salad", "Chicken salad with veggies", new List<Ingredients>
        {
            chicken,
            veggies
        }, 5.50m);
        var menuItemC = new MenuItem("Chicken Burgers", "Homemade burger with our finest chicken breast", new List<Ingredients>
        {
            chicken,
            _iRepo.GetIngredient(1), 
            _iRepo.GetIngredient(2), 
        }, 9.50m);

        AddItemToMenu(menuItemA);
        AddItemToMenu(menuItemB);
        AddItemToMenu(menuItemC);

    }
}
