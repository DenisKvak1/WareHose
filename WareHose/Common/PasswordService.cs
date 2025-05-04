using Microsoft.AspNetCore.Identity;

namespace WareHose.Common;

public static class PasswordService
{
    private static readonly PasswordHasher<string> _hasher = new();

    public static string HashPassword(string password)
    {
        return _hasher.HashPassword(null!, password);
    }

    public static bool VerifyPassword(string hashedPassword, string providedPassword)
    {
        var result = _hasher.VerifyHashedPassword(null!, hashedPassword, providedPassword);
        return result == PasswordVerificationResult.Success;
    }
}