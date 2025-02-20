﻿<#
.SYNOPSIS
	1) Installs the SqlIaaS extension by calling Set-AzVMSqlServerExtension cmdlet on a VM.
	2) Calls Get-AzVMSqlServerExtension cmdlet to check the status of the extension installation.
	3) Verifies settings are correct given input
    4) Verfies AutoUpgradeMinorVersion
	5) Update extension values
	6) Verify changes
	7) Test with correct Name and Version
	8) Test with correct Name and incorrect Version
	9) Test with incorrect Name and crrect Version
	10) Test with incorrect Name and incorrect Version
#>

function Test-SetAzureRmVMSqlServerAKVExtension
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Setup
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    # Common
    New-AzResourceGroup -Name $rgname -Location $loc -Force;

    # VM Profile & Hardware
    $vmsize = 'Standard_A2';
    $vmname = 'vm' + $rgname;
    $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
    Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

    # NRP
    $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
    $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
    $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
    $subnetId = $vnet.Subnets[0].Id;
    $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
    $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
    $pubipId = $pubip.Id;
    $nsg = New-AzNetworkSecurityGroup -Force -Name ('nsg' + $rgname) -ResourceGroupName $rgname -Location $loc;
    $nsg = Get-AzNetworkSecurityGroup -Name ('nsg' + $rgname) -ResourceGroupName $rgname;
    $nsgId = $nsg.Id;
    $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id -NetworkSecurityGroupId $nsgId;
    $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
    $nicId = $nic.Id;

    $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

    # Storage Account
    $stoname = 'sto' + $rgname;
    $stotype = 'Standard_GRS';
    New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
    Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }

    $osDiskName = 'osDisk';
    $osDiskCaching = 'ReadWrite';
    $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
    $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";

    $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;

    # OS & Image
    $user = "localadmin";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
    $vhdContainer = "https://$stoname.blob.core.windows.net/test";

    $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;
    $p = Set-AzVMSourceImage -VM $p -PublisherName MicrosoftSQLServer -Offer SQL2014SP2-WS2012R2 -Skus Enterprise -Version "latest"

    # Virtual Machine
    New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

    #Do actual changes and work here
    $extensionName = "SqlIaaSExtension";

    # 1) Installs the SqlIaaS extension by calling Set-AzVMSqlServerExtension cmdlet on a VM.
    $securepfxpwd = ConvertTo-SecureString –String "Amu6y/RzJcc7JBzdAdRVv6mk=" –AsPlainText –Force;
    $aps_akv = New-AzVMSqlServerKeyVaultCredentialConfig -ResourceGroupName $rgname -Enable -CredentialName "CredentialTesting" -AzureKeyVaultUrl "https://Testkeyvault.vault.azure.net/" -ServicePrincipalName "0326921f-bf005595337c" -ServicePrincipalSecret $securepfxpwd;
    Set-AzVMSqlServerExtension -KeyVaultCredentialSettings $aps_akv -ResourceGroupName $rgname -VMName $vmname -Version "2.0" -Verbose;

    # 2) Calls Get-AzVMSqlServerExtension cmdlet to check the status of the extension installation.
    $extension = Get-AzVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;

    # 3) Verifies settings are correct given input
    Assert-AreEqual $extension.KeyVaultCredentialSettings.Credentials.Count 1;
    Assert-AreEqual $extension.KeyVaultCredentialSettings.Credentials[0].CredentialName "CredentialTesting"

    # 4) Verify the autoUpgradeMinorVersion is true by Default
    $ext = Get-AzVMExtension -ResourceGroupName $rgName -VMName $vmName -Name $extensionName
    Assert-AreEqual $ext.autoUpgradeMinorVersion $true

    # 5) Update extension values
    $aps_akv = New-AzVMSqlServerKeyVaultCredentialConfig -ResourceGroupName $rgname -Enable -CredentialName "CredentialTest" -AzureKeyVaultUrl "https://Testkeyvault.vault.azure.net/" -ServicePrincipalName "0326921f-82af-4ab3-9d46-bf005595337c" -ServicePrincipalSecret $securepfxpwd;
    Set-AzVMSqlServerExtension -KeyVaultCredentialSettings $aps_akv -ResourceGroupName $rgname -VMName $vmname -Version "2.0" -Verbose;

    # 6) Verify changes
    $extension = Get-AzVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;

    Assert-AreEqual $extension.KeyVaultCredentialSettings.Credentials.Count 2;
    Assert-AreEqual $extension.KeyVaultCredentialSettings.Credentials[1].CredentialName "CredentialTest"

    # 7) Test with correct Name and Version

    Set-AzVMSqlServerExtension -KeyVaultCredentialSettings $aps_akv  -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "2.0"

    # 8) Test with correct Name and incorrect Version
    Set-AzVMSqlServerExtension -KeyVaultCredentialSettings $aps_akv  -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "2.*"
}

function Test-SetAzureRmVMSqlServerExtension
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Setup
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    # Common
    New-AzResourceGroup -Name $rgname -Location $loc -Force;

    # VM Profile & Hardware
    $vmsize = 'Standard_A2';
    $vmname = 'vm' + $rgname;
    $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
    Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

    # NRP
    $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
    $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
    $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
    $subnetId = $vnet.Subnets[0].Id;
    $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
    $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
    $pubipId = $pubip.Id;
    $nsg = New-AzNetworkSecurityGroup -Force -Name ('nsg' + $rgname) -ResourceGroupName $rgname -Location $loc;
    $nsg = Get-AzNetworkSecurityGroup -Name ('nsg' + $rgname) -ResourceGroupName $rgname;
    $nsgId = $nsg.Id;
    $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id -NetworkSecurityGroupId $nsgId;
    $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
    $nicId = $nic.Id;

    $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

    # Storage Account
    $stoname = 'sto' + $rgname;
    $stotype = 'Standard_GRS';
    New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
    Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }

    $osDiskName = 'osDisk';
    $osDiskCaching = 'ReadWrite';
    $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
    $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";

    $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;

    # OS & Image
    $user = "localadmin";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
    $vhdContainer = "https://$stoname.blob.core.windows.net/test";

    $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;
    $p = Set-AzVMSourceImage -VM $p -PublisherName MicrosoftSQLServer -Offer SQL2014SP3-WS2012R2 -Skus Enterprise -Version "latest"

    # Virtual Machine
    New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

    #Do actual changes and work here
    $extensionName = "SqlIaaSExtension";

    # 1) Installs the SqlIaaS extension by calling Set-AzVMSqlServerExtension cmdlet on a VM, with auto patching and auto backup settings.
    $aps = New-AzVMSqlServerAutoPatchingConfig -Enable -DayOfWeek "Thursday" -MaintenanceWindowStartingHour 20 -MaintenanceWindowDuration 120 -PatchCategory "Important"
    $storageBlobUrl = "https://$stoname.blob.core.windows.net";
    $storageKey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;
    $storageKeyAsSecureString = ConvertTo-SecureString -String $storageKey -AsPlainText -Force;
    $abs = New-AzVMSqlServerAutoBackupConfig -Enable -RetentionPeriodInDays 5 -ResourceGroupName $rgname -StorageUri $storageBlobUrl -StorageKey $storageKeyAsSecureString
    Set-AzVMSqlServerExtension -AutoPatchingSettings $aps -AutoBackupSettings $abs -ResourceGroupName $rgname -VMName $vmname -Version "2.0" -Verbose -Name $extensionName;

    # 2) Calls Get-AzVMSqlServerExtension cmdlet to check the status of the extension installation.
    Start-TestSleep -Seconds 60
    $extension = Get-AzVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;

    # 3) Verifies settings are correct given input
    Assert-AreEqual $extension.AutoPatchingSettings.DayOfWeek "Thursday"
    Assert-AreEqual $extension.AutoPatchingSettings.MaintenanceWindowStartingHour 20
    Assert-AreEqual $extension.AutoPatchingSettings.MaintenanceWindowDuration 120
    Assert-AreEqual $extension.AutoPatchingSettings.PatchCategory "Important"

    Assert-AreEqual $extension.AutoBackupSettings.RetentionPeriod 5
    Assert-AreEqual $extension.AutoBackupSettings.Enable $true

    # 4) Verify the autoUpgradeMinorVersion is true by Default
    $ext = Get-AzVMExtension -ResourceGroupName $rgName -VMName $vmName -Name $extensionName
    Assert-AreEqual $ext.autoUpgradeMinorVersion $true

    # 5) Update extension values
    $aps = New-AzVMSqlServerAutoPatchingConfig -Enable -DayOfWeek "Monday" -MaintenanceWindowStartingHour 20 -MaintenanceWindowDuration 120 -PatchCategory "Important"
    Set-AzVMSqlServerExtension -AutoPatchingSettings $aps -ResourceGroupName $rgname -VMName $vmname -Version "2.0" -Verbose -Name $extensionName;

    # 6) Verify changes
    $extension = Get-AzVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;
    Assert-AreEqual $extension.AutoPatchingSettings.DayOfWeek "Monday"

    # 7) Test with correct Name and Version
    Set-AzVMSqlServerExtension -AutoPatchingSettings $aps -AutoBackupSettings $abs -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "2.0"

    # 8) Test with correct Name and incorrect Version
    Set-AzVMSqlServerExtension -AutoPatchingSettings $aps -AutoBackupSettings $abs -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "2.*"
}

# Test setting up VM with Sql Server 2017 image. (Includes testing for AutoBackup V2)
function Test-SetAzureRmVMSqlServerExtensionWith2017Image
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Setup
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

   # Common
    New-AzResourceGroup -Name $rgname -Location $loc -Force;

    # VM Profile & Hardware
    $vmsize = 'Standard_A2';
    $vmname = 'vm' + $rgname;
    $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
    Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

    # NRP
    $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
    $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
    $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
    $subnetId = $vnet.Subnets[0].Id;
    $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
    $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
    $pubipId = $pubip.Id;$nsg = New-AzNetworkSecurityGroup -Force -Name ('nsg' + $rgname) -ResourceGroupName $rgname -Location $loc;
    $nsg = New-AzNetworkSecurityGroup -Force -Name ('nsg' + $rgname) -ResourceGroupName $rgname -Location $loc;
    $nsg = Get-AzNetworkSecurityGroup -Name ('nsg' + $rgname) -ResourceGroupName $rgname;
    $nsgId = $nsg.Id;
    $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id -NetworkSecurityGroupId $nsgId;
    $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
    $nicId = $nic.Id;

    $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

    # Storage Account
    $stoname = 'sto' + $rgname;
    $stotype = 'Standard_GRS';
    New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
    Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }

    $osDiskName = 'osDisk';
    $osDiskCaching = 'ReadWrite';
    $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
    $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";

    $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;

    # OS & Image
    $user = "localadmin";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
    $vhdContainer = "https://$stoname.blob.core.windows.net/test";

    $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;
    $p = Set-AzVMSourceImage -VM $p -PublisherName MicrosoftSQLServer -Offer SQL2017-WS2019 -Skus Enterprise -Version "latest"

    # Virtual Machine
    New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

    #Do actual changes and work here

    $extensionName = "SqlIaasExtension";

    # 1) Installs the SqlIaaS extension by calling Set-AzVMSqlServerExtension cmdlet on a VM, with auto patching and auto backup settings.
    $aps = New-AzVMSqlServerAutoPatchingConfig -Enable -DayOfWeek "Thursday" -MaintenanceWindowStartingHour 20 -MaintenanceWindowDuration 120 -PatchCategory "Important"
    $storageBlobUrl = "https://$stoname.blob.core.windows.net";
    $storageKey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname)[0].Value;
    $storageKeyAsSecureString = ConvertTo-SecureString -String $storageKey -AsPlainText -Force;
    $abs = New-AzVMSqlServerAutoBackupConfig -Enable -RetentionPeriodInDays 5 -ResourceGroupName $rgname -StorageUri $storageBlobUrl -StorageKey $storageKeyAsSecureString `
        -BackupScheduleType Manual -BackupSystemDbs -FullBackupStartHour 10 -FullBackupWindowInHours 5 -FullBackupFrequency Daily -LogBackupFrequencyInMinutes 30
    Set-AzVMSqlServerExtension -AutoPatchingSettings $aps -AutoBackupSettings $abs -ResourceGroupName $rgname -VMName $vmname -Version "2.0" -Verbose -Name $extensionName;

    # 2) Calls Get-AzVMSqlServerExtension cmdlet to check the status of the extension installation.
    $extension = Get-AzVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;

    # 3) Verifies settings are correct given input
    Assert-AreEqual $extension.AutoPatchingSettings.DayOfWeek "Thursday"
    Assert-AreEqual $extension.AutoPatchingSettings.MaintenanceWindowStartingHour 20
    Assert-AreEqual $extension.AutoPatchingSettings.MaintenanceWindowDuration 120
    Assert-AreEqual $extension.AutoPatchingSettings.PatchCategory "Important"

    Assert-AreEqual $extension.AutoBackupSettings.RetentionPeriod 5
    Assert-AreEqual $extension.AutoBackupSettings.Enable $true
    Assert-AreEqual $extension.AutoBackupSettings.BackupScheduleType "Manual"
    Assert-AreEqual $extension.AutoBackupSettings.FullBackupFrequency "Daily"
    Assert-AreEqual $extension.AutoBackupSettings.BackupSystemDbs $true
    Assert-AreEqual $extension.AutoBackupSettings.FullBackupStartTime 10
    Assert-AreEqual $extension.AutoBackupSettings.FullBackupWindowHours 5
    Assert-AreEqual $extension.AutoBackupSettings.LogBackupFrequency 30

    # 4) Verify the autoUpgradeMinorVersion is true by Default
    $ext = Get-AzVMExtension -ResourceGroupName $rgName -VMName $vmName -Name $extensionName
    Assert-AreEqual $ext.autoUpgradeMinorVersion $true

    # 5) Update extension values
    $aps = New-AzVMSqlServerAutoPatchingConfig -Enable -DayOfWeek "Monday" -MaintenanceWindowStartingHour 20 -MaintenanceWindowDuration 120 -PatchCategory "Important"
    $abs = New-AzVMSqlServerAutoBackupConfig -Enable -RetentionPeriodInDays 5 -ResourceGroupName $rgname -StorageUri $storageBlobUrl `
            -StorageKey $storageKeyAsSecureString -BackupScheduleType Automated -BackupSystemDbs
    Set-AzVMSqlServerExtension -AutoPatchingSettings $aps -AutoBackupSettings $abs -ResourceGroupName $rgname -VMName $vmname -Version "2.0" -Verbose -Name $extensionName;
    Start-TestSleep -Seconds 30

    # 6) Verify changes
    $extension = Get-AzVMSqlServerExtension -ResourceGroupName $rgname -VmName $vmName -Name $extensionName;
    Assert-AreEqual $extension.AutoPatchingSettings.DayOfWeek "Monday"
    Assert-AreEqual $extension.AutoBackupSettings.RetentionPeriod 5
    Assert-AreEqual $extension.AutoBackupSettings.Enable $true
    Assert-AreEqual $extension.AutoBackupSettings.BackupScheduleType "Automated"
    Assert-AreEqual $extension.AutoBackupSettings.BackupSystemDbs $true

    # 7) Test with correct Name and Version
    Set-AzVMSqlServerExtension -AutoPatchingSettings $aps -AutoBackupSettings $abs -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "2.0"

    # 8) Test with correct Name and incorrect Version
    Set-AzVMSqlServerExtension -AutoPatchingSettings $aps -AutoBackupSettings $abs -ResourceGroupName $rgname -VMName $vmName -Name $extensionName -Version "2.*"
}

#helper methods for ARM
function Get-DefaultResourceGroupLocation
{
    if ((Get-ComputeTestMode) -ne 'Playback')
    {
        $namespace = "Microsoft.Resources"
        $type = "resourceGroups"
        $location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type}

        if ($location -eq $null)
        {
            return "West US"
        } else
        {
            return $location.Locations[0]
        }
    }
    return "West US"
}
