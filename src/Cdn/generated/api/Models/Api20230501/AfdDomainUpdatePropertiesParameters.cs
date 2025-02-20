// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Extensions;

    /// <summary>The JSON object that contains the properties of the domain to create.</summary>
    public partial class AfdDomainUpdatePropertiesParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainUpdatePropertiesParameters,
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainUpdatePropertiesParametersInternal
    {

        /// <summary>
        /// Backing field for <see cref="AfdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId" /> property.
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReference _afdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId;

        /// <summary>
        /// Resource reference to the Azure resource where custom domain ownership was prevalidated
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReference AfdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId { get => (this._afdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId = this._afdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ResourceReference()); set => this._afdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId = value; }

        /// <summary>Backing field for <see cref="AzureDnsZone" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReference _azureDnsZone;

        /// <summary>Resource reference to the Azure DNS zone</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReference AzureDnsZone { get => (this._azureDnsZone = this._azureDnsZone ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ResourceReference()); set => this._azureDnsZone = value; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public string AzureDnsZoneId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReferenceInternal)AzureDnsZone).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReferenceInternal)AzureDnsZone).Id = value ?? null; }

        /// <summary>
        /// Internal Acessors for AfdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReference Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainUpdatePropertiesParametersInternal.AfdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId { get => (this._afdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId = this._afdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ResourceReference()); set { {_afdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId = value;} } }

        /// <summary>Internal Acessors for AzureDnsZone</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReference Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainUpdatePropertiesParametersInternal.AzureDnsZone { get => (this._azureDnsZone = this._azureDnsZone ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ResourceReference()); set { {_azureDnsZone = value;} } }

        /// <summary>Internal Acessors for ProfileName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainUpdatePropertiesParametersInternal.ProfileName { get => this._profileName; set { {_profileName = value;} } }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public string PreValidatedCustomDomainResourceId { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReferenceInternal)AfdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReferenceInternal)AfdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId).Id = value ?? null; }

        /// <summary>Backing field for <see cref="ProfileName" /> property.</summary>
        private string _profileName;

        /// <summary>The name of the profile which holds the domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string ProfileName { get => this._profileName; }

        /// <summary>Backing field for <see cref="TlsSetting" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainHttpsParameters _tlsSetting;

        /// <summary>
        /// The configuration specifying how to enable HTTPS for the domain - using AzureFrontDoor managed certificate or user's own
        /// certificate. If not specified, enabling ssl uses AzureFrontDoor managed certificate by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainHttpsParameters TlsSetting { get => (this._tlsSetting = this._tlsSetting ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.AfdDomainHttpsParameters()); set => this._tlsSetting = value; }

        /// <summary>Creates an new <see cref="AfdDomainUpdatePropertiesParameters" /> instance.</summary>
        public AfdDomainUpdatePropertiesParameters()
        {

        }
    }
    /// The JSON object that contains the properties of the domain to create.
    public partial interface IAfdDomainUpdatePropertiesParameters :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IJsonSerializable
    {
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string AzureDnsZoneId { get; set; }
        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"Resource ID.",
        SerializedName = @"id",
        PossibleTypes = new [] { typeof(string) })]
        string PreValidatedCustomDomainResourceId { get; set; }
        /// <summary>The name of the profile which holds the domain.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the profile which holds the domain.",
        SerializedName = @"profileName",
        PossibleTypes = new [] { typeof(string) })]
        string ProfileName { get;  }
        /// <summary>
        /// The configuration specifying how to enable HTTPS for the domain - using AzureFrontDoor managed certificate or user's own
        /// certificate. If not specified, enabling ssl uses AzureFrontDoor managed certificate by default.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The configuration specifying how to enable HTTPS for the domain - using AzureFrontDoor managed certificate or user's own certificate. If not specified, enabling ssl uses AzureFrontDoor managed certificate by default.",
        SerializedName = @"tlsSettings",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainHttpsParameters) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainHttpsParameters TlsSetting { get; set; }

    }
    /// The JSON object that contains the properties of the domain to create.
    internal partial interface IAfdDomainUpdatePropertiesParametersInternal

    {
        /// <summary>
        /// Resource reference to the Azure resource where custom domain ownership was prevalidated
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReference AfdDomainUpdatePropertiesParametersPreValidatedCustomDomainResourceId { get; set; }
        /// <summary>Resource reference to the Azure DNS zone</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceReference AzureDnsZone { get; set; }
        /// <summary>Resource ID.</summary>
        string AzureDnsZoneId { get; set; }
        /// <summary>Resource ID.</summary>
        string PreValidatedCustomDomainResourceId { get; set; }
        /// <summary>The name of the profile which holds the domain.</summary>
        string ProfileName { get; set; }
        /// <summary>
        /// The configuration specifying how to enable HTTPS for the domain - using AzureFrontDoor managed certificate or user's own
        /// certificate. If not specified, enabling ssl uses AzureFrontDoor managed certificate by default.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdDomainHttpsParameters TlsSetting { get; set; }

    }
}