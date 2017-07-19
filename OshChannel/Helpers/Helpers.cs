using System.Web.Mvc;
using OshBusinessModel.Data;
using System;
namespace OshChannel.Helpers
{
    public static class Helpers
    {

        // html

        public static MvcHtmlString LineThrought(this HtmlHelper helper, bool lineThrought)
        {
            return new MvcHtmlString(lineThrought ? " style=\"text-decoration: line-through;\"" : "");
        }

        public static MvcHtmlString If(this HtmlHelper helper, bool condition, string text)
        {
            return new MvcHtmlString(condition ? text : "");
        }

        public static BootstrapDialog Dialog(this HtmlHelper helper, string dialogId, string dialogCaption, string saveButtonText, bool useFormHorizontal, string callingButtonId)
        {
            return new BootstrapDialog(helper, dialogId, dialogCaption, saveButtonText, useFormHorizontal, callingButtonId);
        }

        public static string Ajax(this HtmlHelper helper, string url)
        {
            helper.ViewContext.Writer.WriteLine(string.Format(@"
        var json = JSON.stringify(dto);

        $.ajax({{
            url: '{0}',
            type: 'POST',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            data: json,
            success: function (result) {{

                if (result['Success']) {{
                    location.reload();
                }} else {{
                    alert(result['Message']);
                }}

            }},
            error: function (jqXHR, textStatus, errorThrown) {{
                alert(jqXHR);
                alert(textStatus);
                alert(errorThrown);
            }}
        }});
", url));
            return "";
        }

        public static string ToDate(this HtmlHelper helper, DateTime date)
        {
            return date.ToShortDateString();
        }

        // url

        public static MvcHtmlString Link(string url, string name)
        {
            return new MvcHtmlString(string.Format("<a href=\"{0}\">{1}</a>", url, name));
        }

        public static string UserDetails(this UrlHelper helper, int userId)
        {
            return helper.Action("Details", "Users", new {userId,});
        }

        public static string Tariff(this UrlHelper helper, string tariffId)
        {
            return helper.Action("Details", "Tariffs", new {tariff = tariffId,});
        }

        public static MvcHtmlString Tariff(this UrlHelper helper, string tariffId, string tariffName)
        {
            return
                new MvcHtmlString(string.Format("<a href=\"{0}\">{1}</a>",
                                                helper.Action("Details", "Tariffs", new {tariff = tariffId,}), tariffName));
        }

        public static MvcHtmlString Contract(this UrlHelper helper, int contractId, string contractName)
        {
            return Contract(helper, contractId, contractName, 0);
        }

        public static MvcHtmlString Contract(this UrlHelper helper, int contractId, string contractName, int archiveId)
        {
            var name = archiveId <= 0
                           ? contractName
                           : string.Format("{0} ({1})", contractName, archiveId);

            return
                new MvcHtmlString(string.Format("<a href=\"{0}\">{1}</a>",
                                                helper.Action("Show", "Contracts", new {contractId}), name));
        }

        public static MvcHtmlString MobileContract(this UrlHelper helper, int contractId, string contractName)
        {
            return
                new MvcHtmlString(string.Format("<a href=\"{0}\">{1}</a>",
                                                helper.Action("Contract", "m", new {contractId}), contractName));
        }

        public static MvcHtmlString Subscriber(this UrlHelper helper, int subscriberId, string subscriberName)
        {
            return new MvcHtmlString(string.Format("<a href=\"{0}\">{1}</a>", helper.Action("Show", "Subscribers", new {subscriberId}), subscriberName));
        }

        public static MvcHtmlString Area (this UrlHelper helper, int areaId, string areaName)
        {
            return areaId <= 0
                       ? new MvcHtmlString("")
                       : new MvcHtmlString(string.Format("<a href=\"{0}\">{1}</a>", helper.Action("Index", "Areas"),
                                                         areaName));
        }

        public static string TariffOption(this UrlHelper helper, string optionId)
        {
            return helper.Action("TariffOption", "Tariffs", new {option = optionId,});
        }

        public static MvcHtmlString TariffOption(this UrlHelper helper, string optionId, string name)
        {
            return new MvcHtmlString(string.Format("<a href=\"{0}\">{1}</a>", TariffOption(helper, optionId), name));
        }

        public static string Settings(this UrlHelper helper, string key)
        {
            return helper.Action("Details", "Settings", new {key,});
        }

        public static MvcHtmlString User(this UrlHelper helper, int userId, string userName)
        {
            return
                new MvcHtmlString(userId <= 0
                                      ? ""
                                      : string.Format("<a href=\"{0}\">{1}</a>", UserDetails(helper, userId), userName));
        }

        public static string Home(this UrlHelper helper)
        {
            if (Auth.User != null)
            {
                var userType = UserType.GetUserTypeById(Auth.User.Role);

                if (userType == UserType.Unknown)
                {
                    return helper.Action("Index", "Index");
                }
                else
                {
                    return helper.Action("Index", userType.AspController);
                }
            }
            else
            {
                return helper.Action("Index", "Index");
            }
        }

        public static MvcHtmlString VisaInfo(this UrlHelper helper, bool visaRequired, int visaGivenUserId, string visaGivenName, DateTime? visaGivenDate, OshBusinessModel.Data.Permission givePermission, int changeId, string controller, string subcategory = "")
        {
            if (visaRequired)
            {
                if (visaGivenUserId != 0)
                {
                    return new MvcHtmlString(
                        (visaGivenUserId < 0 ? "Отклонена <br />" : "") +
                        
                        visaGivenDate.Value.ToShortDateString() + "<br />" + User(helper, Math.Abs(visaGivenUserId), visaGivenName).ToString());
                }
                else
                {
                    if (Auth.HasPermission(givePermission))
                    {
                        return new MvcHtmlString(
                            string.Format(
                                @"<button class=""visabtn btn btn-mini btn-success visa-{0}-{1}-Approve-{2}"">Утвердить</button> <button class=""visabtn btn btn-mini btn-danger visa-{0}-{1}-Decline-{2}"">Отклонить</button>",
                                controller, changeId, subcategory
                                )
                            );
                    }
                    else
                    {
                        return new MvcHtmlString("Ожидание визы");
                    }
                }
            }
            else
            {
                return new MvcHtmlString("");
            }
        }

        public static MvcHtmlString VisaRequiredCss(this UrlHelper helper, bool visaRequired, int visaGivenUserId)
        {
            return new MvcHtmlString(!visaRequired || visaGivenUserId > 0 ? ""
                : visaGivenUserId < 0 ? " class='visaDeclined' " : " class='visaRequired'");
        }

        public static MvcHtmlString Settings(this UrlHelper helper, string key, string description)
        {
            return new MvcHtmlString(string.Format("<a href=\"{0}\">{1}</a>", helper.Action("Details", "Settings", new {key,}), description));
        }

        public static MvcHtmlString Subagent(this UrlHelper helper, int subagentId, string name)
        {
            return new MvcHtmlString(
                subagentId <= 0
                    ? ""
                    : string.Format("<a href=\"{0}\">{1}</a>",
                                    helper.Action("Transactions", "Subagents", new {subagentId}), name));
        }

        public static MvcHtmlString SubscribersDictionaryPage(this UrlHelper helper, string type, int pageNumber, string name, bool isActive)
        {
            return Link(!isActive ? helper.Action("Dictionary", "Subscribers", new {type, pageNumber,}) : "javascript:void(0)", name);
        }

    }
}