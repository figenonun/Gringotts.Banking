namespace Gringotts.Banking.Domain.ValueConverters;

using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

internal class UtcDateTimeConverter : ValueConverter<DateTime, DateTime>
{
    public UtcDateTimeConverter()
        : base(
              outside => outside, 
              inside => DateTime.SpecifyKind(inside, DateTimeKind.Utc))
    { }
}