﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuickMon.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("QuickMon.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to -------------
        ///Version 5.0.0
        ///*************
        ///First release of version 5.x
        ///
        ///-------------
        ///Version 5.0.1
        ///*************
        ///File/Directory collector: Search for text in the last X number of lines of a file (Text file implied). 
        ///
        ///-------------
        ///Version 5.0.2
        ///*************
        ///Quick recent list
        ///	Provide option to have it sorted or not.
        ///	More details about which alerts/notifications have been raised/fired in the Collector detail view
        ///	Success, Warning and Error text boxes have context menu with predefined values like [any] a [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string ChangeLog {
            get {
                return ResourceManager.GetString("ChangeLog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;quickMonTemplate&gt;
        ///  &lt;template name=&quot;New Monitor pack with Ping and System health&quot; type=&quot;MonitorPack&quot; class=&quot;MonitorPack&quot; description=&quot;New Monitor pack with Ping and System health&quot;&gt;
        ///    &lt;monitorPack version=&quot;5.0.0&quot; name=&quot;[[MonitorPackName:New Monitor pack]]&quot; typeName=&quot;&quot; enabled=&quot;True&quot; pollingFreqSecOverride=&quot;[[PollingFrequency:60]]&quot;&gt;
        ///      &lt;configVars /&gt;
        ///      &lt;collectorHosts runCorrectiveScripts=&quot;True&quot; stateHistorySize=&quot;100&quot; pollingFreqSecOverride=&quot;[[PollingFrequency:60]]&quot;&gt;
        ///        &lt;metricsExports /&gt;        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string QuickMon5DefaultTemplate {
            get {
                return ResourceManager.GetString("QuickMon5DefaultTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;?xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
        ///&lt;quickMonTemplate&gt;
        ///	&lt;template name=&quot;New MonitorPack&quot; type=&quot;MonitorPack&quot; class=&quot;MonitorPack&quot; description=&quot;Creates new black monitor pack&quot;&gt;
        ///		&lt;monitorPack version=&quot;5.0.0.0&quot; name=&quot;New MonitorPack&quot; typeName=&quot;&quot; enabled=&quot;True&quot; runCorrectiveScripts=&quot;True&quot; stateHistorySize=&quot;100&quot; pollingFreqSecOverride=&quot;30&quot;&gt;
        ///			&lt;configVars /&gt;
        ///			&lt;collectorHosts&gt;
        ///			&lt;/collectorHosts&gt;
        ///			&lt;notifierHosts&gt;
        ///				&lt;notifierHost name=&quot;Debugging&quot; enabled=&quot;True&quot; alertLevel=&quot;Warning&quot; detailLevel=&quot;De [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string QuickMon5DefaultTemplateOLD {
            get {
                return ResourceManager.GetString("QuickMon5DefaultTemplateOLD", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to use master
        ///declare @PageSize varchar(10)
        ///select @PageSize=v.low/1024.0
        ///from master..spt_values v
        ///where v.number=1 and v.type=&apos;E&apos;
        ///
        ///select name as DatabaseName, convert(float,null) as Size
        ///into #tem
        ///From sysdatabases where name like &apos;&lt;Database&gt;&apos; --dbid&gt;4 and 
        ///
        ///declare @SQL varchar (8000)
        ///set @SQL=&apos;&apos;
        ///
        ///while exists (select * from #tem where size is null)
        ///begin
        ///select @SQL=&apos;update #tem set size=(select round(sum(size)*&apos;+@PageSize+&apos;/1024,0) From &apos;+quotename(databasename)+&apos;.dbo.sysfiles) where Datab [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string SelectDatabaseSizeScript {
            get {
                return ResourceManager.GetString("SelectDatabaseSizeScript", resourceCulture);
            }
        }
    }
}
