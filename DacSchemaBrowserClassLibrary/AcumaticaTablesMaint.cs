using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PX.Data;

namespace TableSchemaReader
{
	public class AcumaticaTablesMaint : PXGraph<AcumaticaTablesMaint>
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		protected virtual void AcumaticaTables_TABLENAME_FieldUpdated(PXCache cache, PXFieldUpdatedEventArgs e)
		{
			bool flag = e.Row == null;
			if (flag)
			{
				this.GetAllFields("SOOrder");
			}
			else
			{
				AcumaticaTables acumaticaTables = e.Row as AcumaticaTables;
				this.GetAllFields(acumaticaTables.TABLENAME);
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002098 File Offset: 0x00000298
		public List<TableSchemaFields> GetAllFields(string nameTable)
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				try
				{
					Assembly assembly2 = Assembly.LoadFile(assembly.Location);
					bool flag = assembly.ManifestModule.ToString() != "DotNetOpenAuth.Core.dll";
					if (flag)
					{
						foreach (Type type in from x in assembly2.GetTypes()
											  where typeof(IBqlTable).IsAssignableFrom(x) && !x.IsInterface
											  select x)
						{
							this.allDacClaseesNames.Add(type.Name);
							bool flag2 = type.Name == nameTable;
							if (flag2)
							{
								List<PropertyInfo> list = AcumaticaTablesMaint.GetAllProperties(type).ToList<PropertyInfo>();
								for (int j = 0; j < list.Count; j++)
								{
									TableSchemaFields tableSchemaFields = new TableSchemaFields();
									tableSchemaFields.Name = list[j].Name;
									tableSchemaFields.DataType = list[j].PropertyType.ToString();
									foreach (CustomAttributeData customAttributeData in list[j].CustomAttributes)
									{
										for (int k = 0; k < customAttributeData.ConstructorArguments.Count; k++)
										{
											bool flag3 = customAttributeData.ConstructorArguments.Count > 0 && customAttributeData.ConstructorArguments[k].ArgumentType.ToString() == "System.Int32";
											if (flag3)
											{
												tableSchemaFields.DataLengthDefaultValue = customAttributeData.ConstructorArguments[0].Value.ToString();
											}
										}
										for (int l = 0; l < customAttributeData.NamedArguments.Count<CustomAttributeNamedArgument>(); l++)
										{
											bool flag4 = customAttributeData.NamedArguments.Count > 0 && customAttributeData.NamedArguments[l].MemberName == "IsKey";
											if (flag4)
											{
												tableSchemaFields.ISKey = true;
											}
											bool flag5 = customAttributeData.NamedArguments.Count > 0 && customAttributeData.NamedArguments[l].MemberName == "DisplayName";
											if (flag5)
											{
												tableSchemaFields.DisplayName = customAttributeData.NamedArguments[l].TypedValue.Value.ToString();
											}
										}
									}
									bool flag6 = this.allFieldsNames.Any((TableSchemaFields item) => item.Name == tableSchemaFields.Name);
									bool flag7 = !flag6;
									if (flag7)
									{
										this.allFieldsNames.Add(tableSchemaFields);
									}
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					this.notLoadedDlls.Add(assembly.FullName);
				}
			}
			return this.allFieldsNames;
		}

		public static IEnumerable<PropertyInfo> GetAllProperties(Type type)
		{
			bool flag = type == null;
			IEnumerable<PropertyInfo> result;
			if (flag)
			{
				result = Enumerable.Empty<PropertyInfo>();
			}
			else
			{
				BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
				result = type.GetProperties(bindingAttr).Union(AcumaticaTablesMaint.GetAllProperties(type.BaseType));
			}
			
			return result;
		}

		protected virtual IEnumerable acumaticaTablesFieldsView()
		{
			AcumaticaTables acumaticaTables = (AcumaticaTables)GraphHelper.Caches<AcumaticaTables>(this).Current;
			return this.GetAllFields(acumaticaTables.TABLENAME);
		}

		public PXFilter<AcumaticaTables> AcumaticaTablesView;

		public PXSelect<TableSchemaFields> AcumaticaTablesFieldsView;

		public List<string> allDacClaseesNames = new List<string>();

		public List<TableSchemaFields> allFieldsNames = new List<TableSchemaFields>();

		public List<string> notLoadedDlls = new List<string>();
	}
}
