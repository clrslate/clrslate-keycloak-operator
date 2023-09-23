using k8s.Models;
using KubeOps.Operator.Entities;
using KubeOps.Operator.Entities.Annotations;

namespace KeyCloakOperator.Entities
{
    [KubernetesEntity(Group = "security.clrslate", ApiVersion = "v1", Kind = "keycloakclient", PluralName = "keycloakclients")]
    [KubernetesEntityShortNames("kcclient")]
    [GenericAdditionalPrinterColumn(".metadata.namespace", "Namespace", "string", Priority = 0)]
    [GenericAdditionalPrinterColumn(".metadata.creationTimestamp", "Age", "date", Priority = 0)]
    public class V1KeyCloakClientEntity : CustomKubernetesEntity<V1KeyCloakClientEntitySpec, V1KeyCloakClientStatus>
    {
    }

    [Description("This represents a KeyCloak client")]
    public class V1KeyCloakClientEntitySpec
    {
        [Required]
        [AdditionalPrinterColumn(Priority = 0)]
        [Description("Specifies ID referenced in URI and tokens. For example 'my-client'. For SAML this is also the expected issuer value from authn requests")]
        [Pattern("^[a-z][a-z\\-]*$")]
        public string ClientId { get; set; } = string.Empty;

        [Required]
        [AdditionalPrinterColumn(Priority = 0)]
        [Description("Specifies display name of the client. For example 'My Client'.")]
        public string Name { get; set; } = string.Empty;

        [Description("Disabled clients cannot initiate a login or have obtained access tokens.")]
        public bool Enabled { get; set; } = true;

        [Description("Specifies description of the client. For example 'My Client for TimeSheets'. Supports keys for localized values as well.")]
        public string? Description { get; set; }

        [Description("Valid URI pattern a browser can redirect to after a successful login. Simple wildcards are allowed such as 'http://example.com/*'. Relative path can be specified too such as /my/relative/path/*. Relative paths are relative to the client root URL, or if none is specified the auth server root URL is used. For SAML, you must set valid URI patterns if you are relying on the consumer service URL embedded with the login request.")]
        public List<string>? RedirectUris { get; set; }

        [Description("Allowed CORS origins. To permit all origins of Valid Redirect URIs, add '+'. This does not include the '*' wildcard though. To permit all origins, explicitly add '*'.")]
        public List<string>? WebOrigins { get; set; }

        [Description("Default URL to use when the auth server needs to redirect or link back to the client.")]
        public string? HomeUrl { get; set; } = string.Empty;

        [Description("Root URL appended to relative URLs")]
        public string? RootUrl { get; set; } = string.Empty;
    }

    public class V1KeyCloakClientStatus
    {
        public string Status { get; set; } = string.Empty;
    }
}
