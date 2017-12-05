// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class InvokeAzureComputeMethodCmdlet : ComputeAutomationBaseCmdlet
    {
        protected object CreateVirtualMachineScaleSetDeallocateDynamicParameters()
        {
            dynamicParameters = new RuntimeDefinedParameterDictionary();
            var pResourceGroupName = new RuntimeDefinedParameter();
            pResourceGroupName.Name = "ResourceGroupName";
            pResourceGroupName.ParameterType = typeof(string);
            pResourceGroupName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 1,
                Mandatory = true
            });
            pResourceGroupName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ResourceGroupName", pResourceGroupName);

            var pVMScaleSetName = new RuntimeDefinedParameter();
            pVMScaleSetName.Name = "VMScaleSetName";
            pVMScaleSetName.ParameterType = typeof(string);
            pVMScaleSetName.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 2,
                Mandatory = true
            });
            pVMScaleSetName.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("VMScaleSetName", pVMScaleSetName);

            var pInstanceIds = new RuntimeDefinedParameter();
            pInstanceIds.Name = "InstanceId";
            pInstanceIds.ParameterType = typeof(string[]);
            pInstanceIds.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByDynamicParameters",
                Position = 3,
                Mandatory = false
            });
            pInstanceIds.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("InstanceId", pInstanceIds);

            var pArgumentList = new RuntimeDefinedParameter();
            pArgumentList.Name = "ArgumentList";
            pArgumentList.ParameterType = typeof(object[]);
            pArgumentList.Attributes.Add(new ParameterAttribute
            {
                ParameterSetName = "InvokeByStaticParameters",
                Position = 4,
                Mandatory = true
            });
            pArgumentList.Attributes.Add(new AllowNullAttribute());
            dynamicParameters.Add("ArgumentList", pArgumentList);

            return dynamicParameters;
        }

        protected void ExecuteVirtualMachineScaleSetDeallocateMethod(object[] invokeMethodInputParameters)
        {
            string resourceGroupName = (string)ParseParameter(invokeMethodInputParameters[0]);
            string vmScaleSetName = (string)ParseParameter(invokeMethodInputParameters[1]);
            System.Collections.Generic.IList<string> instanceIds = null;
            if (invokeMethodInputParameters[2] != null)
            {
                var inputArray2 = Array.ConvertAll((object[]) ParseParameter(invokeMethodInputParameters[2]), e => e.ToString());
                instanceIds = inputArray2.ToList();
            }

            var result = VirtualMachineScaleSetsClient.Deallocate(resourceGroupName, vmScaleSetName, instanceIds);
            WriteObject(result);
        }
    }

    public partial class NewAzureComputeArgumentListCmdlet : ComputeAutomationBaseCmdlet
    {
        protected PSArgument[] CreateVirtualMachineScaleSetDeallocateParameters()
        {
            string resourceGroupName = string.Empty;
            string vmScaleSetName = string.Empty;
            var instanceIds = new string[0];

            return ConvertFromObjectsToArguments(
                 new string[] { "ResourceGroupName", "VMScaleSetName", "InstanceIds" },
                 new object[] { resourceGroupName, vmScaleSetName, instanceIds });
        }
    }

    [Cmdlet(VerbsLifecycle.Stop, "AzureRmVmss", DefaultParameterSetName = "DefaultParameter", SupportsShouldProcess = true)]
    [OutputType(typeof(PSOperationStatusResponse))]
    public partial class StopAzureRmVmss : ComputeAutomationBaseCmdlet
    {
        public override void ExecuteCmdlet()
        {
            ExecuteClientAction(() =>
            {
                if (ShouldProcess(this.VMScaleSetName, VerbsLifecycle.Stop)
                    && (this.Force.IsPresent ||
                        this.ShouldContinue(Properties.Resources.ResourceStoppingConfirmation,
                                            "Stop-AzureRmVmss operation")))
                {
                    string resourceGroupName = this.ResourceGroupName;
                    string vmScaleSetName = this.VMScaleSetName;
                    System.Collections.Generic.IList<string> instanceIds = this.InstanceId;

                    if (this.ParameterSetName.Equals("FriendMethod"))
                    {
                        var result = VirtualMachineScaleSetsClient.PowerOff(resourceGroupName, vmScaleSetName, instanceIds);
                        var psObject = new PSOperationStatusResponse();
                        ComputeAutomationAutoMapperProfile.Mapper.Map<Azure.Management.Compute.Models.OperationStatusResponse, PSOperationStatusResponse>(result, psObject);
                        WriteObject(psObject);
                    }
                    else
                    {
                        var result = VirtualMachineScaleSetsClient.Deallocate(resourceGroupName, vmScaleSetName, instanceIds);
                        var psObject = new PSOperationStatusResponse();
                        ComputeAutomationAutoMapperProfile.Mapper.Map<Azure.Management.Compute.Models.OperationStatusResponse, PSOperationStatusResponse>(result, psObject);
                        WriteObject(psObject);
                    }

                }
            });
        }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Parameter(
            ParameterSetName = "FriendMethod",
            Position = 1,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [AllowNull]
        [ResourceManager.Common.ArgumentCompleters.ResourceGroupCompleter()]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Parameter(
            ParameterSetName = "FriendMethod",
            Position = 2,
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Alias("Name")]
        [AllowNull]
        public string VMScaleSetName { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [Parameter(
            ParameterSetName = "FriendMethod",
            Position = 3,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            ValueFromPipeline = false)]
        [AllowNull]
        public string [] InstanceId { get; set; }

        [Parameter(
            ParameterSetName = "DefaultParameter",
            Mandatory = false)]
        [Parameter(
            ParameterSetName = "FriendMethod",
            Mandatory = false)]
        [AllowNull]
        public SwitchParameter Force { get; set; }

        [Parameter(
            ParameterSetName = "FriendMethod",
            Mandatory = true)]
        [AllowNull]
        public SwitchParameter StayProvisioned { get; set; }
    }
}
