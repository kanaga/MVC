<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="EFMVC.Azure" generation="1" functional="0" release="0" Id="d8db7051-f1b2-4c1e-8982-ac8e3d297581" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="EFMVC.AzureGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="EFMVC.Web:Endpoint1" protocol="http">
          <inToChannel>
            <lBChannelMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/LB:EFMVC.Web:Endpoint1" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="EFMVC.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="EFMVC.WebInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/MapEFMVC.WebInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:EFMVC.Web:Endpoint1">
          <toPorts>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Endpoint1" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapEFMVC.Web:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapEFMVC.WebInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.WebInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="EFMVC.Web" generation="1" functional="0" release="0" software="C:\EFMVC (1)\EFMVC_V1.Beta\EFMVC.Azure\csx\Debug\roles\EFMVC.Web" entryPoint="base\x86\WaHostBootstrapper.exe" parameters="base\x86\WaIISHost.exe " memIndex="1792" hostingEnvironment="frontendadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="Endpoint1" protocol="http" portRanges="80" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;EFMVC.Web&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;EFMVC.Web&quot;&gt;&lt;e name=&quot;Endpoint1&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.WebInstances" />
            <sCSPolicyFaultDomainMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.WebFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyFaultDomain name="EFMVC.WebFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="EFMVC.WebInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="b698b164-b8f9-4ae3-85ed-6998f86c6460" ref="Microsoft.RedDog.Contract\ServiceContract\EFMVC.AzureContract@ServiceDefinition.build">
      <interfacereferences>
        <interfaceReference Id="fd94d57c-22d1-447f-bd6a-da07c5e0a5fd" ref="Microsoft.RedDog.Contract\Interface\EFMVC.Web:Endpoint1@ServiceDefinition.build">
          <inPort>
            <inPortMoniker name="/EFMVC.Azure/EFMVC.AzureGroup/EFMVC.Web:Endpoint1" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>