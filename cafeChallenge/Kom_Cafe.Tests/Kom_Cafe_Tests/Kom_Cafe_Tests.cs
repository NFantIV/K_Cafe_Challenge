namespace Kom_Cafe.Tests;

public class Kom_Cafe_Repository_Tests
{
    private readonly MenuItemRepository _mItemDb;
    private readonly Ingredients_Repository _ingRepo;

    public Kom_Cafe_Repository_Tests()
    {   
        _ingRepo = new Ingredients_Repository();
        _mItemDb = new MenuItemRepository(_ingRepo);
    }
    [Fact]
    public void Menu_Item_Repository_Add_Item_To_Menu_Should_Return_True()
    {
        // Arrange
        var nullItem = new MenuItem();

        // Act
        bool actual = _mItemDb.AddItemToMenu(nullItem);
        bool expected = true;

        // Assert
        Assert.Equal(actual, expected);
    }

    [Fact]
    public void Menu_Item_Repository_Get_Menu_Item()
    {
        // Arrange
        MenuItem menuItem = _mItemDb.GetMenuItem(1);
        // menuItem.MealDescription = "Premium beef tacos with cheese and onions";

        // Act
        string expected = "Premium beef tacos with cheese and onions";
        string actual = menuItem.MealDescription;

        // Assert
        Assert.Equal(expected,actual);
    }
    [Fact]
    public void Menu_Item_Repository_Delete_Menu_Item_Should_Return_True()
    {
        // Act

        int mealNumber = _mItemDb.GetMenuItem(1).MealNumber;
        bool actual = _mItemDb.DeleteMenuItem(mealNumber);

        Assert.Equal(true, actual);
    }

}