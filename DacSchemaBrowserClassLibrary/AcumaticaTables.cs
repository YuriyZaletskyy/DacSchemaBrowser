using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableSchemaReader
{
	[Serializable]
	public class AcumaticaTables : IBqlTable
	{

		[PXDBString(50, IsUnicode = true, InputMask = "")]
		[PXUIField(DisplayName = "Tabel Catalog")]
		public string TABLECATALOG { get; set; }

		[PXDBString(50, IsFixed = true, InputMask = "")]
		[PXUIField(DisplayName = "Table Schema")]
		public string TABLESCHEMA { get; set; }

		[PXDBString(50, IsUnicode = true, InputMask = "")]
		[PXUIField(DisplayName = "Choose table")]
		[PXDefault(TypeCode.String, "SOOrder")]
		[PXSelector(typeof(AcumaticaTables.tableName), DescriptionField = typeof(AcumaticaTables.tableName))]
		public string TABLENAME
		{
			get
			{
				return this._TABLENAME;
			}
			set
			{
				this._TABLENAME = value;
			}
		}

		[PXDBString(50, IsUnicode = true, InputMask = "")]
		[PXUIField(DisplayName = "Table Type")]
		public string TABLETYPE { get; set; }

		private string _TABLENAME;

		public abstract class tableCatalog : IBqlField, IBqlOperand
		{
		}

		public abstract class tableSchema : IBqlField, IBqlOperand
		{
		}

		public abstract class tableName : IBqlField, IBqlOperand
		{
		}

		public abstract class tableType : IBqlField, IBqlOperand
		{
		}
	}
}
