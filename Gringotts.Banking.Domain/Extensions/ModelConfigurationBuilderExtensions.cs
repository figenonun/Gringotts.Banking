namespace Gringotts.Banking.Domain.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Gringotts.Banking.Domain.ValueConverters;


public static class ModelConfigurationBuilderExtensions
{
    /// <summary>
    /// Applies the UTC date-time converter to all of the properties that are <see cref="DateTime"/> and end with Utc.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    public static void ApplyUtcDateTimeConverter(this ModelConfigurationBuilder configurationBuilder)
    {
        foreach (IMutableEntityType mutableEntityType in configurationBuilder.CreateModelBuilder(null).Model.GetEntityTypes())
        {
            IEnumerable<IMutableProperty> dateTimeUtcProperties = mutableEntityType.GetProperties()
                .Where(p => p.ClrType == typeof(DateTime) && p.Name.EndsWith("Utc", StringComparison.Ordinal));

            foreach (IMutableProperty mutableProperty in dateTimeUtcProperties)
            {
                mutableProperty.SetValueConverter(typeof(UtcDateTimeConverter));
            }
        }
    }
}
