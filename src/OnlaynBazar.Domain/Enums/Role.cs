namespace OnlaynBazar.Domain.Enums;

public enum Role
{
    Admin,          // Has full administrative rights.
    User,           // Regular user with standard permissions.
    Guest,          // Temporary access with limited permissions.
    SuperAdmin      // Higher level admin with all permissions.
}
