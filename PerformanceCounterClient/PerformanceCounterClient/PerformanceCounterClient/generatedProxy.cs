﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://PerformanceCounterServer", ConfigurationName="IPerformanceCounter")]
public interface IPerformanceCounter
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://PerformanceCounterServer/IPerformanceCounter/AddHostNameAndIP", ReplyAction="http://PerformanceCounterServer/IPerformanceCounter/AddHostNameAndIPResponse")]
    bool AddHostNameAndIP(string HostName, string IP);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://PerformanceCounterServer/IPerformanceCounter/AddHostNameAndIP", ReplyAction="http://PerformanceCounterServer/IPerformanceCounter/AddHostNameAndIPResponse")]
    System.Threading.Tasks.Task<bool> AddHostNameAndIPAsync(string HostName, string IP);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://PerformanceCounterServer/IPerformanceCounter/AddRamAndCpuvalue", ReplyAction="http://PerformanceCounterServer/IPerformanceCounter/AddRamAndCpuvalueResponse")]
    bool AddRamAndCpuvalue(float cpu, float ram, string HostName);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://PerformanceCounterServer/IPerformanceCounter/AddRamAndCpuvalue", ReplyAction="http://PerformanceCounterServer/IPerformanceCounter/AddRamAndCpuvalueResponse")]
    System.Threading.Tasks.Task<bool> AddRamAndCpuvalueAsync(float cpu, float ram, string HostName);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://PerformanceCounterServer/IPerformanceCounter/AddDriveInfo", ReplyAction="http://PerformanceCounterServer/IPerformanceCounter/AddDriveInfoResponse")]
    bool AddDriveInfo(System.Collections.Generic.Dictionary<string, long> DriveInfo, string HostName);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://PerformanceCounterServer/IPerformanceCounter/AddDriveInfo", ReplyAction="http://PerformanceCounterServer/IPerformanceCounter/AddDriveInfoResponse")]
    System.Threading.Tasks.Task<bool> AddDriveInfoAsync(System.Collections.Generic.Dictionary<string, long> DriveInfo, string HostName);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IPerformanceCounterChannel : IPerformanceCounter, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class PerformanceCounterClient : System.ServiceModel.ClientBase<IPerformanceCounter>, IPerformanceCounter
{
    
    public PerformanceCounterClient()
    {
    }
    
    public PerformanceCounterClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public PerformanceCounterClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PerformanceCounterClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public PerformanceCounterClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public bool AddHostNameAndIP(string HostName, string IP)
    {
        return base.Channel.AddHostNameAndIP(HostName, IP);
    }
    
    public System.Threading.Tasks.Task<bool> AddHostNameAndIPAsync(string HostName, string IP)
    {
        return base.Channel.AddHostNameAndIPAsync(HostName, IP);
    }
    
    public bool AddRamAndCpuvalue(float cpu, float ram, string HostName)
    {
        return base.Channel.AddRamAndCpuvalue(cpu, ram, HostName);
    }
    
    public System.Threading.Tasks.Task<bool> AddRamAndCpuvalueAsync(float cpu, float ram, string HostName)
    {
        return base.Channel.AddRamAndCpuvalueAsync(cpu, ram, HostName);
    }
    
    public bool AddDriveInfo(System.Collections.Generic.Dictionary<string, long> DriveInfo, string HostName)
    {
        return base.Channel.AddDriveInfo(DriveInfo, HostName);
    }
    
    public System.Threading.Tasks.Task<bool> AddDriveInfoAsync(System.Collections.Generic.Dictionary<string, long> DriveInfo, string HostName)
    {
        return base.Channel.AddDriveInfoAsync(DriveInfo, HostName);
    }
}