// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501
{
    using static Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Extensions;

    /// <summary>Friendly Rules name mapping to the any Rules or secret related information.</summary>
    public partial class Rule :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRule,
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleInternal,
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IValidates,
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IHeaderSerializable
    {
        /// <summary>
        /// Backing field for Inherited model <see cref= "Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResource" />
        /// </summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResource __resource = new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.Resource();

        /// <summary>
        /// A list of actions that are executed when all the conditions of a rule are satisfied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IDeliveryRuleAction1[] Action { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).Action; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).Action = value ?? null /* arrayOf */; }

        /// <summary>A list of conditions that must be matched for the actions to be executed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IDeliveryRuleCondition[] Condition { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).Condition; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).Condition = value ?? null /* arrayOf */; }

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeploymentStatus? DeploymentStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdStatePropertiesInternal)Property).DeploymentStatus; }

        /// <summary>Resource ID.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        public string Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).Id; }

        /// <summary>Backing field for <see cref="Location" /> property.</summary>
        private string _location;

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        public string Location { get => this._location; set => this._location = value; }

        /// <summary>
        /// If this rule is a match should the rules engine continue running the remaining rules or stop. If not present, defaults
        /// to Continue.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.MatchProcessingBehavior? MatchProcessingBehavior { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).MatchProcessingBehavior; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).MatchProcessingBehavior = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.MatchProcessingBehavior)""); }

        /// <summary>Internal Acessors for Id</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal.Id { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).Id; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).Id = value; }

        /// <summary>Internal Acessors for Name</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal.Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).Name; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).Name = value; }

        /// <summary>Internal Acessors for SystemData</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ISystemData Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal.SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemData; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemData = value; }

        /// <summary>Internal Acessors for Type</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal.Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).Type; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).Type = value; }

        /// <summary>Internal Acessors for DeploymentStatus</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeploymentStatus? Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleInternal.DeploymentStatus { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdStatePropertiesInternal)Property).DeploymentStatus; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdStatePropertiesInternal)Property).DeploymentStatus = value; }

        /// <summary>Internal Acessors for Property</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleProperties Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleInternal.Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.RuleProperties()); set { {_property = value;} } }

        /// <summary>Internal Acessors for ProvisioningState</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdProvisioningState? Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleInternal.ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdStatePropertiesInternal)Property).ProvisioningState; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdStatePropertiesInternal)Property).ProvisioningState = value; }

        /// <summary>Internal Acessors for SetName</summary>
        string Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleInternal.SetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).RuleSetName; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).RuleSetName = value; }

        /// <summary>Resource name.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        public string Name { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).Name; }

        /// <summary>
        /// The order in which the rules are applied for the endpoint. Possible values {0,1,2,3,………}. A rule with a lesser order will
        /// be applied before a rule with a greater order. Rule with order 0 is a special rule. It does not require any condition
        /// and actions listed in it will always be applied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public int? Order { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).Order; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).Order = value ?? default(int); }

        /// <summary>Backing field for <see cref="Property" /> property.</summary>
        private Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleProperties _property;

        /// <summary>The JSON object that contains the properties of the Rules to create.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        internal Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleProperties Property { get => (this._property = this._property ?? new Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.RuleProperties()); set => this._property = value; }

        /// <summary>Provisioning status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdProvisioningState? ProvisioningState { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IAfdStatePropertiesInternal)Property).ProvisioningState; }

        /// <summary>Gets the resource group name</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Owned)]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.FormatTable]
        public string ResourceGroupName { get => (new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Success ? new global::System.Text.RegularExpressions.Regex("^/subscriptions/(?<subscriptionId>[^/]+)/resourceGroups/(?<resourceGroupName>[^/]+)/providers/", global::System.Text.RegularExpressions.RegexOptions.IgnoreCase).Match(this.Id).Groups["resourceGroupName"].Value : null); }

        /// <summary>The name of the rule set containing the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inlined)]
        public string SetName { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleUpdatePropertiesParametersInternal)Property).RuleSetName; }

        /// <summary>Read only system data</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.ISystemData SystemData { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemData; }

        /// <summary>The timestamp of resource creation (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.DoNotFormat]
        public global::System.DateTime? SystemDataCreatedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataCreatedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataCreatedAt = value ?? default(global::System.DateTime); }

        /// <summary>An identifier for the identity that created the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.DoNotFormat]
        public string SystemDataCreatedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataCreatedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataCreatedBy = value ?? null; }

        /// <summary>The type of identity that created the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.IdentityType? SystemDataCreatedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataCreatedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataCreatedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.IdentityType)""); }

        /// <summary>The timestamp of resource last modification (UTC)</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.DoNotFormat]
        public global::System.DateTime? SystemDataLastModifiedAt { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataLastModifiedAt; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataLastModifiedAt = value ?? default(global::System.DateTime); }

        /// <summary>An identifier for the identity that last modified the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.DoNotFormat]
        public string SystemDataLastModifiedBy { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataLastModifiedBy; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataLastModifiedBy = value ?? null; }

        /// <summary>The type of identity that last modified the resource</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.DoNotFormat]
        public Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.IdentityType? SystemDataLastModifiedByType { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataLastModifiedByType; set => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).SystemDataLastModifiedByType = value ?? ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.IdentityType)""); }

        /// <summary>Resource type.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Origin(Microsoft.Azure.PowerShell.Cmdlets.Cdn.PropertyOrigin.Inherited)]
        public string Type { get => ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal)__resource).Type; }

        /// <param name="headers"></param>
        void Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IHeaderSerializable.ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers)
        {
            if (headers.TryGetValues("location", out var __locationHeader0))
            {
                ((Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleInternal)this).Location = System.Linq.Enumerable.FirstOrDefault(__locationHeader0) is string __headerLocationHeader0 ? __headerLocationHeader0 : (string)null;
            }
        }

        /// <summary>Creates an new <see cref="Rule" /> instance.</summary>
        public Rule()
        {

        }

        /// <summary>Validates that this object meets the validation criteria.</summary>
        /// <param name="eventListener">an <see cref="Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IEventListener" /> instance that will receive validation
        /// events.</param>
        /// <returns>
        /// A <see cref = "global::System.Threading.Tasks.Task" /> that will be complete when validation is completed.
        /// </returns>
        public async global::System.Threading.Tasks.Task Validate(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IEventListener eventListener)
        {
            await eventListener.AssertNotNull(nameof(__resource), __resource);
            await eventListener.AssertObjectIsValid(nameof(__resource), __resource);
        }
    }
    /// Friendly Rules name mapping to the any Rules or secret related information.
    public partial interface IRule :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.IJsonSerializable,
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResource
    {
        /// <summary>
        /// A list of actions that are executed when all the conditions of a rule are satisfied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of actions that are executed when all the conditions of a rule are satisfied.",
        SerializedName = @"actions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IDeliveryRuleAction1) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IDeliveryRuleAction1[] Action { get; set; }
        /// <summary>A list of conditions that must be matched for the actions to be executed</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"A list of conditions that must be matched for the actions to be executed",
        SerializedName = @"conditions",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IDeliveryRuleCondition) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IDeliveryRuleCondition[] Condition { get; set; }

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"",
        SerializedName = @"deploymentStatus",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeploymentStatus) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeploymentStatus? DeploymentStatus { get;  }

        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"",
        SerializedName = @"location",
        PossibleTypes = new [] { typeof(string) })]
        string Location { get; set; }
        /// <summary>
        /// If this rule is a match should the rules engine continue running the remaining rules or stop. If not present, defaults
        /// to Continue.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"If this rule is a match should the rules engine continue running the remaining rules or stop. If not present, defaults to Continue.",
        SerializedName = @"matchProcessingBehavior",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.MatchProcessingBehavior) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.MatchProcessingBehavior? MatchProcessingBehavior { get; set; }
        /// <summary>
        /// The order in which the rules are applied for the endpoint. Possible values {0,1,2,3,………}. A rule with a lesser order will
        /// be applied before a rule with a greater order. Rule with order 0 is a special rule. It does not require any condition
        /// and actions listed in it will always be applied.
        /// </summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = false,
        Description = @"The order in which the rules are applied for the endpoint. Possible values {0,1,2,3,………}. A rule with a lesser order will be applied before a rule with a greater order. Rule with order 0 is a special rule. It does not require any condition and actions listed in it will always be applied.",
        SerializedName = @"order",
        PossibleTypes = new [] { typeof(int) })]
        int? Order { get; set; }
        /// <summary>Provisioning status</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"Provisioning status",
        SerializedName = @"provisioningState",
        PossibleTypes = new [] { typeof(Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdProvisioningState) })]
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdProvisioningState? ProvisioningState { get;  }
        /// <summary>The name of the rule set containing the rule.</summary>
        [Microsoft.Azure.PowerShell.Cmdlets.Cdn.Runtime.Info(
        Required = false,
        ReadOnly = true,
        Description = @"The name of the rule set containing the rule.",
        SerializedName = @"ruleSetName",
        PossibleTypes = new [] { typeof(string) })]
        string SetName { get;  }

    }
    /// Friendly Rules name mapping to the any Rules or secret related information.
    internal partial interface IRuleInternal :
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IResourceInternal
    {
        /// <summary>
        /// A list of actions that are executed when all the conditions of a rule are satisfied.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IDeliveryRuleAction1[] Action { get; set; }
        /// <summary>A list of conditions that must be matched for the actions to be executed</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IDeliveryRuleCondition[] Condition { get; set; }

        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.DeploymentStatus? DeploymentStatus { get; set; }

        string Location { get; set; }
        /// <summary>
        /// If this rule is a match should the rules engine continue running the remaining rules or stop. If not present, defaults
        /// to Continue.
        /// </summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.MatchProcessingBehavior? MatchProcessingBehavior { get; set; }
        /// <summary>
        /// The order in which the rules are applied for the endpoint. Possible values {0,1,2,3,………}. A rule with a lesser order will
        /// be applied before a rule with a greater order. Rule with order 0 is a special rule. It does not require any condition
        /// and actions listed in it will always be applied.
        /// </summary>
        int? Order { get; set; }
        /// <summary>The JSON object that contains the properties of the Rules to create.</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20230501.IRuleProperties Property { get; set; }
        /// <summary>Provisioning status</summary>
        Microsoft.Azure.PowerShell.Cmdlets.Cdn.Support.AfdProvisioningState? ProvisioningState { get; set; }
        /// <summary>The name of the rule set containing the rule.</summary>
        string SetName { get; set; }

    }
}