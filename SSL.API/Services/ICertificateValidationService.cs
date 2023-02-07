using System.Security.Cryptography.X509Certificates;

namespace SSL.API.Services
{
    public interface ICertificateValidationService
    {
        bool ValidateCertificate(X509Certificate2 certificate);
    }
}
