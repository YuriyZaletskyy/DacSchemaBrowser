using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TableSchemaReader
{
	[Serializable]
	public class TableSchemaFields : IBqlTable
	{
		[PXBool]
		[PXUIField(DisplayName = "Is Key")]
		public bool ISKey { get; set; }


		[PXString(255, IsUnicode = true, InputMask = "", IsKey = true)]
		[PXUIField(DisplayName = "Field Name")]
		public string Name { get; set; }

		[PXString(50, IsUnicode = true, InputMask = "")]
		[PXUIField(DisplayName = "Display name")]
		public string DisplayName { get; set; }

		[PXString(255, IsUnicode = true, InputMask = "")]
		[PXUIField(DisplayName = "Data Lengh")]
		public string DataLengthDefaultValue { get; set; }

		[PXString(255, IsUnicode = true, InputMask = "")]
		[PXUIField(DisplayName = "Data Type")]
		public string DataType { get; set; }

		public class iSkey : IBqlField, IBqlOperand
		{
		}

		public class nAme : IBqlField, IBqlOperand
		{
		}

		public class dIsplayName : IBqlField, IBqlOperand
		{
		}

		public class dAtaLengthDefaultValue : IBqlField, IBqlOperand
		{
		}

		public class dAtaType : IBqlField, IBqlOperand
		{
		}
	}
}
