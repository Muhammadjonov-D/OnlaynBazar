namespace OnlaynBazar.Domain.Enums;

public enum PaymentStatus
{
    Pending,        // Payment is pending and has not been completed.
    Completed,      // Payment has been successfully completed.
    Failed         // Payment attempt failed.
}
