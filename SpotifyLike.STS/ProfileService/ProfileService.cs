using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using SpotifyLike.STS.Data;
using System.Security.Claims;

namespace SpotifyLike.STS.ProfileService
{
    public class ProfileService: IProfileService
    {
        private readonly IIdentityRepository repository;

        public ProfileService(IIdentityRepository repository)
        {
            this.repository = repository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var id = context.Subject.GetSubjectId();

            var user = await this.repository.FindByIdAsync(new Guid(id));

            var claims = new List<Claim>()
            {
                new Claim("iss", "Spotifylike.STS"),
                new Claim("name", user.Nome),
                new Claim("email", user.Email),
                new Claim("role", "spotifylike-user")
            };

            context.IssuedClaims = claims;
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            return Task.CompletedTask;
        }
    }
}
