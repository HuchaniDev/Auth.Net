namespace Auth.Domain.Adapters;

public interface IPasswordEncriptAdapter
{
    string PasswordEncript(string password);
}