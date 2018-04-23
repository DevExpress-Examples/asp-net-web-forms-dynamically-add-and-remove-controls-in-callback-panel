using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using DevExpress.Web;
using System.Web.UI;
using System.Collections.Specialized;
using System.Collections;

namespace PageControlWithinCallbackPanel {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Init(object sender, EventArgs e) {
            if(!IsPostBack) {
                ClearTabs();
                AddTab("Type 1");
            }
            else {
                RestoreTabs();
            }
        }

        protected void Page_Load(object sender, EventArgs e) {
        }

        protected void CallbackHandler(object sender, CallbackEventArgsBase e) {
            string[] parameters = e.Parameter.Split(':');
            string action = parameters[0];
            string target = parameters[1];

            if(action == "remove")
                RemoveTab(int.Parse(target));
            else if(action == "add")
                AddTab(target);
        }

        void ClearTabs() {
            Session.Clear();
            Session.Remove("tabs");
            Session.Remove("uid");
        }
        void AddTab(string tabType) {
            string tabId = GenUID();

            CreateTab(tabId, tabType);
            PageControl.ActiveTabIndex = PageControl.TabPages.Count - 1;

            SaveTabInfo(tabId, tabType);
        }
        void RestoreTabs() {
            var tabsInfo = Session["tabs"] as OrderedDictionary;

            if(tabsInfo != null) {
                foreach(DictionaryEntry tabInfo in tabsInfo)
                    CreateTab((string)tabInfo.Key, (string)tabInfo.Value);
            }
        }
        void RemoveTab(int index) {
            var tabsInfo = Session["tabs"] as OrderedDictionary;

            if(tabsInfo != null) {
                tabsInfo.Remove(PageControl.TabPages[index].Name);
                Session["tabs"] = tabsInfo;
            }

            if(index < PageControl.ActiveTabIndex) {
                PageControl.ActiveTabIndex--;
            }

            PageControl.TabPages.RemoveAt(index);
        }

        string GenUID() {
            int uid = (int)(Session["uid"] ?? 0);
            Session["uid"] = ++uid;

            return "TabPageUID" + uid;
        }
        void CreateTab(string id, string tabType) {
            TabPage tab = new TabPage();
            tab.Text = tabType;
            tab.Name = id;

            string tabContentPath = null;
            switch(tabType) {
                case "Type 1":
                    tabContentPath = "~/TabsContent/TabContentType1.ascx";
                    break;
                case "Type 2":
                    tabContentPath = "~/TabsContent/TabContentType2.ascx";
                    break;
                default: break;
            }

            Control ctrl = LoadControl(tabContentPath);
            ctrl.ID = id;
            tab.Controls.Add(ctrl);

            PageControl.TabPages.Add(tab);
        }
        void SaveTabInfo(string id, string tabType) {
            var tabsInfo = Session["tabs"] as OrderedDictionary;

            if(tabsInfo == null)
                tabsInfo = new OrderedDictionary();
            tabsInfo.Add(id, tabType);

            Session["tabs"] = tabsInfo;
        }
    }
}