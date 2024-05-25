using IdentityModel;
using IdentityServer4.Validation;
using SpotifyLike.STS.Data;
using System.Security.Cryptography;
using System.Text;

namespace SpotifyLike.STS.GrantType
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        
        private readonly IIdentityRepository repository;

        public ResourceOwnerPasswordValidator(IIdentityRepository repository)
        {
            this.repository = repository;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var password = context.Password;
            var email = context.UserName;

            var user = await this.repository.FindByEmailAndPasswordAsync(email, HashSHA256(password));

            if (user is not null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            }

        }

        public String HashSHA256(string plainText)
        {
            SHA256 criptoProvider = SHA256.Create();

            byte[] btexto = Encoding.UTF8.GetBytes(plainText);

            var criptoResult = criptoProvider.ComputeHash(btexto);

            return Convert.ToHexString(criptoResult);
        }

    }
}
