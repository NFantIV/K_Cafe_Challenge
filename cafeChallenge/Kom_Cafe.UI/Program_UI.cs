using static System.Console;
public class Program_UI
{
    private readonly Ingredients_Repository _iRepo;
    private readonly MenuItemRepository _mRepo;
    public Program_UI()
    {
        _iRepo = new Ingredients_Repository();
        _mRepo = new MenuItemRepository(_iRepo);
    }
    public void Run()
    {
        RunApplication();
    }

    private void RunApplication()
    {
        Clear ();
        bool isRunning = true;
        while (isRunning)
        {
            WriteLine("Komodo Cafe! \n"+
            "1. Add an Item\n"+
            "2. View All Items\n"+
            "3. Delete an Item\n"+
            "0. Exit Application");

            var userInput = ReadLine();

            switch (userInput)
            {
                case "1":
                    AddItem();
                    break;
                case "2":
                    ViewAllItems();
                    break;
                case "3":
                    DeleteItems();
                    break;
                case "0":
                    isRunning = CloseApplication();
                    break;
                default:
                    WriteLine("Invalid Selection");
                    PressAnyKey();
                    break;

            }
        }
    }

    private bool CloseApplication()
    {
        WriteLine("Thank for coming!");
        PressAnyKey();
        return false;
    }

    private void DeleteItems()
    {
        Clear();
        
        try
        {
            WriteLine("Please input an existing Menu Id");
            int userInput = int.Parse(ReadLine());
            if (_mRepo.DeleteMenuItem(userInput))
            {
                WriteLine("Success!");
            }
            else
            {
                WriteLine("Failure");
            }
        }
        catch (Exception ex)
        {
            SomethingWentWrong(ex);
        }
        ReadKey();
    }

    private void ViewAllItems()
    {
        Clear();
        foreach (var menuItem in _mRepo.GetMenuItems())
        {
            WriteLine(menuItem);
        }
        ReadKey();
    }

    private void SomethingWentWrong(Exception ex)
    {
        WriteLine(ex); 
    }
    private void AddItem()
    {
        Clear();
        try
        {
            MenuItem menuItem = new MenuItem();
            WriteLine("Enter Item Name.");
            menuItem.MealName = ReadLine();
            WriteLine("Describe the item");
            menuItem.MealDescription = ReadLine();
            
            // List<Ingredients> ingredients = 
            bool hasAddedAllIngredients = false;
            while (!hasAddedAllIngredients)
            {
                WriteLine("Do you want to add ingredients? y/n");
                var userInput = ReadLine();
                if (userInput == "Y".ToLower())
                {
                    WriteLine("What are the ingredients?");
                    var ingredients = _iRepo.GetIngredients();
                    foreach (var ingredient in ingredients)
                    {
                        WriteLine($"{ingredient.Id}-{ingredient.Name}");
                    }

                    WriteLine("Please enter the Id of the ingredient");
                    int userInputIngId = int.Parse(ReadLine());
                    Ingredients selectedIngredient = _iRepo.GetIngredient(userInputIngId);

                    if (selectedIngredient != null)
                    {
                        menuItem.IngredientsList.Add(selectedIngredient);
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    hasAddedAllIngredients = true;
                }
            }
            WriteLine("What is the price?");
            decimal price = decimal.Parse(ReadLine());
            menuItem.MealPrice = price;
            if (_mRepo.AddItemToMenu(menuItem))
            {
                WriteLine("Success");
            }
            else
            {
                WriteLine("Failure");
            }
        }
        catch (Exception ex)
        {
            SomethingWentWrong(ex);
        }

        ReadKey();
    }

    private void PressAnyKey()
    {
        WriteLine("Press Any Key to Continue");
        ReadKey();
    }
}
