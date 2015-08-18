﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TonzaDiplomski
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Semafori")]
	public partial class SemaforiDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InserttblSemafor(tblSemafor instance);
    partial void UpdatetblSemafor(tblSemafor instance);
    partial void DeletetblSemafor(tblSemafor instance);
    partial void InserttblUpit(tblUpit instance);
    partial void UpdatetblUpit(tblUpit instance);
    partial void DeletetblUpit(tblUpit instance);
    partial void InserttblVrstaGrafa(tblVrstaGrafa instance);
    partial void UpdatetblVrstaGrafa(tblVrstaGrafa instance);
    partial void DeletetblVrstaGrafa(tblVrstaGrafa instance);
    partial void InserttblRedak(tblRedak instance);
    partial void UpdatetblRedak(tblRedak instance);
    partial void DeletetblRedak(tblRedak instance);
    partial void InserttblCelija(tblCelija instance);
    partial void UpdatetblCelija(tblCelija instance);
    partial void DeletetblCelija(tblCelija instance);
    partial void InserttblStranica(tblStranica instance);
    partial void UpdatetblStranica(tblStranica instance);
    partial void DeletetblStranica(tblStranica instance);
    #endregion
		
		public SemaforiDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SemaforiConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public SemaforiDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SemaforiDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SemaforiDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SemaforiDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<tblSemafor> tblSemafors
		{
			get
			{
				return this.GetTable<tblSemafor>();
			}
		}
		
		public System.Data.Linq.Table<tblUpit> tblUpits
		{
			get
			{
				return this.GetTable<tblUpit>();
			}
		}
		
		public System.Data.Linq.Table<tblVrstaGrafa> tblVrstaGrafas
		{
			get
			{
				return this.GetTable<tblVrstaGrafa>();
			}
		}
		
		public System.Data.Linq.Table<tblRedak> tblRedaks
		{
			get
			{
				return this.GetTable<tblRedak>();
			}
		}
		
		public System.Data.Linq.Table<tblCelija> tblCelijas
		{
			get
			{
				return this.GetTable<tblCelija>();
			}
		}
		
		public System.Data.Linq.Table<tblStranica> tblStranicas
		{
			get
			{
				return this.GetTable<tblStranica>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblSemafor")]
	public partial class tblSemafor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _naziv;
		
		private EntitySet<tblStranica> _tblStranicas;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnazivChanging(string value);
    partial void OnnazivChanged();
    #endregion
		
		public tblSemafor()
		{
			this._tblStranicas = new EntitySet<tblStranica>(new Action<tblStranica>(this.attach_tblStranicas), new Action<tblStranica>(this.detach_tblStranicas));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_naziv", DbType="VarChar(200)")]
		public string naziv
		{
			get
			{
				return this._naziv;
			}
			set
			{
				if ((this._naziv != value))
				{
					this.OnnazivChanging(value);
					this.SendPropertyChanging();
					this._naziv = value;
					this.SendPropertyChanged("naziv");
					this.OnnazivChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblSemafor_tblStranica", Storage="_tblStranicas", ThisKey="Id", OtherKey="semaforID")]
		public EntitySet<tblStranica> tblStranicas
		{
			get
			{
				return this._tblStranicas;
			}
			set
			{
				this._tblStranicas.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblStranicas(tblStranica entity)
		{
			this.SendPropertyChanging();
			entity.tblSemafor = this;
		}
		
		private void detach_tblStranicas(tblStranica entity)
		{
			this.SendPropertyChanging();
			entity.tblSemafor = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblUpit")]
	public partial class tblUpit : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _upit;
		
		private string _naziv;
		
		private EntitySet<tblCelija> _tblCelijas;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnupitChanging(string value);
    partial void OnupitChanged();
    partial void OnnazivChanging(string value);
    partial void OnnazivChanged();
    #endregion
		
		public tblUpit()
		{
			this._tblCelijas = new EntitySet<tblCelija>(new Action<tblCelija>(this.attach_tblCelijas), new Action<tblCelija>(this.detach_tblCelijas));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_upit", DbType="VarChar(5000)")]
		public string upit
		{
			get
			{
				return this._upit;
			}
			set
			{
				if ((this._upit != value))
				{
					this.OnupitChanging(value);
					this.SendPropertyChanging();
					this._upit = value;
					this.SendPropertyChanged("upit");
					this.OnupitChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_naziv", DbType="VarChar(200)")]
		public string naziv
		{
			get
			{
				return this._naziv;
			}
			set
			{
				if ((this._naziv != value))
				{
					this.OnnazivChanging(value);
					this.SendPropertyChanging();
					this._naziv = value;
					this.SendPropertyChanged("naziv");
					this.OnnazivChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblUpit_tblCelija", Storage="_tblCelijas", ThisKey="id", OtherKey="upitID")]
		public EntitySet<tblCelija> tblCelijas
		{
			get
			{
				return this._tblCelijas;
			}
			set
			{
				this._tblCelijas.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblCelijas(tblCelija entity)
		{
			this.SendPropertyChanging();
			entity.tblUpit = this;
		}
		
		private void detach_tblCelijas(tblCelija entity)
		{
			this.SendPropertyChanging();
			entity.tblUpit = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblVrstaGrafa")]
	public partial class tblVrstaGrafa : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _Naziv;
		
		private EntitySet<tblCelija> _tblCelijas;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnNazivChanging(string value);
    partial void OnNazivChanged();
    #endregion
		
		public tblVrstaGrafa()
		{
			this._tblCelijas = new EntitySet<tblCelija>(new Action<tblCelija>(this.attach_tblCelijas), new Action<tblCelija>(this.detach_tblCelijas));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Naziv", DbType="NChar(10)")]
		public string Naziv
		{
			get
			{
				return this._Naziv;
			}
			set
			{
				if ((this._Naziv != value))
				{
					this.OnNazivChanging(value);
					this.SendPropertyChanging();
					this._Naziv = value;
					this.SendPropertyChanged("Naziv");
					this.OnNazivChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblVrstaGrafa_tblCelija", Storage="_tblCelijas", ThisKey="id", OtherKey="grafID")]
		public EntitySet<tblCelija> tblCelijas
		{
			get
			{
				return this._tblCelijas;
			}
			set
			{
				this._tblCelijas.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblCelijas(tblCelija entity)
		{
			this.SendPropertyChanging();
			entity.tblVrstaGrafa = this;
		}
		
		private void detach_tblCelijas(tblCelija entity)
		{
			this.SendPropertyChanging();
			entity.tblVrstaGrafa = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblRedak")]
	public partial class tblRedak : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _stranicaID;
		
		private EntitySet<tblCelija> _tblCelijas;
		
		private EntityRef<tblStranica> _tblStranica;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnstranicaIDChanging(int value);
    partial void OnstranicaIDChanged();
    #endregion
		
		public tblRedak()
		{
			this._tblCelijas = new EntitySet<tblCelija>(new Action<tblCelija>(this.attach_tblCelijas), new Action<tblCelija>(this.detach_tblCelijas));
			this._tblStranica = default(EntityRef<tblStranica>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_stranicaID", DbType="Int NOT NULL")]
		public int stranicaID
		{
			get
			{
				return this._stranicaID;
			}
			set
			{
				if ((this._stranicaID != value))
				{
					if (this._tblStranica.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnstranicaIDChanging(value);
					this.SendPropertyChanging();
					this._stranicaID = value;
					this.SendPropertyChanged("stranicaID");
					this.OnstranicaIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblRedak_tblCelija", Storage="_tblCelijas", ThisKey="id", OtherKey="redakID")]
		public EntitySet<tblCelija> tblCelijas
		{
			get
			{
				return this._tblCelijas;
			}
			set
			{
				this._tblCelijas.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblStranica_tblRedak", Storage="_tblStranica", ThisKey="stranicaID", OtherKey="Id", IsForeignKey=true)]
		public tblStranica tblStranica
		{
			get
			{
				return this._tblStranica.Entity;
			}
			set
			{
				tblStranica previousValue = this._tblStranica.Entity;
				if (((previousValue != value) 
							|| (this._tblStranica.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblStranica.Entity = null;
						previousValue.tblRedaks.Remove(this);
					}
					this._tblStranica.Entity = value;
					if ((value != null))
					{
						value.tblRedaks.Add(this);
						this._stranicaID = value.Id;
					}
					else
					{
						this._stranicaID = default(int);
					}
					this.SendPropertyChanged("tblStranica");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblCelijas(tblCelija entity)
		{
			this.SendPropertyChanging();
			entity.tblRedak = this;
		}
		
		private void detach_tblCelijas(tblCelija entity)
		{
			this.SendPropertyChanging();
			entity.tblRedak = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblCelija")]
	public partial class tblCelija : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Nullable<int> _redakID;
		
		private System.Nullable<int> _grafID;
		
		private System.Nullable<int> _upitID;
		
		private EntityRef<tblUpit> _tblUpit;
		
		private EntityRef<tblVrstaGrafa> _tblVrstaGrafa;
		
		private EntityRef<tblRedak> _tblRedak;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnredakIDChanging(System.Nullable<int> value);
    partial void OnredakIDChanged();
    partial void OngrafIDChanging(System.Nullable<int> value);
    partial void OngrafIDChanged();
    partial void OnupitIDChanging(System.Nullable<int> value);
    partial void OnupitIDChanged();
    #endregion
		
		public tblCelija()
		{
			this._tblUpit = default(EntityRef<tblUpit>);
			this._tblVrstaGrafa = default(EntityRef<tblVrstaGrafa>);
			this._tblRedak = default(EntityRef<tblRedak>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_redakID", DbType="Int")]
		public System.Nullable<int> redakID
		{
			get
			{
				return this._redakID;
			}
			set
			{
				if ((this._redakID != value))
				{
					if (this._tblRedak.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnredakIDChanging(value);
					this.SendPropertyChanging();
					this._redakID = value;
					this.SendPropertyChanged("redakID");
					this.OnredakIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_grafID", DbType="Int")]
		public System.Nullable<int> grafID
		{
			get
			{
				return this._grafID;
			}
			set
			{
				if ((this._grafID != value))
				{
					if (this._tblVrstaGrafa.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OngrafIDChanging(value);
					this.SendPropertyChanging();
					this._grafID = value;
					this.SendPropertyChanged("grafID");
					this.OngrafIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_upitID", DbType="Int")]
		public System.Nullable<int> upitID
		{
			get
			{
				return this._upitID;
			}
			set
			{
				if ((this._upitID != value))
				{
					if (this._tblUpit.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnupitIDChanging(value);
					this.SendPropertyChanging();
					this._upitID = value;
					this.SendPropertyChanged("upitID");
					this.OnupitIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblUpit_tblCelija", Storage="_tblUpit", ThisKey="upitID", OtherKey="id", IsForeignKey=true)]
		public tblUpit tblUpit
		{
			get
			{
				return this._tblUpit.Entity;
			}
			set
			{
				tblUpit previousValue = this._tblUpit.Entity;
				if (((previousValue != value) 
							|| (this._tblUpit.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblUpit.Entity = null;
						previousValue.tblCelijas.Remove(this);
					}
					this._tblUpit.Entity = value;
					if ((value != null))
					{
						value.tblCelijas.Add(this);
						this._upitID = value.id;
					}
					else
					{
						this._upitID = default(Nullable<int>);
					}
					this.SendPropertyChanged("tblUpit");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblVrstaGrafa_tblCelija", Storage="_tblVrstaGrafa", ThisKey="grafID", OtherKey="id", IsForeignKey=true)]
		public tblVrstaGrafa tblVrstaGrafa
		{
			get
			{
				return this._tblVrstaGrafa.Entity;
			}
			set
			{
				tblVrstaGrafa previousValue = this._tblVrstaGrafa.Entity;
				if (((previousValue != value) 
							|| (this._tblVrstaGrafa.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblVrstaGrafa.Entity = null;
						previousValue.tblCelijas.Remove(this);
					}
					this._tblVrstaGrafa.Entity = value;
					if ((value != null))
					{
						value.tblCelijas.Add(this);
						this._grafID = value.id;
					}
					else
					{
						this._grafID = default(Nullable<int>);
					}
					this.SendPropertyChanged("tblVrstaGrafa");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblRedak_tblCelija", Storage="_tblRedak", ThisKey="redakID", OtherKey="id", IsForeignKey=true)]
		public tblRedak tblRedak
		{
			get
			{
				return this._tblRedak.Entity;
			}
			set
			{
				tblRedak previousValue = this._tblRedak.Entity;
				if (((previousValue != value) 
							|| (this._tblRedak.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblRedak.Entity = null;
						previousValue.tblCelijas.Remove(this);
					}
					this._tblRedak.Entity = value;
					if ((value != null))
					{
						value.tblCelijas.Add(this);
						this._redakID = value.id;
					}
					else
					{
						this._redakID = default(Nullable<int>);
					}
					this.SendPropertyChanged("tblRedak");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.tblStranica")]
	public partial class tblStranica : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _naziv;
		
		private int _refreshPeriod;
		
		private int _semaforID;
		
		private int _brojRedova;
		
		private EntitySet<tblRedak> _tblRedaks;
		
		private EntityRef<tblSemafor> _tblSemafor;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnnazivChanging(string value);
    partial void OnnazivChanged();
    partial void OnrefreshPeriodChanging(int value);
    partial void OnrefreshPeriodChanged();
    partial void OnsemaforIDChanging(int value);
    partial void OnsemaforIDChanged();
    partial void OnbrojRedovaChanging(int value);
    partial void OnbrojRedovaChanged();
    #endregion
		
		public tblStranica()
		{
			this._tblRedaks = new EntitySet<tblRedak>(new Action<tblRedak>(this.attach_tblRedaks), new Action<tblRedak>(this.detach_tblRedaks));
			this._tblSemafor = default(EntityRef<tblSemafor>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_naziv", DbType="NChar(10)")]
		public string naziv
		{
			get
			{
				return this._naziv;
			}
			set
			{
				if ((this._naziv != value))
				{
					this.OnnazivChanging(value);
					this.SendPropertyChanging();
					this._naziv = value;
					this.SendPropertyChanged("naziv");
					this.OnnazivChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_refreshPeriod", DbType="Int NOT NULL")]
		public int refreshPeriod
		{
			get
			{
				return this._refreshPeriod;
			}
			set
			{
				if ((this._refreshPeriod != value))
				{
					this.OnrefreshPeriodChanging(value);
					this.SendPropertyChanging();
					this._refreshPeriod = value;
					this.SendPropertyChanged("refreshPeriod");
					this.OnrefreshPeriodChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_semaforID", DbType="Int NOT NULL")]
		public int semaforID
		{
			get
			{
				return this._semaforID;
			}
			set
			{
				if ((this._semaforID != value))
				{
					if (this._tblSemafor.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnsemaforIDChanging(value);
					this.SendPropertyChanging();
					this._semaforID = value;
					this.SendPropertyChanged("semaforID");
					this.OnsemaforIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_brojRedova", DbType="Int NOT NULL")]
		public int brojRedova
		{
			get
			{
				return this._brojRedova;
			}
			set
			{
				if ((this._brojRedova != value))
				{
					this.OnbrojRedovaChanging(value);
					this.SendPropertyChanging();
					this._brojRedova = value;
					this.SendPropertyChanged("brojRedova");
					this.OnbrojRedovaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblStranica_tblRedak", Storage="_tblRedaks", ThisKey="Id", OtherKey="stranicaID")]
		public EntitySet<tblRedak> tblRedaks
		{
			get
			{
				return this._tblRedaks;
			}
			set
			{
				this._tblRedaks.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="tblSemafor_tblStranica", Storage="_tblSemafor", ThisKey="semaforID", OtherKey="Id", IsForeignKey=true)]
		public tblSemafor tblSemafor
		{
			get
			{
				return this._tblSemafor.Entity;
			}
			set
			{
				tblSemafor previousValue = this._tblSemafor.Entity;
				if (((previousValue != value) 
							|| (this._tblSemafor.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._tblSemafor.Entity = null;
						previousValue.tblStranicas.Remove(this);
					}
					this._tblSemafor.Entity = value;
					if ((value != null))
					{
						value.tblStranicas.Add(this);
						this._semaforID = value.Id;
					}
					else
					{
						this._semaforID = default(int);
					}
					this.SendPropertyChanged("tblSemafor");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_tblRedaks(tblRedak entity)
		{
			this.SendPropertyChanging();
			entity.tblStranica = this;
		}
		
		private void detach_tblRedaks(tblRedak entity)
		{
			this.SendPropertyChanging();
			entity.tblStranica = null;
		}
	}
}
#pragma warning restore 1591
