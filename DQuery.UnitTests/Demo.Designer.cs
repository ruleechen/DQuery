﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace DQuery.UnitTests
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class DemoEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new DemoEntities object using the connection string found in the 'DemoEntities' section of the application configuration file.
        /// </summary>
        public DemoEntities() : base("name=DemoEntities", "DemoEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DemoEntities object.
        /// </summary>
        public DemoEntities(string connectionString) : base(connectionString, "DemoEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new DemoEntities object.
        /// </summary>
        public DemoEntities(EntityConnection connection) : base(connection, "DemoEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Property> Properties
        {
            get
            {
                if ((_Properties == null))
                {
                    _Properties = base.CreateObjectSet<Property>("Properties");
                }
                return _Properties;
            }
        }
        private ObjectSet<Property> _Properties;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the Properties EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToProperties(Property property)
        {
            base.AddObject("Properties", property);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="DemoModel", Name="Property")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Property : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Property object.
        /// </summary>
        /// <param name="propertyID">Initial value of the PropertyID property.</param>
        /// <param name="useCustomWeekend">Initial value of the UseCustomWeekend property.</param>
        /// <param name="enableStayLengthDiscount">Initial value of the EnableStayLengthDiscount property.</param>
        /// <param name="enableEarlyBirdDiscount">Initial value of the EnableEarlyBirdDiscount property.</param>
        /// <param name="enableLastMinuteDiscount">Initial value of the EnableLastMinuteDiscount property.</param>
        /// <param name="enablePricingGroups">Initial value of the EnablePricingGroups property.</param>
        /// <param name="enableSmallPartyDiscount">Initial value of the EnableSmallPartyDiscount property.</param>
        /// <param name="isDraft">Initial value of the IsDraft property.</param>
        public static Property CreateProperty(global::System.Int32 propertyID, global::System.Boolean useCustomWeekend, global::System.Boolean enableStayLengthDiscount, global::System.Boolean enableEarlyBirdDiscount, global::System.Boolean enableLastMinuteDiscount, global::System.Boolean enablePricingGroups, global::System.Boolean enableSmallPartyDiscount, global::System.Boolean isDraft)
        {
            Property property = new Property();
            property.PropertyID = propertyID;
            property.UseCustomWeekend = useCustomWeekend;
            property.EnableStayLengthDiscount = enableStayLengthDiscount;
            property.EnableEarlyBirdDiscount = enableEarlyBirdDiscount;
            property.EnableLastMinuteDiscount = enableLastMinuteDiscount;
            property.EnablePricingGroups = enablePricingGroups;
            property.EnableSmallPartyDiscount = enableSmallPartyDiscount;
            property.IsDraft = isDraft;
            return property;
        }

        #endregion

        #region Simple Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 PropertyID
        {
            get
            {
                return _PropertyID;
            }
            set
            {
                if (_PropertyID != value)
                {
                    OnPropertyIDChanging(value);
                    ReportPropertyChanging("PropertyID");
                    _PropertyID = StructuralObject.SetValidValue(value, "PropertyID");
                    ReportPropertyChanged("PropertyID");
                    OnPropertyIDChanged();
                }
            }
        }
        private global::System.Int32 _PropertyID;
        partial void OnPropertyIDChanging(global::System.Int32 value);
        partial void OnPropertyIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> CompanyID
        {
            get
            {
                return _CompanyID;
            }
            set
            {
                OnCompanyIDChanging(value);
                ReportPropertyChanging("CompanyID");
                _CompanyID = StructuralObject.SetValidValue(value, "CompanyID");
                ReportPropertyChanged("CompanyID");
                OnCompanyIDChanged();
            }
        }
        private Nullable<global::System.Int32> _CompanyID;
        partial void OnCompanyIDChanging(Nullable<global::System.Int32> value);
        partial void OnCompanyIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> CreatedDate
        {
            get
            {
                return _CreatedDate;
            }
            set
            {
                OnCreatedDateChanging(value);
                ReportPropertyChanging("CreatedDate");
                _CreatedDate = StructuralObject.SetValidValue(value, "CreatedDate");
                ReportPropertyChanged("CreatedDate");
                OnCreatedDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _CreatedDate;
        partial void OnCreatedDateChanging(Nullable<global::System.DateTime> value);
        partial void OnCreatedDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PropertyTitle
        {
            get
            {
                return _PropertyTitle;
            }
            set
            {
                OnPropertyTitleChanging(value);
                ReportPropertyChanging("PropertyTitle");
                _PropertyTitle = StructuralObject.SetValidValue(value, true, "PropertyTitle");
                ReportPropertyChanged("PropertyTitle");
                OnPropertyTitleChanged();
            }
        }
        private global::System.String _PropertyTitle;
        partial void OnPropertyTitleChanging(global::System.String value);
        partial void OnPropertyTitleChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ProductTypeID
        {
            get
            {
                return _ProductTypeID;
            }
            set
            {
                OnProductTypeIDChanging(value);
                ReportPropertyChanging("ProductTypeID");
                _ProductTypeID = StructuralObject.SetValidValue(value, "ProductTypeID");
                ReportPropertyChanged("ProductTypeID");
                OnProductTypeIDChanged();
            }
        }
        private Nullable<global::System.Int32> _ProductTypeID;
        partial void OnProductTypeIDChanging(Nullable<global::System.Int32> value);
        partial void OnProductTypeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PropertyName
        {
            get
            {
                return _PropertyName;
            }
            set
            {
                OnPropertyNameChanging(value);
                ReportPropertyChanging("PropertyName");
                _PropertyName = StructuralObject.SetValidValue(value, true, "PropertyName");
                ReportPropertyChanged("PropertyName");
                OnPropertyNameChanged();
            }
        }
        private global::System.String _PropertyName;
        partial void OnPropertyNameChanging(global::System.String value);
        partial void OnPropertyNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Decimal> BreakagesDeposit
        {
            get
            {
                return _BreakagesDeposit;
            }
            set
            {
                OnBreakagesDepositChanging(value);
                ReportPropertyChanging("BreakagesDeposit");
                _BreakagesDeposit = StructuralObject.SetValidValue(value, "BreakagesDeposit");
                ReportPropertyChanged("BreakagesDeposit");
                OnBreakagesDepositChanged();
            }
        }
        private Nullable<global::System.Decimal> _BreakagesDeposit;
        partial void OnBreakagesDepositChanging(Nullable<global::System.Decimal> value);
        partial void OnBreakagesDepositChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> TermsID
        {
            get
            {
                return _TermsID;
            }
            set
            {
                OnTermsIDChanging(value);
                ReportPropertyChanging("TermsID");
                _TermsID = StructuralObject.SetValidValue(value, "TermsID");
                ReportPropertyChanged("TermsID");
                OnTermsIDChanged();
            }
        }
        private Nullable<global::System.Int32> _TermsID;
        partial void OnTermsIDChanging(Nullable<global::System.Int32> value);
        partial void OnTermsIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> CurrencyID
        {
            get
            {
                return _CurrencyID;
            }
            set
            {
                OnCurrencyIDChanging(value);
                ReportPropertyChanging("CurrencyID");
                _CurrencyID = StructuralObject.SetValidValue(value, "CurrencyID");
                ReportPropertyChanged("CurrencyID");
                OnCurrencyIDChanged();
            }
        }
        private Nullable<global::System.Int32> _CurrencyID;
        partial void OnCurrencyIDChanging(Nullable<global::System.Int32> value);
        partial void OnCurrencyIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> RowCompanyID
        {
            get
            {
                return _RowCompanyID;
            }
            set
            {
                OnRowCompanyIDChanging(value);
                ReportPropertyChanging("RowCompanyID");
                _RowCompanyID = StructuralObject.SetValidValue(value, "RowCompanyID");
                ReportPropertyChanged("RowCompanyID");
                OnRowCompanyIDChanged();
            }
        }
        private Nullable<global::System.Int32> _RowCompanyID;
        partial void OnRowCompanyIDChanging(Nullable<global::System.Int32> value);
        partial void OnRowCompanyIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> RowContactID
        {
            get
            {
                return _RowContactID;
            }
            set
            {
                OnRowContactIDChanging(value);
                ReportPropertyChanging("RowContactID");
                _RowContactID = StructuralObject.SetValidValue(value, "RowContactID");
                ReportPropertyChanged("RowContactID");
                OnRowContactIDChanged();
            }
        }
        private Nullable<global::System.Int32> _RowContactID;
        partial void OnRowContactIDChanging(Nullable<global::System.Int32> value);
        partial void OnRowContactIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> UmbracoNodeID
        {
            get
            {
                return _UmbracoNodeID;
            }
            set
            {
                OnUmbracoNodeIDChanging(value);
                ReportPropertyChanging("UmbracoNodeID");
                _UmbracoNodeID = StructuralObject.SetValidValue(value, "UmbracoNodeID");
                ReportPropertyChanged("UmbracoNodeID");
                OnUmbracoNodeIDChanged();
            }
        }
        private Nullable<global::System.Int32> _UmbracoNodeID;
        partial void OnUmbracoNodeIDChanging(Nullable<global::System.Int32> value);
        partial void OnUmbracoNodeIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> PropertyReference
        {
            get
            {
                return _PropertyReference;
            }
            set
            {
                OnPropertyReferenceChanging(value);
                ReportPropertyChanging("PropertyReference");
                _PropertyReference = StructuralObject.SetValidValue(value, "PropertyReference");
                ReportPropertyChanged("PropertyReference");
                OnPropertyReferenceChanged();
            }
        }
        private Nullable<global::System.Int32> _PropertyReference;
        partial void OnPropertyReferenceChanging(Nullable<global::System.Int32> value);
        partial void OnPropertyReferenceChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String RentalNotes
        {
            get
            {
                return _RentalNotes;
            }
            set
            {
                OnRentalNotesChanging(value);
                ReportPropertyChanging("RentalNotes");
                _RentalNotes = StructuralObject.SetValidValue(value, true, "RentalNotes");
                ReportPropertyChanged("RentalNotes");
                OnRentalNotesChanged();
            }
        }
        private global::System.String _RentalNotes;
        partial void OnRentalNotesChanging(global::System.String value);
        partial void OnRentalNotesChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> ContractRenewalDate
        {
            get
            {
                return _ContractRenewalDate;
            }
            set
            {
                OnContractRenewalDateChanging(value);
                ReportPropertyChanging("ContractRenewalDate");
                _ContractRenewalDate = StructuralObject.SetValidValue(value, "ContractRenewalDate");
                ReportPropertyChanged("ContractRenewalDate");
                OnContractRenewalDateChanged();
            }
        }
        private Nullable<global::System.DateTime> _ContractRenewalDate;
        partial void OnContractRenewalDateChanging(Nullable<global::System.DateTime> value);
        partial void OnContractRenewalDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean UseCustomWeekend
        {
            get
            {
                return _UseCustomWeekend;
            }
            set
            {
                OnUseCustomWeekendChanging(value);
                ReportPropertyChanging("UseCustomWeekend");
                _UseCustomWeekend = StructuralObject.SetValidValue(value, "UseCustomWeekend");
                ReportPropertyChanged("UseCustomWeekend");
                OnUseCustomWeekendChanged();
            }
        }
        private global::System.Boolean _UseCustomWeekend;
        partial void OnUseCustomWeekendChanging(global::System.Boolean value);
        partial void OnUseCustomWeekendChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean EnableStayLengthDiscount
        {
            get
            {
                return _EnableStayLengthDiscount;
            }
            set
            {
                OnEnableStayLengthDiscountChanging(value);
                ReportPropertyChanging("EnableStayLengthDiscount");
                _EnableStayLengthDiscount = StructuralObject.SetValidValue(value, "EnableStayLengthDiscount");
                ReportPropertyChanged("EnableStayLengthDiscount");
                OnEnableStayLengthDiscountChanged();
            }
        }
        private global::System.Boolean _EnableStayLengthDiscount;
        partial void OnEnableStayLengthDiscountChanging(global::System.Boolean value);
        partial void OnEnableStayLengthDiscountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean EnableEarlyBirdDiscount
        {
            get
            {
                return _EnableEarlyBirdDiscount;
            }
            set
            {
                OnEnableEarlyBirdDiscountChanging(value);
                ReportPropertyChanging("EnableEarlyBirdDiscount");
                _EnableEarlyBirdDiscount = StructuralObject.SetValidValue(value, "EnableEarlyBirdDiscount");
                ReportPropertyChanged("EnableEarlyBirdDiscount");
                OnEnableEarlyBirdDiscountChanged();
            }
        }
        private global::System.Boolean _EnableEarlyBirdDiscount;
        partial void OnEnableEarlyBirdDiscountChanging(global::System.Boolean value);
        partial void OnEnableEarlyBirdDiscountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean EnableLastMinuteDiscount
        {
            get
            {
                return _EnableLastMinuteDiscount;
            }
            set
            {
                OnEnableLastMinuteDiscountChanging(value);
                ReportPropertyChanging("EnableLastMinuteDiscount");
                _EnableLastMinuteDiscount = StructuralObject.SetValidValue(value, "EnableLastMinuteDiscount");
                ReportPropertyChanged("EnableLastMinuteDiscount");
                OnEnableLastMinuteDiscountChanged();
            }
        }
        private global::System.Boolean _EnableLastMinuteDiscount;
        partial void OnEnableLastMinuteDiscountChanging(global::System.Boolean value);
        partial void OnEnableLastMinuteDiscountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean EnablePricingGroups
        {
            get
            {
                return _EnablePricingGroups;
            }
            set
            {
                OnEnablePricingGroupsChanging(value);
                ReportPropertyChanging("EnablePricingGroups");
                _EnablePricingGroups = StructuralObject.SetValidValue(value, "EnablePricingGroups");
                ReportPropertyChanged("EnablePricingGroups");
                OnEnablePricingGroupsChanged();
            }
        }
        private global::System.Boolean _EnablePricingGroups;
        partial void OnEnablePricingGroupsChanging(global::System.Boolean value);
        partial void OnEnablePricingGroupsChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean EnableSmallPartyDiscount
        {
            get
            {
                return _EnableSmallPartyDiscount;
            }
            set
            {
                OnEnableSmallPartyDiscountChanging(value);
                ReportPropertyChanging("EnableSmallPartyDiscount");
                _EnableSmallPartyDiscount = StructuralObject.SetValidValue(value, "EnableSmallPartyDiscount");
                ReportPropertyChanged("EnableSmallPartyDiscount");
                OnEnableSmallPartyDiscountChanged();
            }
        }
        private global::System.Boolean _EnableSmallPartyDiscount;
        partial void OnEnableSmallPartyDiscountChanging(global::System.Boolean value);
        partial void OnEnableSmallPartyDiscountChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> ChangeoverDayID
        {
            get
            {
                return _ChangeoverDayID;
            }
            set
            {
                OnChangeoverDayIDChanging(value);
                ReportPropertyChanging("ChangeoverDayID");
                _ChangeoverDayID = StructuralObject.SetValidValue(value, "ChangeoverDayID");
                ReportPropertyChanged("ChangeoverDayID");
                OnChangeoverDayIDChanged();
            }
        }
        private Nullable<global::System.Int32> _ChangeoverDayID;
        partial void OnChangeoverDayIDChanging(Nullable<global::System.Int32> value);
        partial void OnChangeoverDayIDChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Boolean IsDraft
        {
            get
            {
                return _IsDraft;
            }
            set
            {
                OnIsDraftChanging(value);
                ReportPropertyChanging("IsDraft");
                _IsDraft = StructuralObject.SetValidValue(value, "IsDraft");
                ReportPropertyChanged("IsDraft");
                OnIsDraftChanged();
            }
        }
        private global::System.Boolean _IsDraft;
        partial void OnIsDraftChanging(global::System.Boolean value);
        partial void OnIsDraftChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String LinkedPropertyIds
        {
            get
            {
                return _LinkedPropertyIds;
            }
            set
            {
                OnLinkedPropertyIdsChanging(value);
                ReportPropertyChanging("LinkedPropertyIds");
                _LinkedPropertyIds = StructuralObject.SetValidValue(value, true, "LinkedPropertyIds");
                ReportPropertyChanged("LinkedPropertyIds");
                OnLinkedPropertyIdsChanged();
            }
        }
        private global::System.String _LinkedPropertyIds;
        partial void OnLinkedPropertyIdsChanging(global::System.String value);
        partial void OnLinkedPropertyIdsChanged();

        #endregion

    }

    #endregion

}
