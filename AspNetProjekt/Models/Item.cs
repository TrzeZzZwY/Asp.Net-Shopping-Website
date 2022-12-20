namespace AspNetProjekt.Models
{
    public class Item
    {
        Guid ItemId;
        string ItemName;
        decimal ItemPrice;
        int ItemDiscout;
        int ItemAvalibility;
        List<Category> Categories;

    }
}
