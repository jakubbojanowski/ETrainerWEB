namespace ETrainerWEB.Services
{
    public class PropertyCopierService<T>  where T : class
    {
        public void Copy(T source, T destination) 
        {
            var parentProperties = source.GetType().GetProperties();
            var childProperties = destination.GetType().GetProperties();

            foreach (var parentProperty in parentProperties)
            {
                foreach (var childProperty in childProperties)
                {
                    if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType && parentProperty.Name != "Id")
                    {
                        childProperty.SetValue(destination, parentProperty.GetValue(source));
                        break;
                    }
                }
            }
        }
    }
}