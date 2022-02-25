namespace Business.Services
{
    public static class SQLQueryList
    {

        public static string CategoryAdd()
        {
            return @"Insert into Category (CategoryTypes) values (@Name)";
        }
        public static string CategoryUpdate()
        {
            return @"Update Category set CategoryTypes=@Name where Id=@Id";
        }

        public static string CategoryDelete()
        {
            return @"Delete From Category where Id=@Id";
        }
    }
}
