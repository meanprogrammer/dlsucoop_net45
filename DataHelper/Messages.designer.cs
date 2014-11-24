﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataHelper
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Messages")]
	public partial class MessagesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public MessagesDataContext() : 
				base(global::DataHelper.Properties.Settings.Default.MessagesConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public MessagesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MessagesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MessagesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public MessagesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User
	{
		
		private string _EmpNo;
		
		private string _UserType;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _MiddleName;
		
		private string _Email;
		
		private string _Password;
		
		private string _Address;
		
		private System.Nullable<System.DateTime> _Birthday;
		
		private string _College;
		
		private string _Dept;
		
		private string _PhoneNumber;
		
		private System.Nullable<System.DateTime> _DateConfirmed;
		
		private string _MemberStatus;
		
		private string _DateHired;
		
		private string _Picture;
		
		private string _ATMAccountNo;
		
		private string _TINNo;
		
		private string _SSSNo;
		
		private string _Gender;
		
		private string _CivilStatus;
		
		private string _FatherName;
		
		private string _FatherOccupation;
		
		private string _MotherName;
		
		private string _MotherOccupation;
		
		private string _LegalSpouse;
		
		private string _SpouseEmployer;
		
		private string _BusinessName;
		
		private string _BusinessAddress;
		
		private string _OtherSourceOfIncome;
		
		private string _EmergencyName;
		
		private string _EmergencyAddress;
		
		private string _EmergencyNumber;
		
		public User()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmpNo", DbType="NVarChar(10) NOT NULL", CanBeNull=false)]
		public string EmpNo
		{
			get
			{
				return this._EmpNo;
			}
			set
			{
				if ((this._EmpNo != value))
				{
					this._EmpNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserType", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
		public string UserType
		{
			get
			{
				return this._UserType;
			}
			set
			{
				if ((this._UserType != value))
				{
					this._UserType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this._FirstName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this._LastName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MiddleName", DbType="NVarChar(50)")]
		public string MiddleName
		{
			get
			{
				return this._MiddleName;
			}
			set
			{
				if ((this._MiddleName != value))
				{
					this._MiddleName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="NVarChar(70) NOT NULL", CanBeNull=false)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this._Email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this._Password = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Address", DbType="NVarChar(150)")]
		public string Address
		{
			get
			{
				return this._Address;
			}
			set
			{
				if ((this._Address != value))
				{
					this._Address = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Birthday", DbType="Date")]
		public System.Nullable<System.DateTime> Birthday
		{
			get
			{
				return this._Birthday;
			}
			set
			{
				if ((this._Birthday != value))
				{
					this._Birthday = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_College", DbType="NVarChar(30)")]
		public string College
		{
			get
			{
				return this._College;
			}
			set
			{
				if ((this._College != value))
				{
					this._College = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dept", DbType="NVarChar(30)")]
		public string Dept
		{
			get
			{
				return this._Dept;
			}
			set
			{
				if ((this._Dept != value))
				{
					this._Dept = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhoneNumber", DbType="NVarChar(13) NOT NULL", CanBeNull=false)]
		public string PhoneNumber
		{
			get
			{
				return this._PhoneNumber;
			}
			set
			{
				if ((this._PhoneNumber != value))
				{
					this._PhoneNumber = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateConfirmed", DbType="Date")]
		public System.Nullable<System.DateTime> DateConfirmed
		{
			get
			{
				return this._DateConfirmed;
			}
			set
			{
				if ((this._DateConfirmed != value))
				{
					this._DateConfirmed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MemberStatus", DbType="NVarChar(50)")]
		public string MemberStatus
		{
			get
			{
				return this._MemberStatus;
			}
			set
			{
				if ((this._MemberStatus != value))
				{
					this._MemberStatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateHired", DbType="NVarChar(10)")]
		public string DateHired
		{
			get
			{
				return this._DateHired;
			}
			set
			{
				if ((this._DateHired != value))
				{
					this._DateHired = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Picture", DbType="NVarChar(MAX)")]
		public string Picture
		{
			get
			{
				return this._Picture;
			}
			set
			{
				if ((this._Picture != value))
				{
					this._Picture = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ATMAccountNo", DbType="NVarChar(50)")]
		public string ATMAccountNo
		{
			get
			{
				return this._ATMAccountNo;
			}
			set
			{
				if ((this._ATMAccountNo != value))
				{
					this._ATMAccountNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TINNo", DbType="NVarChar(50)")]
		public string TINNo
		{
			get
			{
				return this._TINNo;
			}
			set
			{
				if ((this._TINNo != value))
				{
					this._TINNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SSSNo", DbType="NVarChar(50)")]
		public string SSSNo
		{
			get
			{
				return this._SSSNo;
			}
			set
			{
				if ((this._SSSNo != value))
				{
					this._SSSNo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Gender", DbType="NVarChar(10)")]
		public string Gender
		{
			get
			{
				return this._Gender;
			}
			set
			{
				if ((this._Gender != value))
				{
					this._Gender = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CivilStatus", DbType="NVarChar(20)")]
		public string CivilStatus
		{
			get
			{
				return this._CivilStatus;
			}
			set
			{
				if ((this._CivilStatus != value))
				{
					this._CivilStatus = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FatherName", DbType="NVarChar(50)")]
		public string FatherName
		{
			get
			{
				return this._FatherName;
			}
			set
			{
				if ((this._FatherName != value))
				{
					this._FatherName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FatherOccupation", DbType="NVarChar(50)")]
		public string FatherOccupation
		{
			get
			{
				return this._FatherOccupation;
			}
			set
			{
				if ((this._FatherOccupation != value))
				{
					this._FatherOccupation = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MotherName", DbType="NVarChar(50)")]
		public string MotherName
		{
			get
			{
				return this._MotherName;
			}
			set
			{
				if ((this._MotherName != value))
				{
					this._MotherName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MotherOccupation", DbType="NVarChar(50)")]
		public string MotherOccupation
		{
			get
			{
				return this._MotherOccupation;
			}
			set
			{
				if ((this._MotherOccupation != value))
				{
					this._MotherOccupation = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LegalSpouse", DbType="NVarChar(50)")]
		public string LegalSpouse
		{
			get
			{
				return this._LegalSpouse;
			}
			set
			{
				if ((this._LegalSpouse != value))
				{
					this._LegalSpouse = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SpouseEmployer", DbType="NVarChar(50)")]
		public string SpouseEmployer
		{
			get
			{
				return this._SpouseEmployer;
			}
			set
			{
				if ((this._SpouseEmployer != value))
				{
					this._SpouseEmployer = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessName", DbType="NVarChar(50)")]
		public string BusinessName
		{
			get
			{
				return this._BusinessName;
			}
			set
			{
				if ((this._BusinessName != value))
				{
					this._BusinessName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessAddress", DbType="NVarChar(150)")]
		public string BusinessAddress
		{
			get
			{
				return this._BusinessAddress;
			}
			set
			{
				if ((this._BusinessAddress != value))
				{
					this._BusinessAddress = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OtherSourceOfIncome", DbType="NVarChar(250)")]
		public string OtherSourceOfIncome
		{
			get
			{
				return this._OtherSourceOfIncome;
			}
			set
			{
				if ((this._OtherSourceOfIncome != value))
				{
					this._OtherSourceOfIncome = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmergencyName", DbType="NVarChar(50)")]
		public string EmergencyName
		{
			get
			{
				return this._EmergencyName;
			}
			set
			{
				if ((this._EmergencyName != value))
				{
					this._EmergencyName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmergencyAddress", DbType="NVarChar(50)")]
		public string EmergencyAddress
		{
			get
			{
				return this._EmergencyAddress;
			}
			set
			{
				if ((this._EmergencyAddress != value))
				{
					this._EmergencyAddress = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmergencyNumber", DbType="NVarChar(50)")]
		public string EmergencyNumber
		{
			get
			{
				return this._EmergencyNumber;
			}
			set
			{
				if ((this._EmergencyNumber != value))
				{
					this._EmergencyNumber = value;
				}
			}
		}
	}
}
#pragma warning restore 1591