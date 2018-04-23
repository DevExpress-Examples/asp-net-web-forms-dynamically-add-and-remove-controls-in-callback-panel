Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web.Script.Serialization
Imports DevExpress.Web.ASPxClasses
Imports DevExpress.Web.ASPxTabControl
Imports System.Web.UI
Imports System.Collections.Specialized
Imports System.Collections

Namespace PageControlWithinCallbackPanel
	Partial Public Class [Default]
		Inherits System.Web.UI.Page
		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			If (Not IsPostBack) Then
				ClearTabs()
				AddTab("Type 1")
			Else
				RestoreTabs()
			End If
		End Sub

		Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		End Sub

		Protected Sub CallbackHandler(ByVal sender As Object, ByVal e As CallbackEventArgsBase)
			Dim parameters() As String = e.Parameter.Split(":"c)
			Dim action As String = parameters(0)
			Dim target As String = parameters(1)

			If action = "remove" Then
				RemoveTab(Integer.Parse(target))
			ElseIf action = "add" Then
				AddTab(target)
			End If
		End Sub

		Private Sub ClearTabs()
			Session.Remove("tabs")
			Session.Remove("uid")
		End Sub
		Private Sub AddTab(ByVal tabType As String)
			Dim tabId As String = GenUID()

			CreateTab(tabId, tabType)
			PageControl.ActiveTabIndex = PageControl.TabPages.Count - 1

			SaveTabInfo(tabId, tabType)
		End Sub
		Private Sub RestoreTabs()
			Dim tabsInfo = TryCast(Session("tabs"), OrderedDictionary)

			If tabsInfo IsNot Nothing Then
				For Each tabInfo As DictionaryEntry In tabsInfo
					CreateTab(CStr(tabInfo.Key), CStr(tabInfo.Value))
				Next tabInfo
			End If
		End Sub
		Private Sub RemoveTab(ByVal index As Integer)
			Dim tabsInfo = TryCast(Session("tabs"), OrderedDictionary)

			If tabsInfo IsNot Nothing Then
				tabsInfo.Remove(PageControl.TabPages(index).Name)
				Session("tabs") = tabsInfo
			End If

			If index < PageControl.ActiveTabIndex Then
				PageControl.ActiveTabIndex -= 1
			End If

			PageControl.TabPages.RemoveAt(index)
		End Sub

		Private Function GenUID() As String
			Dim uid As Integer = CInt(Fix(If(Session("uid"), 0)))
			uid += 1
			Session("uid") = uid

			Return "TabPageUID" & uid
		End Function
		Private Sub CreateTab(ByVal id As String, ByVal tabType As String)
			Dim tab As New TabPage()
			tab.Text = tabType
			tab.Name = id

			Dim tabContentPath As String = Nothing
			Select Case tabType
				Case "Type 1"
					tabContentPath = "~/TabsContent/TabContentType1.ascx"
				Case "Type 2"
					tabContentPath = "~/TabsContent/TabContentType2.ascx"
				Case Else
			End Select

			Dim ctrl As Control = LoadControl(tabContentPath)
			ctrl.ID = id
			tab.Controls.Add(ctrl)

			PageControl.TabPages.Add(tab)
		End Sub
		Private Sub SaveTabInfo(ByVal id As String, ByVal tabType As String)
			Dim tabsInfo = TryCast(Session("tabs"), OrderedDictionary)

			If tabsInfo Is Nothing Then
				tabsInfo = New OrderedDictionary()
			End If
			tabsInfo.Add(id, tabType)

			Session("tabs") = tabsInfo
		End Sub
	End Class
End Namespace