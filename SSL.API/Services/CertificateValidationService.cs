using System.Security.Cryptography.X509Certificates;

namespace SSL.API.Services
{
    public class CertificateValidationService : ICertificateValidationService
    {
        public bool ValidateCertificate(X509Certificate2 clientCertificate)
        {
            // Don't hardcode passwords in production code.
            // Use a certificate thumbprint or Azure Key Vault.
            var expectedCertificate = new X509Certificate2(
                "d:/certs/new/sc-cert.pfx", "1234");

            return clientCertificate.Thumbprint == expectedCertificate.Thumbprint;
        }
    }
}
