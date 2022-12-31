using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Zeyo.DotnetFrameworkViewer.Core
{
  public class DotnetFramework
  {
    public static readonly DotnetFramework V20       = new DotnetFramework("v2.0       ".Trim());
    public static readonly DotnetFramework V30       = new DotnetFramework("v3.0       ".Trim());
    public static readonly DotnetFramework V35       = new DotnetFramework("v3.5       ".Trim());
    public static readonly DotnetFramework V40Client = new DotnetFramework("v4.0 Client".Trim());
    public static readonly DotnetFramework V40Full   = new DotnetFramework("v4.0 Full  ".Trim());
    public static readonly DotnetFramework V4xClient = new DotnetFramework("v4.x Client".Trim());
    public static readonly DotnetFramework V4xFull   = new DotnetFramework("v4.x Full  ".Trim());

    private DotnetFramework(string name)
    {
      this.Name = name;
      /************************************************/
      RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\");
      /************************************************/
      if (this.Name == "v2.0")
      {
        key = key.OpenSubKey("v2.0.50727");
      }
      if (this.Name == "v3.0")
      {
        key = key.OpenSubKey("v3.0");
      }
      if (this.Name == "v3.5")
      {
        key = key.OpenSubKey("v3.5");
      }
      if (this.Name == "v4.0 Client")
      {
        key = key.OpenSubKey("v4.0");
        key = key.OpenSubKey("Client");
      }
      if (this.Name == "v4.0 Full")
      {
        key = key.OpenSubKey("v4.0");
        key = key.OpenSubKey("Full");
      }
      if (this.Name == "v4.x Client")
      {
        key = key.OpenSubKey("v4");
        key = key.OpenSubKey("Client");
      }
      if (this.Name == "v4.x Full")
      {
        key = key.OpenSubKey("v4");
        key = key.OpenSubKey("Full");
      }
      /************************************************/
      if (key != null)
      {
        this.Version     = Convert.ToString(key.GetValue("Version".Trim()));
        this.ServicePack = Convert.ToString(key.GetValue("SP     ".Trim()));
        this.Install     = Convert.ToString(key.GetValue("Install".Trim())) == "1" ? "V" : this.Install;
      }
    }

    private string name = "";
    public string Name
    {
      get
      {
        return this.name;
      }
      private set
      {
        this.name = value;
      }
    }

    private string version = "";
    public string Version
    {
      get
      {
        return this.version;
      }
      private set
      {
        this.version = value;
      }
    }

    private string servicePack = "";
    public string ServicePack
    {
      get
      {
        return this.servicePack;
      }
      private set
      {
        this.servicePack = value;
      }
    }

    private string install = "";
    public string Install
    {
      get
      {
        return this.install;
      }
      private set
      {
        this.install = value;
      }
    }

    private static List<DotnetFramework> items = null;
    public static DotnetFramework[] Items
    {
      get
      {
        if (DotnetFramework.items == null)
        {
          DotnetFramework.items = new List<DotnetFramework>();
          /************************************************/
          DotnetFramework.items.Add(DotnetFramework.V20);
          DotnetFramework.items.Add(DotnetFramework.V30);
          DotnetFramework.items.Add(DotnetFramework.V35);
          DotnetFramework.items.Add(DotnetFramework.V40Client);
          DotnetFramework.items.Add(DotnetFramework.V40Full);
          DotnetFramework.items.Add(DotnetFramework.V4xClient);
          DotnetFramework.items.Add(DotnetFramework.V4xFull);
        }
        /************************************************/
        return DotnetFramework.items.ToArray();
      }
    }
  }
}