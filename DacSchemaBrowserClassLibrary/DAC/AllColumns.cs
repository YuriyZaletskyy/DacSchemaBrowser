using System;
using PX.Data;

namespace TableSchemaReader
{
    [Serializable]
    public class AllColumns : IBqlTable
    {
        #region Schema
        [PXDBString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Schema")]
        public virtual string Schema { get; set; }
        public abstract class schema : PX.Data.BQL.BqlString.Field<schema> { }
        #endregion

        #region Table
        [PXDBString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Table")]
        public virtual string MyTable { get; set; }
        public abstract class myTable : PX.Data.BQL.BqlString.Field<myTable> { }
        #endregion

        #region Column
        [PXDBString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Column")]
        public virtual string MyColumn { get; set; }
        public abstract class myColumn : PX.Data.BQL.BqlString.Field<myColumn> { }
        #endregion

        #region Data Type
        [PXDBString(128, IsUnicode = true, InputMask = "")]
        [PXUIField(DisplayName = "Data Type")]
        public virtual string DataType { get; set; }
        public abstract class dataType : PX.Data.BQL.BqlString.Field<dataType> { }
        #endregion

        #region Length
        [PXDBShort()]
        [PXUIField(DisplayName = "Length")]
        public virtual short? Length { get; set; }
        public abstract class length : PX.Data.BQL.BqlShort.Field<length> { }
        #endregion

        #region MaxLength
        [PXDBShort()]
        [PXUIField(DisplayName = "Max Length")]
        public virtual short? MaxLength { get; set; }
        public abstract class maxLength : PX.Data.BQL.BqlShort.Field<maxLength> { }
        #endregion

        #region IsId
        [PXDBBool()]
        [PXUIField(DisplayName = "Is id")]
        public virtual bool? IsId { get; set; }
        public abstract class isId : PX.Data.BQL.BqlBool.Field<isId> { }
        #endregion

        #region IsNullable
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Nullable")]
        public virtual bool? IsNullable { get; set; }
        public abstract class isNullable : PX.Data.BQL.BqlBool.Field<isNullable> { }
        #endregion

        #region IsComputed
        [PXDBBool()]
        [PXUIField(DisplayName = "Is Computed")]
        public virtual bool? IsComputed { get; set; }
        public abstract class isComputed : PX.Data.BQL.BqlBool.Field<isComputed> { }
        #endregion

        #region IsUserDefined
        [PXDBBool()]
        [PXUIField(DisplayName = "Is User Defined")]
        public virtual bool? IsUserDefined { get; set; }
        public abstract class isUserDefined : PX.Data.BQL.BqlBool.Field<isUserDefined> { }
        #endregion

        #region DateModified
        [PXDBDate()]
        [PXUIField(DisplayName = "Date Modified")]
        public virtual DateTime? DateModified { get; set; }
        public abstract class dateModified : PX.Data.BQL.BqlDateTime.Field<dateModified> { }
        #endregion

        #region DateCreated
        [PXDBDate()]
        [PXUIField(DisplayName = "Date created")]
        public virtual DateTime? DateCreated { get; set; }
        public abstract class dateCreated : PX.Data.BQL.BqlDateTime.Field<dateCreated> { }
        #endregion
      }
}