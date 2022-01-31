namespace bank_api.Helper
{
    public static class SwaggerConfiguration
    {
        public static string SchemaIdStrategy(Type currentClass)
        {
            string returnedValue = currentClass.Name;
            if (returnedValue.EndsWith("Dto"))
                returnedValue = returnedValue.Replace("Dto", string.Empty);
            return returnedValue;
        }
    }
}
