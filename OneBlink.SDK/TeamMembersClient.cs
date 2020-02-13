using System;
using System.Linq;
using System.Threading.Tasks;
using OneBlink.SDK.Model;

namespace OneBlink.SDK
{
  public class TeamMembersClient
  {
    OneBlinkHttpClient oneBlinkHttpClient;

    public TeamMembersClient(string accessKey, string secretKey, RegionCode regionCode = RegionCode.AU)
        {
            this.oneBlinkHttpClient = new OneBlinkHttpClient(
                accessKey,
                secretKey,
                region: new Region(regionCode)
            );
        }

        public TeamMembersClient(string accessKey, string secretKey, string apiOrigin)
        {
            this.oneBlinkHttpClient = new OneBlinkHttpClient(
                accessKey,
                secretKey,
                region: new Region(apiOrigin: apiOrigin)
            );
        }


    public async Task<Role> GetTeamMemberRole(string email)
    {
      if (String.IsNullOrWhiteSpace(email))
      {
        throw new ArgumentException("email must be provided with a value");
      }

      string url = "/permissions?email=" + email;
      PermissionSearchResult permissionSearchResult = await this.oneBlinkHttpClient.GetRequest<PermissionSearchResult>(url);
      Permission permission = permissionSearchResult.permissions.FirstOrDefault();
      if (permission == null || permission.links == null || permission.links.role == null)
      {
        return null;
      }

      return permission.links.role;
    }
  }
}