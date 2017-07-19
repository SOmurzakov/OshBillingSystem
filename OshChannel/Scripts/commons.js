// show edit value dialog
function editValue(caption, text, btnText, btnClass, maxLength, onConfirm) {
    var modal = $('#editValueModal');
    $('h3', '#editValueModal .modal-header').html(caption);
    $('input', '#editValueModal .modal-body').val(text);

    if (maxLength > 0) {
        $('input', '#editValueModal .modal-body').attr('maxlength', maxLength);
    } else {
        $('input', '#editValueModal .modal-body').removeAttr('maxlength');
    }

    $('.confirmButton', '#editValueModal .modal-footer')
        //.resetPressed()
        .text(btnText)
        .removeClass('btn-danger').removeClass('btn-success').addClass(btnClass).unbind('click')
        .click(function() {
            var value = $('input', '#editValueModal .modal-body').val();

            if (!value) {
                alert('Не может быть пустым');
            } else if (maxLength > 0 && value.length > maxLength) {
                alert('Должно иметь меньше ' + maxLength + ' символов.');
            } else {
                modal.modal('hide');
                $('.confirmButton', '#editValueModal .modal-footer').unbind('click');
                if (onConfirm != null) {
                    onConfirm(value);
                }
            }
        });

    modal.modal('show');
    $('input', '#editValueModal .modal-body').focus();
}

function datetimepicker(selector) {
    $(selector).datepicker({
        dateFormat: "dd.mm.yy",
        monthNames: ["Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"],
        dayNamesMin: ["Вс", "Пн", "Вт", "Ср", "Чт", "Пт", "Сб"],
        nextText: "Следующий",
        prevText: "Предыдущий",
        firstDay: 1
    });
    
}