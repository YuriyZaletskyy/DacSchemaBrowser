<%@ Page Language="C#" MasterPageFile="~/MasterPages/FormDetail.master" AutoEventWireup="true"
	ValidateRequest="false" CodeFile="AT102000.aspx.cs" Inherits="Page_AT102000" Title="Acumatica Tables" %>

<%@ MasterType VirtualPath="~/MasterPages/FormDetail.master" %>

<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
	<px:PXDataSource ID="ds" runat="server" Visible="True" Width="100%" TypeName="TableSchemaReader.AcumaticaTablesMaint"
		PrimaryView="AcumaticaTablesView">
		<CallbackCommands>
			<px:PXDSCallbackCommand CommitChanges="True" Name="Save" />
			<px:PXDSCallbackCommand Name="Delete" Visible="false" />
			<px:PXDSCallbackCommand Name="CopyPaste" Visible="false" />
			<px:PXDSCallbackCommand Name="First" PostData="Self" StartNewGroup="True" />
		</CallbackCommands>
	</px:PXDataSource>
</asp:Content>

<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
	<px:PXFormView ID="form" runat="server" DataSourceID="ds" Style="z-index: 100"
		Width="100%"  DataMember="AcumaticaTablesView"
		 TemplateContainer="" TabIndex="100">
	    <CallbackCommands>
	        <Save PostData="Self" />
	    </CallbackCommands>
		<Template> 
			<px:PXLayoutRule runat="server" StartColumn="True"  LabelsWidth="SM" 
				ControlSize="M" />
			<px:PXSelector ID="edTableName" runat="server" DataField="TABLENAME" AutoRefresh="True" CommitChanges="True">
			</px:PXSelector>
		</Template>
	</px:PXFormView>
</asp:Content>

<asp:Content ID="cont3" ContentPlaceHolderID="phG" runat="Server" >
	<px:PXTab ID="tab" runat="server" Height="168%" Style="z-index: 100" Width="100%" SelectedIndex="1" TabIndex="200">
		<Items>
			<px:PXTabItem Text="Table fields">
				<Template>
					<px:PXGrid ID="gridFields" BorderWidth="0px" runat="server" DataSourceID="ds" Height="150px"
							   Style="z-index: 100" Width="100%" AllowPaging="True" AdjustPageSize="Auto"
							   AllowSearch="True" SkinID="Details" TabIndex="300">
						<Levels>
							<px:PXGridLevel DataMember="AcumaticaTablesFieldsView">
								<Mode AllowAddNew="True" AllowDelete="False" />
								<RowTemplate>
									<%--<px:PXLayoutRule runat="server" StartColumn="True"  LabelsWidth="SM" ControlSize="M" />
									<px:PXSelector ID="edUsername" runat="server" DataField="Username" TextField="Username" />
									<px:PXTextEdit ID="edFullName" runat="server" DataField="FullName" />
									<px:PXTextEdit ID="edComment" runat="server" DataField="Comment"  />
									<px:PXCheckBox ID="chkIncluded" runat="server" DataField="Included" />--%>

								</RowTemplate>
								<Columns>
									<px:PXGridColumn DataField="ISKey" Width="200px" AllowUpdate="False" />
									<px:PXGridColumn DataField="Name" Width="300px" AllowUpdate="False" />
									<px:PXGridColumn DataField="DisplayName" Width="300px" AllowUpdate="False" />
									<px:PXGridColumn DataField="DataLengthDefaultValue" Width="300px" AllowUpdate="False" />
									<px:PXGridColumn DataField="DataType" Width="300px" AllowUpdate="False" />

								</Columns>
							</px:PXGridLevel>
						</Levels>
						<AutoSize Enabled="True" />
						<Mode AllowDelete="False" />
					
					</px:PXGrid>
					
				</Template>
			</px:PXTabItem>

		</Items>
		<AutoSize Container="Window" Enabled="True" MinHeight="250" MinWidth="300" />
	</px:PXTab>
</asp:Content>
