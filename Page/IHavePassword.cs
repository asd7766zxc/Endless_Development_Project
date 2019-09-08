using System.Security;

namespace Chat_Pro_NCP
{
    public interface IHavePassword
    {
        SecureString SecurePassword { get; }
    }
}