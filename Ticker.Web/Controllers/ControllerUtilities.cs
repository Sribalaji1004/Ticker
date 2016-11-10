using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using Ticker.Data;
//using System.Web.Mvc;

namespace Ticker.Controllers
{
    public class Utilities
    {
        public enum Action_Flag { ADDITION = 1, CHANGE = 2, DELETION = 3 }
        public enum App_Label { auth, contenttypes, sessions, sites, admin, south, FoxTick }
        public static void Write_Admin_Log(FoxTickerEntities db, App_Label app_label, Type model, Action_Flag action_flag, string object_id, string object_repr, string change_message, bool save = false)
        {
            //db.Mapping.GetTables();
            auth_admin_log dal = new auth_admin_log();
            dal.action_flag = (short)action_flag;
            dal.action_time = DateTime.Now;
            dal.user_id = int.Parse(HttpContext.Current.Session["UserID"].ToString());
            dal.change_message = change_message;
            string label = app_label.ToString();
            dal.auth_content_type = db.auth_content_type.Where(dct => dct.app_label == label && dct.model == model.Name.ToLower() + "s").FirstOrDefault();
            dal.object_id = object_id;
            if (object_repr.Length > 200)
                object_repr = object_repr.Substring(0, 199);

            dal.object_repr = object_repr;

            db.auth_admin_log.AddObject(dal);
            if (save)
            {
            }
                //db.SaveChanges();
        }
        private static string SnRTag(string note, string tag, string replaceTag)
        {
            string fulltag = "#" + tag + "#";
            int foundTag = 0;
            int foundDelimiter = 0;
            string replString = "";
            while (true)
            {
                foundTag = note.IndexOf(fulltag);
                if (foundTag > -1)
                {
                    foundDelimiter = note.IndexOf(' ', foundTag);
                    if (foundDelimiter == -1)
                        foundDelimiter = note.IndexOf('.', foundTag);

                    if (foundDelimiter > -1)
                    {
                        replString = note.Substring(foundTag + fulltag.Length, foundDelimiter - foundTag - fulltag.Length + 1);
                        note = note.Substring(0, foundTag) + "&lt;" + replaceTag + "&gt;" + replString + "&lt;/" + replaceTag + "&gt;" + note.Substring(foundDelimiter + 1, note.Length - foundDelimiter - 1);
                    }
                    else
                    {
                        replString = note.Substring(foundTag + fulltag.Length, note.Length - foundTag - fulltag.Length);
                        note = note.Substring(0, foundTag) + "&lt;" + replaceTag + "&gt;" + replString + "&lt;/" + replaceTag + "&gt;";
                        if (note.IndexOf(fulltag) == -1)
                            break;
                    }
                }
                else
                    break;
            }
            return note;

        }
        public static string ConvertFromHTML(string note)
        {
            note = note.Replace("&rsquo;", "'");
            note = note.Replace("&nbsp;", " ");
            note = note.Replace("<br>", " ");
            note = note.Replace("<br />", "\n");

            note = note.Replace("<span style=\"color:WHITE;\"></span>", "");
            note = note.Replace("<span style=\"color:YELLOW;\"></span>", "");
            note = note.Replace("<span style=\"color:RED;\"></span>", "");
            note = note.Replace("<span style=\"color:BLUE;\"></span>", "");
            note = note.Replace("<span style=\"color:GREEN;\"></span>", "");

            int colorStart = 0;
            int colorEnd = 0;
            int tagStart = 0;
            string colorName = "";
            for (int i = 0; i < note.Length; i++)
            {
                colorStart = note.IndexOf("color:", i) + 6; //plus length of 'color:'
                if (colorStart != -1 && colorStart != 5) //colorStart=5 would mean not found
                {
                    colorEnd = note.IndexOf(";", colorStart);
                    if (colorEnd != -1)
                    {
                        colorName = note.Substring(colorStart, colorEnd - colorStart);
                        if (colorName != "")
                        {
                            note = note.Substring(0, colorStart - 19) + "@@" + colorName + "##" + note.Substring(colorStart + colorName.Length + 3, note.Length - colorStart - colorName.Length - 3);

                            tagStart = note.IndexOf("</span>", i) + 7; //plus length of 'color:'
                            note = note.Substring(0, tagStart - 7) + "@@/" + colorName + "##" + note.Substring(tagStart, note.Length - tagStart);
                        }
                    }

                    //note = note.Substring(note.IndexOf(colorName
                    //note=note.Substring(note.Substring(0,i) + note.Substring(  note.Substring(note.IndexOf "</span>",);
                }
            }

            note = note.Replace("<span style=\"color:", "<");
            note = note.Replace("</span>", "</");

            ////reverse 
            //note = note.Replace("BLACK;\">", "WHITE#");

            note = note.Replace("WHITE;\">", "WHITE#");
            note = note.Replace("YELLOW;\">", "YELLOW#");
            note = note.Replace("RED;\">", "RED#");
            note = note.Replace("BLUE;\">", "BLUE#");
            note = note.Replace("GREEN;\">", "GREEN#");

            //reverse
            //note = note.Replace("WHITE;\">", "BLACK#");
            note = note.Replace("BLACK;\">", "BLACK#");

            //remove kendo garbage additives
            note = note.Replace("<span style=\"font-family:Verdana, 'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:14px;\">", "");

            return note;
        }
        public static string RemoveHTML(string note)
        {
            note = note.Replace("&amp;","&");
            note = note.Replace("&rsquo;", "'");
            note = note.Replace("&nbsp;", " ");
            note = note.Replace("<br>", " ");
            note = note.Replace("<br />", "\n");

            note = note.Replace("<span style=\"color:", "");
            note = note.Replace("</span>", "");

            note = note.Replace("<font color='", "");
            note = note.Replace("</font>", "");

            ////reverse 
            //note = note.Replace("BLACK;\">", "");

            note = note.Replace("WHITE;\">", "");
            note = note.Replace("WHITE'>", "");
            note = note.Replace("YELLOW;\">", "");
            note = note.Replace("YELLOW'>", "");
            note = note.Replace("RED;\">", "");
            note = note.Replace("RED'>", "");
            note = note.Replace("BLUE;\">", "");
            note = note.Replace("BLUE'>", "");
            note = note.Replace("GREEN;\">", "");
            note = note.Replace("GREEN'>", "");

            //reverse
            note = note.Replace("WHITE;\">", "");
            note = note.Replace("BLACK;\">", "");

            //remove kendo garbage additives
            note = note.Replace("<span style=\"font-family:Verdana, 'Helvetica Neue', Helvetica, Arial, sans-serif;font-size:14px;\">", "");

            return note;
        }
        public static string ConvertToHTML(string note)
        {
            if (note == null) return null;
            //handle special characters
            //note = note.Replace(char.ConvertFromUtf32(34), "&amp;#34;");
            //note = note.Replace(char.ConvertFromUtf32(38), "&amp;#38;"); //&
            //note = note.Replace(char.ConvertFromUtf32(93), "&amp;#93;");
            //note = note.Replace(char.ConvertFromUtf32(60), "&amp;#60;");
            //note = note.Replace(char.ConvertFromUtf32(62), "&amp;#62;");

            note = note.Replace("<WHITE>", "<span style=\"color:WHITE;\">");
            note = note.Replace("</WHITE>", "</span>");
            note = note.Replace("<YELLOW>", "<span style=\"color:YELLOW;\">");
            note = note.Replace("</YELLOW>", "</span>");
            note = note.Replace("<RED>", "<span style=\"color:RED;\">");
            note = note.Replace("</RED>", "</span>");
            note = note.Replace("<BLUE>", "<span style=\"color:BLUE;\">");
            note = note.Replace("</BLUE>", "</span>");
            note = note.Replace("<GREEN>", "<span style=\"color:GREEN;\">");
            note = note.Replace("</GREEN>", "</span>");
            note = note.Replace("<BLACK>", "<span style=\"color:BLACK;\">");
            note = note.Replace("</BLACK>", "</span>");

            note = SnRTag(note, "WHITE", "DefaultColor");
            note = SnRTag(note, "YELLOW", "Color2");
            note = SnRTag(note, "RED", "Color3");
            note = SnRTag(note, "BLUE", "Color4");
            note = SnRTag(note, "GREEN", "Color5");
            note = SnRTag(note, "BLACK", "Color6");

            note = note.Replace("\n", "<br />");

            ////reverse white to black
            //note = note.Replace("&lt;DefaultColor&gt;", "<font color='BLACK'>");
            //note = note.Replace("&lt;/DefaultColor&gt;", "</font>");

            note = note.Replace("&lt;DefaultColor&gt;", "<font color='WHITE'>");
            note = note.Replace("&lt;/DefaultColor&gt;", "</font>");

            note = note.Replace("&lt;Color2&gt;", "<font color='YELLOW'>");
            note = note.Replace("&lt;/Color2&gt;", "</font>");

            note = note.Replace("&lt;Color3&gt;", "<font color='RED'>");
            note = note.Replace("&lt;/Color3&gt;", "</font>");

            note = note.Replace("&lt;Color4&gt;", "<font color='BLUE'>");
            note = note.Replace("&lt;/Color4&gt;", "</font>");

            note = note.Replace("&lt;Color5&gt;", "<font color='GREEN'>");
            note = note.Replace("&lt;/Color5&gt;", "</font>");

            note = note.Replace("&lt;Color6&gt;", "<font color='BLACK'>");
            note = note.Replace("&lt;/Color6&gt;", "</font>");

            //reverse black to wrhite
            //note = note.Replace("&lt;Color6&gt;", "<font color='WHITE'>");
            //note = note.Replace("&lt;/Color6&gt;", "</font>");

            //if (!note.Contains("BLACK"))
            //    note = "<span style='background-color:black;'>" + note + "</span>";

            note = note.Replace("  ", " "); //replace double space w/single
            return note;
        }
        public static void BreakingNewsTypesLoad()
        {
            System.Web.HttpContext.Current.Application["BreakingNewsTypes"] = new Ticker.Data.FoxTickerEntities().BreakingNewsTypes.Where(bnt => bnt.Enabled == true);
        }

        public static void ExpirationModesLoad()
        {
            System.Web.HttpContext.Current.Application["ExpirationModes"] = new Ticker.Data.FoxTickerEntities().BreakingNewsExpirationModes;
        }

        public static void LoadClientShares(FoxTickerEntities db, int cid)
        {
            db.Clients.Single(s => s.ID == cid).Clients.Load();
        }
        public sealed class SessionBag : DynamicObject
        {
            private static readonly SessionBag sessionBag;

            static SessionBag()
            {
                sessionBag = new SessionBag();
            }

            private SessionBag()
            {
            }

            private HttpSessionStateBase Session
            {
                get { return new HttpSessionStateWrapper(HttpContext.Current.Session); }
            }

            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = Session[binder.Name];
                return true;
            }

            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                Session[binder.Name] = value;
                return true;
            }

            public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
            {
                int index = (int)indexes[0];
                result = Session[index];
                return result != null;
            }

            public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
            {
                int index = (int)indexes[0];
                Session[index] = value;
                return true;
            }

            public static dynamic Current
            {
                get { return sessionBag; }
            }
        }
    }
}