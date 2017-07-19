using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OshChannel.Helpers
{
    public class BootstrapDialog : IDisposable
    {
        private readonly HtmlHelper _helper;
        private readonly bool _useFormHorizontal;
        private readonly string _callingButtonId;
        private readonly string _dialogId;
        private readonly string _saveButtonText;

        public BootstrapDialog(HtmlHelper helper, string dialogId, string dialogCaption, string saveButtonText, bool useFormHorizontal, string callingButtonId)
        {
            _helper = helper;
            _useFormHorizontal = useFormHorizontal;
            _callingButtonId = callingButtonId;
            _dialogId = dialogId;
            _saveButtonText = saveButtonText;

            helper.ViewContext.Writer.WriteLine(string.Format(@"
    <div id='modal-{1}' class='modal hide' tabindex='-1' role='dialog' aria-labelledby='caption-{1}' aria-hidden='true'>
        <div class='modal-header'>
            <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>
            <h3 id='caption-{1}'>{0}</h3>
        </div>
        <div class='modal-body'>
                
            <div class='form-horizontal'>
", dialogCaption, dialogId));
        }

        public void Dispose()
        {
            _helper.ViewContext.Writer.WriteLine(string.Format(@"
            </div>

        </div>
        <div class='modal-footer'>
            <button class='btn' data-dismiss='modal' aria-hidden='true'>Отмета</button>
            <button class='btn btn-primary' id='save-{0}'>{1}</button>
        </div>
    </div>

<script type='text/javascript'>

    $(function () {{

        $('#{2}').click(function () {{
            $('#modal-{0}').modal('show');
        }});

        $('#save-{0}').click(function () {{
            save_{0}();
        }});
    }});

</script>
", _dialogId, _saveButtonText, _callingButtonId));
        }


        public void InputText(string label, string id, string value)
        {
            Input(label, "text", id, value);
        }

        public void Input(string label, string type, string id, string value)
        {
            _helper.ViewContext.Writer.WriteLine(string.Format(@"
                <div class='control-group'>
                    <label class='control-label' for='{4}-{2}'>{0}</label>
                    <div class='controls'>
                        <input type='{1}' id='{4}-{2}' value='{3}'/>
                    </div>
                </div>
", label, type, id, value, _dialogId));
        }

        public void Hiddent(string id, string value)
        {
            _helper.ViewContext.Writer.WriteLine(string.Format("<input type='hidden' id='{0}-{1}' value='{2}' />", _dialogId, id, value));
        }

    }

}