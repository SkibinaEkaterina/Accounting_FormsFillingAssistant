﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accounting_FormsFillingAssistant.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PathToDataBase {
            get {
                return ((string)(this["PathToDataBase"]));
            }
            set {
                this["PathToDataBase"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>ak_01_Number</string>
  <string>ak_02_CurrentDate</string>
  <string>ak_03_PaymentType</string>
  <string>ak_04_SumInCuirsive</string>
  <string>ak_05_INN_Payer</string>
  <string>ak_06_SumNumber</string>
  <string>ak_07_PayerName</string>
  <string>ak_08_PayerBankAccount</string>
  <string>ak_09_Payer_BankName</string>
  <string>ak_10_Payer_Bank_BIK</string>
  <string>ak_11_Payer_Bank_BankAccount</string>
  <string>ak_12_Recipient_BankName</string>
  <string>ak_13_Recipient_Bank_BIK</string>
  <string>ak_14_Recipient_Bank_BankAccount</string>
  <string>ak_15_INN_Recipient</string>
  <string>ak_16_RecipientName</string>
  <string>ak_17_Recipient_BankAccount</string>
  <string>ak_18_OperationType</string>
  <string>ak_19_NazPL</string>
  <string>ak_20_Code</string>
  <string>ak_21_AkTimePeriod</string>
  <string>ak_22_ResField</string>
  <string>ak_23_AkType</string>
  <string>ak_24_PaymentCondition</string>
  <string>ak_25_ConditionsDetails</string>
  <string>ak_26_SubmissionPayment</string>
  <string>ak_27_AdditionalDetails</string>
  <string>ak_28_Recipient_BankAccount_2</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection ListOfBookmarksNames_Accreditiv {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ListOfBookmarksNames_Accreditiv"]));
            }
            set {
                this["ListOfBookmarksNames_Accreditiv"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection ListOfBookmarksNames_Inkasso {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ListOfBookmarksNames_Inkasso"]));
            }
            set {
                this["ListOfBookmarksNames_Inkasso"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection ListOfBookmarksNames_PaymentRequirement {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ListOfBookmarksNames_PaymentRequirement"]));
            }
            set {
                this["ListOfBookmarksNames_PaymentRequirement"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection ListOfBookmarksNames_PaymentOrder {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["ListOfBookmarksNames_PaymentOrder"]));
            }
            set {
                this["ListOfBookmarksNames_PaymentOrder"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string PathToWorkingDirectory {
            get {
                return ((string)(this["PathToWorkingDirectory"]));
            }
            set {
                this["PathToWorkingDirectory"] = value;
            }
        }
    }
}
