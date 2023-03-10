using System;

namespace DDDCustomer.Domain.Interfaces
{
    public interface IApplicationSettings
    {
        int ClinicId { get; }

        DateTimeOffset TestDate { get; }
    }
}