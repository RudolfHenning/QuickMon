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
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap _246_7 {
            get {
                object obj = ResourceManager.GetObject("246_7", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap add {
            get {
                object obj = ResourceManager.GetObject("add", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;collectorAgent name=&quot;&quot; type=&quot;&quot; enabled=&quot;True&quot;&gt;
        ///    {0}
        ///&lt;/collectorAgent&gt;.
        /// </summary>
        internal static string BlankTemplateCollectorAgent {
            get {
                return ResourceManager.GetString("BlankTemplateCollectorAgent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;collectorHost uniqueId=&quot;&quot; name=&quot;&quot; enabled=&quot;True&quot; expandOnStart=&quot;True&quot; dependOnParentId=&quot;&quot; agentCheckSequence=&quot;All&quot; childCheckBehaviour=&quot;OnlyRunOnSuccess&quot; repeatAlertInXMin=&quot;0&quot; alertOnceInXMin=&quot;0&quot; delayErrWarnAlertForXSec=&quot;0&quot; repeatAlertInXPolls=&quot;0&quot; alertOnceInXPolls=&quot;0&quot; delayErrWarnAlertForXPolls=&quot;0&quot; correctiveScriptDisabled=&quot;False&quot; correctiveScriptOnWarningPath=&quot;&quot; correctiveScriptOnErrorPath=&quot;&quot; restorationScriptPath=&quot;&quot; correctiveScriptsOnlyOnStateChange=&quot;False&quot; enableRemoteExecute=&quot;False&quot; forceRemoteExcut [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BlankTemplateCollectorHost {
            get {
                return ResourceManager.GetString("BlankTemplateCollectorHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;monitorPack version=&quot;4.0.0.0&quot; name=&quot;&quot; typeName=&quot;&quot; enabled=&quot;True&quot; runCorrectiveScripts=&quot;True&quot; stateHistorySize=&quot;100&quot; pollingFreqSecOverride=&quot;30&quot;&gt;
        ///	&lt;configVars /&gt;
        ///    &lt;collectorHosts&gt;
        ///	&lt;/collectorHosts&gt;
        ///    &lt;notifierHosts&gt;
        ///		&lt;notifierHost name=&quot;Default Notifier&quot; enabled=&quot;True&quot; alertLevel=&quot;Warning&quot; detailLevel=&quot;Detail&quot; attendedOptionOverride=&quot;OnlyAttended&quot;&gt;
        ///			&lt;notifierAgents&gt;
        ///				&lt;notifierAgent name=&quot;Memory agent&quot; type=&quot;InMemoryNotifier&quot;&gt;
        ///					&lt;config&gt;&lt;inMemory maxEntryCount=&quot;99999&quot; /&gt;&lt;/config&gt;
        ///				 [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BlankTemplateMonitorPack {
            get {
                return ResourceManager.GetString("BlankTemplateMonitorPack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;notifierAgent name=&quot;&quot; type=&quot;&quot; enabled=&quot;True&quot;&gt;
        ///    {0}
        ///&lt;/notifierAgent&gt;.
        /// </summary>
        internal static string BlankTemplateNotifierAgent {
            get {
                return ResourceManager.GetString("BlankTemplateNotifierAgent", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;notifierHost name=&quot;&quot; enabled=&quot;True&quot; alertLevel=&quot;Debug&quot; detailLevel=&quot;Detail&quot; attendedOptionOverride=&quot;AttendedAndUnAttended&quot;&gt;
        ///    &lt;!-- collectorHosts --&gt;
        ///    &lt;collectorHosts&gt;
        ///    &lt;/collectorHosts&gt;
        ///    &lt;!-- ServiceWindows --&gt;
        ///    &lt;serviceWindows&gt;
        ///    &lt;/serviceWindows&gt;
        ///    &lt;!-- Config variables --&gt;
        ///    &lt;configVars&gt;
        ///    &lt;/configVars&gt;
        ///    &lt;!-- notifierAgents --&gt;
        ///    &lt;notifierAgents&gt;
        ///		&lt;notifierAgent name=&quot;Debugger agent&quot; type=&quot;InMemoryNotifier&quot; enabled=&quot;True&quot;&gt;
        ///			&lt;config&gt;
        ///			&lt;inMemory maxEntryCount [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string BlankTemplateNotifierHost {
            get {
                return ResourceManager.GetString("BlankTemplateNotifierHost", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap BlueArcTopRight {
            get {
                object obj = ResourceManager.GetObject("BlueArcTopRight", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap calculator {
            get {
                object obj = ResourceManager.GetObject("calculator", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap doc_addnew {
            get {
                object obj = ResourceManager.GetObject("doc_addnew", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap doc_export {
            get {
                object obj = ResourceManager.GetObject("doc_export", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap doc_remove3 {
            get {
                object obj = ResourceManager.GetObject("doc_remove3", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap doc_upload {
            get {
                object obj = ResourceManager.GetObject("doc_upload", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Down16x16 {
            get {
                object obj = ResourceManager.GetObject("Down16x16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap download {
            get {
                object obj = ResourceManager.GetObject("download", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap FindDoc {
            get {
                object obj = ResourceManager.GetObject("FindDoc", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Icon similar to (Icon).
        /// </summary>
        internal static System.Drawing.Icon FindDoc1 {
            get {
                object obj = ResourceManager.GetObject("FindDoc1", resourceCulture);
                return ((System.Drawing.Icon)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap FindDoc24x24 {
            get {
                object obj = ResourceManager.GetObject("FindDoc24x24", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap folder_add {
            get {
                object obj = ResourceManager.GetObject("folder_add", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ForbiddenGray16x16 {
            get {
                object obj = ResourceManager.GetObject("ForbiddenGray16x16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap GearWithPlus {
            get {
                object obj = ResourceManager.GetObject("GearWithPlus", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap GearWithPlusGreen {
            get {
                object obj = ResourceManager.GetObject("GearWithPlusGreen", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap helpbwy16x16 {
            get {
                object obj = ResourceManager.GetObject("helpbwy16x16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap MenuBlueShade {
            get {
                object obj = ResourceManager.GetObject("MenuBlueShade", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap NoGo {
            get {
                object obj = ResourceManager.GetObject("NoGo", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap ok16x16 {
            get {
                object obj = ResourceManager.GetObject("ok16x16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap OUTLLIBR_9825 {
            get {
                object obj = ResourceManager.GetObject("OUTLLIBR_9825", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap pastewithedit {
            get {
                object obj = ResourceManager.GetObject("pastewithedit", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Plus16x16 {
            get {
                object obj = ResourceManager.GetObject("Plus16x16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap proc2 {
            get {
                object obj = ResourceManager.GetObject("proc2", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap refresh24x24 {
            get {
                object obj = ResourceManager.GetObject("refresh24x24", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap save {
            get {
                object obj = ResourceManager.GetObject("save", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap save16x16 {
            get {
                object obj = ResourceManager.GetObject("save16x16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap settings_16 {
            get {
                object obj = ResourceManager.GetObject("settings_16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap stop {
            get {
                object obj = ResourceManager.GetObject("stop", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap stop16x16 {
            get {
                object obj = ResourceManager.GetObject("stop16x16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap triang_yellow16x16 {
            get {
                object obj = ResourceManager.GetObject("triang_yellow16x16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap TriangleRight {
            get {
                object obj = ResourceManager.GetObject("TriangleRight", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap undo {
            get {
                object obj = ResourceManager.GetObject("undo", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap Up16x16 {
            get {
                object obj = ResourceManager.GetObject("Up16x16", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   Looks up a localized resource of type System.Drawing.Bitmap.
        /// </summary>
        internal static System.Drawing.Bitmap whack {
            get {
                object obj = ResourceManager.GetObject("whack", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
    }
}
